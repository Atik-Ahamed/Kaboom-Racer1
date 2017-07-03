using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour
{
    
    Animator anmtr;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * 1700f * Time.deltaTime);

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            PlayerMotor.IncScore(5);
            anmtr = col.gameObject.GetComponentInChildren<Animator>();
            anmtr.SetBool("fired", true);
            //Debug.Log(hit.collider.gameObject);
            col.gameObject.GetComponent<Collider>().isTrigger = true;
            Destroy(col.gameObject, 1.0f);


        }
    }

}
