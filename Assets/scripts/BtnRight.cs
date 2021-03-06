﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class BtnRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player;

                                  

    bool btnRightPressed = false;
    //bool btnLeftPressed = false;

    public void OnPointerUp(PointerEventData eventData)
    {
        // Debug.Log("The mouse click was released");
        btnRightPressed = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("rightPressed");
        btnRightPressed = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (btnRightPressed)
        {

            player.GetComponent<PlayerMotor>().turnRight();
            if (player.GetComponent<PlayerMotor>().getButtonRotaion() <= 1)
            {
                player.GetComponent<PlayerMotor>().setBUttonRotation(.09f);
            }

        }
        else
        {

            if (player.GetComponent<PlayerMotor>().getButtonRotaion() >= 0)
                player.GetComponent<PlayerMotor>().setBUttonRotation(-.09f);
        }
    }

}
