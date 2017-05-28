using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayGenerate : MonoBehaviour
{
    public Button hitButton;
    AudioSource shotGunSound;
    Animator anmtr;
    int fired_anim_Hash;
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
                anmtr = hit.collider.gameObject.GetComponentInChildren<Animator>();
                fired_anim_Hash = Animator.StringToHash("fired");
                anmtr.SetBool(fired_anim_Hash, true);
                //Debug.Log(hit.collider.gameObject);
                hit.collider.gameObject.GetComponent<Collider>().isTrigger = true;
                Destroy(hit.collider.gameObject,2.0f);

            }
        }
       
        
    }
}
