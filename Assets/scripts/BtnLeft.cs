using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class BtnLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player;



   
    bool btnLeftPressed = false;
    void Start () {
		
	}
    public void OnPointerUp(PointerEventData eventData)
    {
       // Debug.Log("The mouse click was released");
        btnLeftPressed = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
       // Debug.Log("rightPressed");
        btnLeftPressed = true;
    }
   
    // Update is called once per frame
    void Update () {
          
        if (btnLeftPressed)
        {

            player.GetComponent<PlayerMotor>().turnLeft();
            if (player.GetComponent<PlayerMotor>().getButtonRotaion() >= -1)
            {
                player.GetComponent<PlayerMotor>().setBUttonRotation(-.09f);
            }

        }
        else
        {
            if(player.GetComponent<PlayerMotor>().getButtonRotaion()<=0)
                player.GetComponent<PlayerMotor>().setBUttonRotation(.09f);
        }
    }
 
}
