namespace MultiTouchInput {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// This class will hold necessary information for calculating input.
	/// </summary>
	public class TapInfo {

		public int numFinger; //Number of fingers on the device.
		public float lastTapTime; //Last time the finger tapped the screen. (Similar to mouse button up)
		public float lastPressTime; //Last time the finger touched the screen. (Similar to mouse button down)
		public float lastFingerLeaveTime; //Last time a finger left the screen.
		public int numTap; //Number of taps counted. It resets to 0 after tap threshold.
		public int numFingerLeft; //Number of fingers left the screen
		public int numFingerTapped; //The number of fingers upon successful tap.

		public void Reset() {

			//Resets tap information.
			lastTapTime = 0;
			lastPressTime = 0;
			numTap = 0;
			numFinger = 0;
			numFingerLeft = 0;
			numFingerTapped = 0;

		}

		//Resets tap info only.
		public void ResetTap() {
			lastTapTime = 0;
			numTap = 0;
			numFingerTapped = 0;
		}

		public void ResetFinger() {
			numFinger = 0;
			numFingerLeft = 0;
		}

	}

}
