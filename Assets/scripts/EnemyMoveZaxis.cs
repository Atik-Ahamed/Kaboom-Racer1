using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveZaxis : MonoBehaviour {
    //public float delayTime = .01f;

	void Start () {
        iTween.MoveBy(gameObject, iTween.Hash("z", 4, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", 0, "time",5));
         
    }

   
}
