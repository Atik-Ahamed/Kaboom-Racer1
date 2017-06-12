using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SlowMotionController : SingletonMonoBehaviour<SlowMotionController> {

	[System.Serializable]
	private class SlowMotionClass
	{
		public	string				identifier				= "";
		public	float				delay					= 0;
		public	float				desiredFreezeDuration	= 0;
		public	float				desiredTimeScale		= 0;
		public	float				desiredEndTimeScale		= 0;

		public	Action				callback				= null;

		public SlowMotionClass(float pDesiredFreezeDuration = 0, float pDesiredTimeScale = 0, string pIdentifier = "", Action pCallback = null ,float pDelay = 0, float pDesiredEndTimeScale = 1){
			this.identifier				= pIdentifier;
			this.delay					= pDelay;
			this.desiredFreezeDuration 	= pDesiredFreezeDuration;
			this.desiredTimeScale 		= pDesiredTimeScale;
			this.desiredEndTimeScale	= pDesiredEndTimeScale;
			this.callback				= pCallback;
		}
	}

	static 	private	SlowMotionController 	that;
	static	private	bool					canSlowMotion		= true;
	static	private	List<SlowMotionClass>	slowMotionList;

					void 	Awake () {
		that			= this;
		slowMotionList 	= new List<SlowMotionClass> ();
	}

	static	private 	void		TestNextSlowMotion	(){
		if (canSlowMotion && slowMotionList.Count > 0) {
			canSlowMotion = false;

			if(slowMotionList[0].delay == 0){
				that.InitSlowMotion();
			}else{
				that.Invoke("InitSlowMotion", slowMotionList[0].delay);
			}
		}
	}
	
	private		void		InitSlowMotion		(){
		StartCoroutine ("SlowMotion");
	}

	//public		UILabel stateLabel;
	private		void		FinishSlowMotion	(){
		if (slowMotionList [0].callback != null) {
			slowMotionList [0].callback ();
		}
		slowMotionList.RemoveAt (0);

		canSlowMotion = true;
		TestNextSlowMotion ();
	}

	private		IEnumerator	SlowMotion			(){
		SlowMotionClass firstSlowMotion = slowMotionList [0];
		
		float startOfFreeze = Time.realtimeSinceStartup + firstSlowMotion.desiredFreezeDuration;
		Time.timeScale 		= firstSlowMotion.desiredTimeScale;
		
		while (startOfFreeze >= Time.realtimeSinceStartup)
		{
			yield return 0;
		}
		
		if(Time.timeScale == firstSlowMotion.desiredTimeScale){
			Time.timeScale = firstSlowMotion.desiredEndTimeScale;
		}
		
		FinishSlowMotion ();
		StopCoroutine("SlowMotion");
	}

	#region CONSTRUTORS
	/// <summary>
	/// Add the slow motion to the List.
	/// </summary>
	/// <param name="pDesiredFreezeDuration">Time in seconds that Slow Motion will be applied. 1f = 1seg, 0.5f = 1/2seg.</param>
	/// <param name="pDesiredTimeScale">Desired speed for Time.Scale. 0f stops time, 1 normal speed.</param>
	static	public		void 		AddSlowMotion		(float pDesiredFreezeDuration, float pDesiredTimeScale){
		slowMotionList.Add(new SlowMotionClass(pDesiredFreezeDuration, pDesiredTimeScale));
		TestNextSlowMotion();
	}

	/// <summary>
	/// Add the slow motion to the List.
	/// </summary>
	/// <param name="pDesiredFreezeDuration">Time in seconds that Slow Motion will be applied. 1f = 1seg, 0.5f = 1/2seg.</param>
	/// <param name="pDesiredTimeScale">Desired speed for Time.Scale. 0f stops time, 1 normal speed.</param>
	/// /// <param name="pIdentifier">Use to give a name to the SlowMotion.</param>
	static	public		void 		AddSlowMotion		(float pDesiredFreezeDuration, float pDesiredTimeScale, string pIdentifier){
		slowMotionList.Add(new SlowMotionClass(pDesiredFreezeDuration, pDesiredTimeScale, pIdentifier));
		TestNextSlowMotion();
	}
	
	/// <summary>
	/// Add the slow motion to the List.
	/// </summary>
	/// <param name="pDesiredFreezeDuration">Time in seconds that Slow Motion will be applied. 1f = 1seg, 0.5f = 1/2seg.</param>
	/// <param name="pDesiredTimeScale">Desired speed for Time.Scale. 0f stops time, 1 normal speed.</param>
	/// <param name="pDelay">The delay in seconds to start the Slow Motion. [Default = 0]</param>
	static	public		void 		AddSlowMotion		(float pDesiredFreezeDuration, float pDesiredTimeScale, float pDelay){
		slowMotionList.Add(new SlowMotionClass(pDesiredFreezeDuration, pDesiredTimeScale, "", null, pDelay));
		TestNextSlowMotion();
	}

	/// <summary>
	/// Add the slow motion to the List.
	/// </summary>
	/// <param name="pDesiredFreezeDuration">Time in seconds that Slow Motion will be applied. 1f = 1seg, 0.5f = 1/2seg.</param>
	/// <param name="pDesiredTimeScale">Desired speed for Time.Scale. 0f stops time, 1 normal speed.</param>
	/// <param name="pCallback">Action to execute after Slow Motion</param>
	static	public		void 		AddSlowMotion		(float pDesiredFreezeDuration, float pDesiredTimeScale, Action pCallback){
		slowMotionList.Add(new SlowMotionClass(pDesiredFreezeDuration, pDesiredTimeScale, "", pCallback));
		TestNextSlowMotion();
	}

	/// <summary>
	/// Add the slow motion to the List.
	/// </summary>
	/// <param name="pDesiredFreezeDuration">Time in seconds that Slow Motion will be applied. 1f = 1seg, 0.5f = 1/2seg.</param>
	/// <param name="pDesiredTimeScale">Desired speed for Time.Scale. 0f stops time, 1 normal speed.</param>
	/// <param name="pCallback">Action to execute after Slow Motion</param>
	/// <param name="pDelay">The delay in seconds to start the Slow Motion. [Default = 0]</param>
	static	public		void 		AddSlowMotion		(float pDesiredFreezeDuration, float pDesiredTimeScale, Action pCallback, float pDelay){
		slowMotionList.Add(new SlowMotionClass(pDesiredFreezeDuration, pDesiredTimeScale, "", pCallback, pDelay));
		TestNextSlowMotion();
	}

	/// <summary>
	/// Add the slow motion to the List.
	/// </summary>
	/// <param name="pDesiredFreezeDuration">Time in seconds that Slow Motion will be applied. 1f = 1seg, 0.5f = 1/2seg.</param>
	/// <param name="pDesiredTimeScale">Desired speed for Time.Scale. 0f stops time, 1 normal speed.</param>
	/// <param name="pCallback">Action to execute after Slow Motion</param>
	/// <param name="pDelay">The delay in seconds to start the Slow Motion. [Default = 0]</param>
	/// <param name="pDesiredEndTimeScale">Desired speed for Time.Scale after the end of the Slow Motion.</param>
	static	public		void 		AddSlowMotion		(float pDesiredFreezeDuration, float pDesiredTimeScale, Action pCallback, float pDelay, float pDesiredEndTimeScale){
		slowMotionList.Add(new SlowMotionClass(pDesiredFreezeDuration, pDesiredTimeScale, "", pCallback, pDelay, pDesiredEndTimeScale));
		TestNextSlowMotion();
	}
	#endregion

	/*
	static	public		void		CancelSlowMotion	(string pIdentifier){
		for (int i = 0; i < slowMotionList.Count; i++) {
			if(slowMotionList[i].identifier == pIdentifier){
				if(slowMotionList[i] != null){
					slowMotionList.RemoveAt(i);
				}
			}
		}
	}
	*/
}
