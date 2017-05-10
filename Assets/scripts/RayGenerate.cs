using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayGenerate : MonoBehaviour
{
    public Button hitButton;
    public void generateRay()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        hitButton.interactable = false;
        if (hit.collider.tag == "enemy")
        {
            Debug.Log(hit.collider.gameObject);
            Destroy(hit.collider.gameObject);
        }
    }
}
