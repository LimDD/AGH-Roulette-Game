namespace MultiTouchInput {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Finger {


		//Positions.
		Vector2 startPressPosition; //Will be used for calculating swipe.
		Vector2 currentPosition;
		Vector2 pinchPosition; //Will be start press position to begin with, but will be updated as you pinch.
		int fingerIndex;
		public InputAction action; //Current action of this finger.

		public Finger(Touch touch, int index) {
			pinchPosition = touch.position;
			startPressPosition = touch.position;
			fingerIndex = index;
		}

		public void UpdatePinchPosition() {
			pinchPosition = Input.GetTouch(fingerIndex).position;
		}

		Vector2 GetFingerPosition(int fingerIndex) {
			return Input.GetTouch(fingerIndex).position;
		}

		public bool IsMoving {

			get {
				return Input.GetTouch(fingerIndex).phase == TouchPhase.Moved;
			}

		}

		public Vector2 DeltaPosition {

			get {
				return GetFingerPosition(fingerIndex) - startPressPosition;
			}
		}

		public Vector2 CurrentPosition {
			get {
				return GetFingerPosition(fingerIndex);
			}

			set {
				currentPosition = value;
			}
		}


	}

}
