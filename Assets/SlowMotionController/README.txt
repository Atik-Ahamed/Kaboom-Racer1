SlowMotionController is easy to use.

Guides to use it.
1 - Create a game object and assign SlowMotionController script on it or use a game object already on scene. You're done!

2 - Now to use it 
		// To Call Slow Motion Just Add
		SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale);

		// Or
		//SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, () => Debug.Log("Callback"));

		// Or
		//SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, delay);

		// Or
		//SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, "Test");

		// Or
		//SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, () => Debug.Log("Callback"), delay);

		// Or
		//SlowMotionController.AddSlowMotion(desiredFreezeDuration, desiredTimeScale, () => Debug.Log("Callback"), delay, desiredEndTimeScale);