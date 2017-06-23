using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayGenerate : MonoBehaviour
{
    public GameObject rocket;
    private float destroyTime = 1.0f;
    public GameObject blast;
    private static int animIndex;
    public Button hitButton;
    public GameObject fireRibbon;
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
            case 2:
                jumpFight();
                break;
            case 3:
                throwRocket();
                break;

        }
    }
    public void throwRocket()
    {
        hitButton.interactable = false;
        GameObject rk = Instantiate(rocket, transform.position, transform.parent.rotation)as GameObject;
       
        Destroy(rk, 1.0f);
       // iTween.MoveTo(rk, movePos, 2.0f);

    }
    
   public void generateRay()
    {
        // fired_anim_Hash = Animator.StringToHash("fired");
        GameObject fr=Instantiate(fireRibbon, transform.position, transform.rotation) as GameObject;
      
        if (fireRibbon != null)
        {
            Destroy(fr, 1.0f);
        }
        hitButton.interactable = false;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 20f))
        {
            if (hit.collider.gameObject.tag == "enemy")
            {
                GameObject exploison = GameObject.Instantiate(blast,hit.collider.gameObject.transform.position,Quaternion.identity,hit
                    .collider.gameObject.transform) as GameObject;

                anmtr = hit.collider.gameObject.GetComponentInChildren<Animator>();
                anmtr.SetBool("fired", true);
                //Debug.Log(hit.collider.gameObject);
                hit.collider.gameObject.GetComponent<Collider>().isTrigger = true;
                Destroy(hit.collider.gameObject,destroyTime);

            }
        }

       

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
                Destroy(hit.collider.gameObject, destroyTime);

            }
        }

    }
    public void jumpFight()
    {
        hitButton.interactable = false;
        playerAnimator.Play("jumpFight");
        if (Physics.Raycast(transform.position, transform.forward, out hit, 20f))
        {
            if (hit.collider.gameObject.tag == "enemy")
            {
                anmtr = hit.collider.gameObject.GetComponentInChildren<Animator>();
                anmtr.SetBool("fired", true);
                //Debug.Log(hit.collider.gameObject);
                hit.collider.gameObject.GetComponent<Collider>().isTrigger = true;
                Destroy(hit.collider.gameObject, destroyTime);

            }
        }

    }
}
