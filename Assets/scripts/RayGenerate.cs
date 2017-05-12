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
        Physics.Raycast(transform.position, transform.forward, out hit);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        hitButton.interactable = false;
        if (hit.collider.gameObject.tag == "enemy")
        {
            Debug.Log(hit.collider.gameObject);
            Destroy(hit.collider.gameObject);
        }
    }
}
