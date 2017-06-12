using UnityEngine;
using System.Collections;
using System;

public class ApplyingSlowMotion : MonoBehaviour {

	public	string				identifier				= "";		// Use to identify the slow motion
	public	float				delay					= 1;		// Delay to start Slow Motion
	public	float				desiredFreezeDuration	= 5;		// Duration in seconds of the slow motion
	public	float				desiredTimeScale		= 0.5f;		// Desired game speed 0 stops game, 1 full speed
	public	float				desiredEndTimeScale		= 1;		// Desired game speed when slow motion ends 0 stops game, 1 full speed
	public	Action				callback				= null;		// Action To execute when slow motion ends

	void Start () {
		// To Call Slow Motion Just Add
		//SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale);

		// Or
		//SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, () => Debug.Log("Callback"));

		// Or
		SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, delay);

		// Or
		//SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, "Test");

		// Or
		//SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, () => Debug.Log("Callback"), delay);

		// Or
		//SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, () => Debug.Log("Callback"), delay, desiredEndTimeScale);
	}
}
