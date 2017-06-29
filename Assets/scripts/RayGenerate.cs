using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayGenerate : MonoBehaviour
{
    public GameObject rocket;
    public GameObject stone;
    private float destroyTime = 1.0f;
   // public GameObject blast;
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
        switch (animIndex)
        {
            case 0:
                generateRay();
                break;
            case 1:
                throwStone();
                break;

            case 2:
                throwRocket();
                break;

        }
    }
    public void throwRocket()
    {
        hitButton.interactable = false;
        GameObject rk = Instantiate(rocket, transform.position, transform.parent.rotation) as GameObject;

        Destroy(rk, 1.0f);
        // iTween.MoveTo(rk, movePos, 2.0f);

    }

    public void generateRay()
    {
        // fired_anim_Hash = Animator.StringToHash("fired");
        GameObject fr = Instantiate(fireRibbon, transform.position, transform.rotation) as GameObject;

        if (fireRibbon != null)
        {
            Destroy(fr, 1.0f);
        }
        hitButton.interactable = false;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 50f))
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
    public void throwStone()
    {
        hitButton.interactable = false;
        playerAnimator.Play("throw");
        GameObject st = Instantiate(stone, transform.position, transform.parent.rotation) as GameObject;
        Destroy(st, 1.0f);


    }

}
