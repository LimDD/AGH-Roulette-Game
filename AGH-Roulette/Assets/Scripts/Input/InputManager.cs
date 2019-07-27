using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using MultiTouchInput;

public class InputManager : MonoBehaviour {

	InputAction currentInput;
	public static InputManager _Instance;

	int numClicked = 0; //The counter to check double click.
	float angleRange = 30f;
	float minSwipeDist = 100f;
	float clickTime;
	float doubleClickThreshold = 0.3f;
	float multiTouchWindow = 0.2f; //Window in which we count it as "Same frame finger".

	Vector2 xAxis = new Vector2(1, 0);
	Vector2 yAxis = new Vector2(0, 1);
	float dragThreshold = 0.4f; //Time it takes for the input to become a drag from swipe.
	Vector2 prevClickPos; //Compare this to current click pos, to distinguish between double click.

	bool isActive;

	//Positions.
	Vector2 startPressPosition; //Will be used for calculating swipe.

	TapInfo oneFinger; //Represents 1 finger inputs.
	TapInfo multiFinger; //Represents multi tap inputs.
	TapInfo keyboardInfo;
	Dictionary<int, Finger> multiTouchDictionary = new Dictionary<int, Finger>();
	List<int> fingerIDs = new List<int>(); //Stores a list of finger ID that is being tracked. It is required for iterating through the touches.
	Finger tempFinger;

	List<InputAction> actionList = new List<InputAction>();

	void Awake() {
		//Singleton
		if (_Instance == null) {
			_Instance = this;
			isActive = true;
			DontDestroyOnLoad(gameObject);
			oneFinger = new TapInfo(); //Initialize necessary tap info.
			multiFinger = new TapInfo();
			keyboardInfo = new TapInfo();
			//Calculate min tap radius.
			if (Screen.width > Screen.height) { // Land scape
				minSwipeDist = Screen.width * 0.04f;
			}
			else { //Portrait
				minSwipeDist = Screen.height * 0.05f;
			}
		}
		else {
			Destroy(gameObject);
		}

	}

	void Update() {
		if (!isActive) {
			return; //Do nothing if it isn't active.
		}
		//Otherwise, take inputs.
		GetNonKeyboardInput();
		GetKeyboardInput();

	}

	void GetNonKeyboardInput() {
		currentInput = InputAction.Null; //Always assume the input is null to begin with.

		if (Input.multiTouchEnabled) {
            //Multi input detected. First, check if the input has the same number of fingers as the last input.
            try
            {
                GetMultiTouchInput();
            }
            catch { }
        }

		if (currentInput != InputAction.Null) {
			//The input was multi touch, reset the single finger input.
			oneFinger.Reset();
			return;
		}

		//More than one finger detected. Don't try to calculate single touch.
		if (multiFinger.numFingerTapped > 1 || Input.touchCount > 1) {
			oneFinger.Reset();
			return;
		}

		if (Input.GetMouseButtonDown(0)) {
			startPressPosition = Input.mousePosition; //This is necessary for calculating swipe/drag input.
			oneFinger.lastPressTime = Time.time;
		}

		//In order for the drag to register, you need to have pressed down past a doubletap threshold.
		if (Input.GetMouseButton(0) && oneFinger.lastPressTime + dragThreshold < Time.time && oneFinger.lastPressTime != 0) {
			//We calculate drag here.
			Vector2 endPosition = Input.mousePosition;
			currentInput = CalculateDrag(endPosition - startPressPosition);
		}

		if (Input.GetMouseButtonUp(0)) { //You tapped the screen. Register swipe now, but do not register tap unless the time passes the double tap threshold.

			//Only calculate as swipe if you are fast enough.
			if (oneFinger.lastPressTime + dragThreshold > Time.time && oneFinger.lastPressTime != 0) {
				Vector2 endPos = Input.mousePosition;
				currentInput = CalculateSwipe(endPos - startPressPosition);
				//If the input turns out to be click.
				if (currentInput == InputAction.Click) {
					currentInput = InputAction.Null; //Reset it to null so you don't trigger click twice.
													 //Check if we should increase number of tap based on distance difference from previous and current position.
					Vector2 curPos = Input.mousePosition;
					if ((curPos - prevClickPos).magnitude > minSwipeDist) {
						oneFinger.numTap = 1;
					}
					else {
						oneFinger.numTap++;
					}
					oneFinger.lastTapTime = Time.time;
					prevClickPos = curPos;
					//Set the previous pos and laptime.
				}
			}
		}

		//If the input is still null and the last input wasn't a drag.
		if (currentInput == InputAction.Null) {

			//Check when was the last time you've tapped.
			if (oneFinger.lastTapTime + doubleClickThreshold < Time.time) {
				//Calculate it as input.
				if (oneFinger.numTap == 1) {
					currentInput = InputAction.Click;
				}
				else if (oneFinger.numTap == 2) {
					currentInput = InputAction.DoubleClick;
				}
				if (oneFinger.numTap > 0) {
					oneFinger.Reset(); //Reset the information.
				}
			}
		}
	}

	void GetMultiTouchInput() {

		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				//if the last press time is less than allowed, reset the dictionary.	
				if (Mathf.Abs(multiFinger.lastPressTime - Time.time) < multiTouchWindow) {
					multiFinger.numFinger++;
				}
				else {
					multiTouchDictionary.Clear();
					fingerIDs.Clear();
					multiFinger.numFinger = 1;
					multiFinger.lastPressTime = Time.time;
				}
				//Add the finger to the dictionary,
				multiTouchDictionary.Add(Input.GetTouch(i).fingerId, new Finger(Input.GetTouch(i), i));
				fingerIDs.Add(Input.GetTouch(i).fingerId);
				//Clear the action stack because a new press is detected.
				actionList.Clear();
			}

			if (Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled) {

				if (multiTouchDictionary.TryGetValue(Input.GetTouch(i).fingerId, out tempFinger)) {
					//Before we remove it, calculate the current swipe value for each finger and save it onto the stack.
					actionList.Add(CalculateSwipe(tempFinger.DeltaPosition));
					//Debug text.
					//Check if it exists in dictionary, and remove if so.
					multiTouchDictionary.Remove(Input.GetTouch(i).fingerId);
					fingerIDs.Remove(Input.GetTouch(i).fingerId);
				}

				//Compare the last tap time.
				if (Mathf.Abs(multiFinger.lastFingerLeaveTime - Time.time) < multiTouchWindow) {
					multiFinger.numFingerLeft++;
				}
				else {
					multiFinger.numFingerLeft = 1;
					multiFinger.lastFingerLeaveTime = Time.time;
				}
			}
		}

		if (multiTouchDictionary.Count == 0) {

			//The number of fingers presse is equal to the number of fingers left. It also has to have more than 1 finger so that it is a multi touch.
			if (multiFinger.numFinger == multiFinger.numFingerLeft && multiFinger.numFinger > 1) {
				//Check if the inputs are swipes.
				InputAction curInput = actionList[0];
				bool isSameAction = true;
				for (int i = 1; i < actionList.Count; i++) {
					if (curInput != actionList[i]) {
						isSameAction = false;
					}
				}

				if (!isSameAction) { //One of the finger had different from the rest of fingers.
					multiFinger.ResetFinger();
					/*}else if (multiFinger.lastPressTime + dragThreshold + multiTouchWindow < Time.time) { Uncomment this if you want to have drag threshold on multi finger. 
						//Will need to be a drag, not a swipe.
						multiFinger.ResetFinger();*/
				}
				else {
					if (curInput == InputAction.Click) {
						//It is a successful tap. Now we check if the number of fingers previously is same as the currently saved.
						if (multiFinger.numTap > 0) {
							bool isSameNumFinger = multiFinger.numFinger == multiFinger.numFingerTapped;
							if (!isSameNumFinger) {
								multiFinger.numTap = 0; //Reset the number of tap because the number of fingers tapped is now different.
							}
						}
						else { //This is the first tap with this number of fingers.
							multiFinger.numFingerTapped = multiFinger.numFinger;
						}
						multiFinger.lastTapTime = Time.time;
						multiFinger.numTap++;
						multiFinger.ResetFinger();
					}
					else { //It is a swipe.
						currentInput = InputCalculator.Calculate(multiFinger.numFinger, curInput);
					}
				}

			}

			if (multiFinger.lastTapTime + doubleClickThreshold < Time.time) {
				//Only count as tap IF the last finger pressed time is less than the drag threshold.
				if (multiFinger.lastPressTime + dragThreshold + multiTouchWindow > Time.time && multiFinger.lastPressTime != 0) {
					//Calculate the tap and reset the value.																							  
					if (multiFinger.numTap == 1) {
						currentInput = InputCalculator.Calculate(multiFinger.numFingerTapped, InputAction.Click);
					}
					else if (multiFinger.numTap == 2) {
						currentInput = InputCalculator.Calculate(multiFinger.numFingerTapped, InputAction.DoubleClick);
					} //We don't do beyond double tap.
				}

				//Reset the tap.
				multiFinger.Reset();
			}

		}
		else {
			//Check if any of the finger left the screen OR if there are more than 5 fingers. We don't calculate beyond 5 fingers.
			if (multiFinger.numFingerLeft > 0 || multiFinger.numFinger > 5) {
				currentInput = InputAction.Null;
			}

			//Check if the finger has been pressed long enough to count as a drag.
			if (multiFinger.lastPressTime + multiTouchWindow < Time.time && multiFinger.lastPressTime != 0) {
				//Calculate the drag.
				multiTouchDictionary[fingerIDs[0]].action = CalculateDrag(multiTouchDictionary[fingerIDs[0]].DeltaPosition);
				bool isSameAction = true;
				for (int i = 1; i < multiTouchDictionary.Count; i++) {
					multiTouchDictionary[fingerIDs[i]].action = CalculateDrag(multiTouchDictionary[fingerIDs[i]].DeltaPosition);
					if (multiTouchDictionary[fingerIDs[0]].action != multiTouchDictionary[fingerIDs[i]].action) {
						isSameAction = false;
					}
				}
				if (isSameAction) {
					//It becomes a drag.
					currentInput = InputCalculator.Calculate(Input.touchCount, multiTouchDictionary[fingerIDs[0]].action);
				}
				else {
					//The input isnt the same. Now we check if the input is pinch in/out.
					if (multiFinger.numFinger == 2) {
						currentInput = CalculatePinch();

					}
				}
			}
		}
	}

	InputAction CalculatePinch() {

		//In order to be pinch, you need to have moved the finger.
		if (!multiTouchDictionary[fingerIDs[1]].IsMoving || !multiTouchDictionary[fingerIDs[1]].IsMoving) {
			return InputAction.Null;
		}

		//TODO: PINCH


		//Need to get each swipe action.
		int topID = 0;//This is the finger that is sitting at the top.
		int botID = 1;
		if (multiTouchDictionary[fingerIDs[1]].CurrentPosition.y > multiTouchDictionary[fingerIDs[0]].CurrentPosition.y) {
			topID = 1;
			botID = 0;
		}

		//Now we need to check if the top and bot has correct swipe input.
		if (multiTouchDictionary[fingerIDs[topID]].action == InputAction.DragUp && multiTouchDictionary[fingerIDs[botID]].action == InputAction.DragDown) {
			return InputAction.PinchOut;
		}
		else if (multiTouchDictionary[fingerIDs[topID]].action == InputAction.DragDown && multiTouchDictionary[fingerIDs[botID]].action == InputAction.DragUp) {
			return InputAction.PinchIn;
		}
		else { //It could be a horizontal pinch. Check horizontal position.
			int leftID = 0;
			int rightID = 1;
			//Calculate the current position to see which finger is on left and which is on right.
			if (multiTouchDictionary[fingerIDs[0]].CurrentPosition.x > multiTouchDictionary[fingerIDs[1]].CurrentPosition.x) {
				leftID = 1;
				rightID = 0;
			}
			//Get current velocity of the finger, reset the position if the velocity is low.
			/*if () {

			}*/

			if (multiTouchDictionary[fingerIDs[leftID]].action == InputAction.DragLeft && multiTouchDictionary[fingerIDs[rightID]].action == InputAction.DragRight) {
				return InputAction.PinchOut;
			}
			else if (multiTouchDictionary[fingerIDs[leftID]].action == InputAction.DragRight && multiTouchDictionary[fingerIDs[rightID]].action == InputAction.DragLeft) {
				return InputAction.PinchIn;
			}
			else {
				return InputAction.Null; //This is not a pinch action.
			}

		}

	}

	/// <summary>
	/// Is the finger on screen for a long time.
	/// </summary>
	/// <returns></returns>
	public bool IsHover()
	{
		return ( CurrentInput == InputAction.Pressed
			|| CurrentInput == InputAction.DragDown
			|| CurrentInput == InputAction.DragUp
			|| currentInput == InputAction.DragRight
            || CurrentInput == InputAction.DragLeft
		);
	}

	InputAction CalculateDrag(Vector2 vector) {
		if (vector.magnitude > minSwipeDist) {
			vector.Normalize();
			float angle = Vector2.Dot(vector, xAxis);
			angle = Mathf.Acos(angle) * Mathf.Rad2Deg;
			float horizontalAngleRange = 60f;
			if (angle < horizontalAngleRange) {
				//Swiped right no release
				return InputAction.DragRight;
			}
			else if ((180f - angle) < horizontalAngleRange) {
				//Swiped left no release
				return InputAction.DragLeft;
			}
			else { //Swiped down or up.
				angle = Vector2.Dot(vector, yAxis);
				angle = Mathf.Acos(angle) * Mathf.Rad2Deg;
				if (angle < angleRange) {
					//dragged up
					return InputAction.DragUp;

				}
				else if ( (180f - angle) < angleRange){
					//dragged down
					return InputAction.DragDown;
				} else
				{
					return InputAction.Pressed;
				}

			}
		}
		else { //No swipe detected. You are dragging in current position.
			return InputAction.Pressed;
		}

	}

	InputAction CalculateSwipe(Vector2 vector) {

		//checks if the swipe has enough speed and distance.
		if (vector.magnitude > minSwipeDist) {
			vector.Normalize();
			float angle = Vector2.Dot(vector, xAxis);
			angle = Mathf.Acos(angle) * Mathf.Rad2Deg;
			float horizontalAngleRange = 60f;
			oneFinger.ResetTap();
			//Reset the tap info because its a swipe, not a tap.
			if (angle < horizontalAngleRange) {
				//Swiped right
				return InputAction.SwipeRight;
			}
			else if ((180f - angle) < horizontalAngleRange) {
				//Swiped left
				return InputAction.SwipeLeft;
			}
			else {
				angle = Vector2.Dot(vector, yAxis);
				angle = Mathf.Acos(angle) * Mathf.Rad2Deg;
				if (angle < angleRange) {
					//Swiped Top
					return InputAction.SwipeUp;
				}
				else if ( (180f - angle) < angleRange){
					//Swiped bot.
					return InputAction.SwipeDown;
				} else
				{
					return InputAction.Null;
				}
			}
		}
		else { //Tap.
			return InputAction.Click;
		}
	}
	//
	void GetKeyboardInput() {

		if (Input.GetKeyUp(KeyCode.RightArrow) && keyboardInfo.lastPressTime + dragThreshold > Time.time) {
			currentInput = InputAction.SwipeRight;
		}

		if (Input.GetKeyUp(KeyCode.LeftArrow) && keyboardInfo.lastPressTime + dragThreshold > Time.time) {
			currentInput = InputAction.SwipeLeft;
		}

		if (Input.GetKeyUp(KeyCode.UpArrow) && keyboardInfo.lastPressTime + dragThreshold > Time.time) {
			currentInput = InputAction.SwipeUp;
		}

		if (Input.GetKeyUp(KeyCode.DownArrow) && keyboardInfo.lastPressTime + dragThreshold > Time.time) {
			currentInput = InputAction.SwipeDown;
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			keyboardInfo.lastPressTime = Time.time;
		}

		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			keyboardInfo.lastPressTime = Time.time;
		}

		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			keyboardInfo.lastPressTime = Time.time;
		}

		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			keyboardInfo.lastPressTime = Time.time;
		}

		if(Input.GetKey(KeyCode.DownArrow) && keyboardInfo.lastPressTime + dragThreshold < Time.time)
		{
			currentInput = InputAction.DragDown;
		}

		if(Input.GetKey(KeyCode.UpArrow) && keyboardInfo.lastPressTime + dragThreshold < Time.time)
		{
			currentInput = InputAction.DragUp;
		}

		if(Input.GetKey(KeyCode.LeftArrow) && keyboardInfo.lastPressTime + dragThreshold < Time.time)
		{
			currentInput = InputAction.DragLeft;
		}

		if(Input.GetKey(KeyCode.RightArrow) && keyboardInfo.lastPressTime + dragThreshold < Time.time)
		{
			currentInput = InputAction.DragRight;
		}
	}

	public bool IsActive {
		get {
			return isActive;
		}

		set {
			isActive = value;
		}
	}

	public static InputAction CurrentInput {
		get {
			return _Instance.currentInput;
		}

		set {
			_Instance.currentInput = value;
		}
	}
}

