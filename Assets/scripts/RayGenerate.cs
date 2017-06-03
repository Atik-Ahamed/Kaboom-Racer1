using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayGenerate : MonoBehaviour
{
    private static int animIndex;
    public Button hitButton;
    AudioSource shotGunSound;
    Animator anmtr;
    public Animator playerAnimator;
    int fired_anim_Hash;
    RaycastHit hit;
    public static void setAnimIndex(int index) { animIndex = index; }
    public void hitAnim()
    {
        Debug.Log("Received Index : " + animIndex);
        switch (animIndex)
        {
            case 0 :
                generateRay();
                break;
            case 1:
                throwStone();
                break;
        }
    }
    
   public void generateRay()
    {
       // fired_anim_Hash = Animator.StringToHash("fired");
        
        hitButton.interactable = false;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 20f))
        {
            if (hit.collider.gameObject.tag == "enemy")
            {
                anmtr = hit.collider.gameObject.GetComponentInChildren<Animator>();
                anmtr.SetBool("fired", true);
                //Debug.Log(hit.collider.gameObject);
                hit.collider.gameObject.GetComponent<Collider>().isTrigger = true;
                Destroy(hit.collider.gameObject,2.0f);

            }
        }
        shotGunSound = this.GetComponent<AudioSource>();
        shotGunSound.Play();


    }
    public void throwStone()
    {
        hitButton.interactable = false;
        playerAnimator.Play("throw");
        if (Physics.Raycast(transform.position, transform.forward, out hit, 20f))
        {
            if (hit.collider.gameObject.tag == "enemy")
            {
                anmtr = hit.collider.gameObject.GetComponentInChildren<Animator>();
                anmtr.SetBool("fired", true);
                //Debug.Log(hit.collider.gameObject);
                hit.collider.gameObject.GetComponent<Collider>().isTrigger = true;
                Destroy(hit.collider.gameObject, 2.0f);

            }
        }

    }
}
