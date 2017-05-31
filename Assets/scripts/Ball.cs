using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	
   void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Touched");
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("TouchedWithTrigger");
    }
}
