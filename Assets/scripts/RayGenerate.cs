using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayGenerate : MonoBehaviour
{
    public Button hitButton;
    AudioSource shotGunSound;
    public void generateRay()
    {
        shotGunSound = this.GetComponent<AudioSource>();
        shotGunSound.Play();
        RaycastHit hit;
        hitButton.interactable = false;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
        {
            if (hit.collider.gameObject.tag == "enemy")
            {
                //Debug.Log(hit.collider.gameObject);
                Destroy(hit.collider.gameObject);
            }
        }
       // Debug.DrawRay(transform.position, transform.forward, Color.green);
        
        
    }
}
