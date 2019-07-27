namespace MultiTouchInput{

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	//Returns input action based on number of fingers involved and action involved.
	public class InputCalculator : MonoBehaviour {

		public static InputAction Calculate(int numFinger, InputAction action) {
			switch (action) {
			case InputAction.Click:
				return Click(numFinger);
			case InputAction.DoubleClick:
				return DoubleClick(numFinger);
			case InputAction.SwipeLeft:
				return SwipeLeft(numFinger);
			case InputAction.SwipeUp:
				return SwipeUp(numFinger);
			case InputAction.SwipeDown:
				return SwipeDown(numFinger);
			case InputAction.SwipeRight:
				return SwipeRight(numFinger);
			case InputAction.DragDown:
				return DragDown(numFinger);
			case InputAction.DragUp:
				return DragUp(numFinger);
			case InputAction.DragLeft:
				return DragLeft(numFinger);
			case InputAction.DragRight:
				return DragRight(numFinger);
			case InputAction.Pressed:
				return Pressed(numFinger);
			}
			//Other inputs detected. return null.
			return InputAction.Null;

		}

		static InputAction Click(int numFinger) {
			switch (numFinger) {
			case 2:
				return InputAction.DoubleFingerTap;
			case 3:
				return InputAction.TrippleFingerTap;
			case 4:
				return InputAction.FourFingerTap;
			case 5:
				return InputAction.FiveFingerTap;
			}
			return InputAction.Null; //The input is invalid.
		}

		static InputAction DoubleClick(int numFinger) {
			switch (numFinger) {
			case 2:
				return InputAction.DoubleFingerDoubleTap;
			case 3:
				return InputAction.TrippleFingerDoubleTap;
			case 4:
				return InputAction.FourFingerDoubleTap;
			case 5:
				return InputAction.FiveFingerDoubleTap;
			}
			return InputAction.Null; //The input is invalid.
		}

		static InputAction SwipeLeft(int numFinger) {
			switch (numFinger) {
			case 2:
				return InputAction.DoubleFingerSwipeLeft;
			case 3:
				return InputAction.TrippleFingerSwipeLeft;
			case 4:
				return InputAction.FourFingerSwipeLeft;
			case 5:
				return InputAction.FiveFingerSwipeLeft;
			}
			return InputAction.Null; //The input is invalid.
		}

		static InputAction SwipeRight(int numFinger) {
			switch (numFinger) {
			case 2:
				return InputAction.DoubleFingerSwipeRight;
			case 3:
				return InputAction.TrippleFingerSwipeRight;
			case 4:
				return InputAction.FourFingerSwipeRight;
			case 5:
				return InputAction.FiveFingerSwipeRight;
			}
			return InputAction.Null; //The input is invalid.
		}

		static InputAction SwipeUp(int numFinger) {
			switch (numFinger) {
			case 2:
				return InputAction.DoubleFingerSwipeUp;
			case 3:
				return InputAction.TrippleFingerSwipeUp;
			case 4:
				return InputAction.FourFingerSwipeUp;
			case 5:
				return InputAction.FiveFingerSwipeUp;
			}
			return InputAction.Null; //The input is invalid.
		}

		static InputAction SwipeDown(int numFinger) {
			switch (numFinger) {
			case 2:
				return InputAction.DoubleFingerSwipeDown;
			case 3:
				return InputAction.TrippleFingerSwipeDown;
			case 4:
				return InputAction.FourFingerSwipeDown;
			case 5:
				return InputAction.FiveFingerSwipeDown;
			}
			return InputAction.Null; //The input is invalid.
		}

		static InputAction DragUp(int numFinger) {
			switch (numFinger) {
			case 2:
				return InputAction.DoubleFingerDragUp;
			case 3:
				return InputAction.TrippleFingerDragUp;
			case 4:
				return InputAction.FourFingerDragUp;
			case 5:
				return InputAction.FiveFingerDragUp;
			}
			return InputAction.Null; //The input is invalid.
		}

		static InputAction DragDown(int numFinger) {
			switch (numFinger) {
			case 2:
				return InputAction.DoubleFingerDragDown;
			case 3:
				return InputAction.TrippleFingerDragDown;
			case 4:
				return InputAction.FourFingerDragDown;
			case 5:
				return InputAction.FiveFingerDragDown;
			}
			return InputAction.Null; //The input is invalid.
		}

		static InputAction DragLeft(int numFinger) {
			switch (numFinger) {
			case 2:
				return InputAction.DoubleFingerDragLeft;
			case 3:
				return InputAction.TrippleFingerDragLeft;
			case 4:
				return InputAction.FourFingerDragLeft;
			case 5:
				return InputAction.FiveFingerDragLeft;
			}
			return InputAction.Null; //The input is invalid.
		}

		static InputAction DragRight(int numFinger) {
			switch (numFinger) {
			case 2:
				return InputAction.DoubleFingerDragRight;
			case 3:
				return InputAction.TrippleFingerDragRight;
			case 4:
				return InputAction.FourFingerDragRight;
			case 5:
				return InputAction.FiveFingerDragRight;
			}
			return InputAction.Null; //The input is invalid.
		}

		static InputAction Pressed(int numFinger) {
			switch (numFinger) {
			case 2:
				return InputAction.DoubleFingerPressed;
			case 3:
				return InputAction.TrippleFingerPressed;
			case 4:
				return InputAction.FourFingerPressed;
			case 5:
				return InputAction.FiveFingerPressed;
			}
			return InputAction.Null; //The input is invalid.
		}
	}

}
