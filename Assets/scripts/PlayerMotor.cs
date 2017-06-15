using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class PlayerMotor : MonoBehaviour
{
    /// //////////////////////////////////////////Game Objects  section start/////////////////////////////////////
    public GameObject weaponEffect;
    // public Mesh[] meshes;
    //public GameObject mainPlayer;
    public GameObject mainCycle;
    //public WheelCollider front1;
    // public WheelCollider front2;
    private WheelCollider back;
    //public GameObject front;
    //public GameObject frontToRotatePoint;
    Rigidbody rb;
    public Button hitBUtton;
    public Light torchLight;
    public Transform sun;
    /// //////////////////////////////////////////Game Objects  section end/////////////////////////////////////



    ///////////////////////////////////////Variables section start/////////////////////////////////////////
    private const float RAD_TO_DEG_EUL = 115.6383f;
    private float speed = 100f;
    private float buttonRotation;
    public float maxTime = 0.5f;
    public float minSwipeDist = 50f;
    private float turningSpeed = 70f;
    float startTime;
    float endTime;
    float swipeDistance;
    float swipeTime;
    float yAsixRotation;
    private float jumpForce = 100f;
    private float leftright;
    private float forwardback;
    Vector3 startPose;
    Vector3 endPose;
    private int startAnimIndex = 0;
    private int endAnimIndex = 500;
    /// /////////////////////////////////////////////variables section end/////////////////////////////////



    //////////////getters and setters start///////////////////////////////////////////
    public void setBUttonRotation(float value) { buttonRotation += value; }
    public float getButtonRotaion() { return buttonRotation; }
    //////////////getters and setters end///////////////////////////////////////////



    void Awake()
    {
        hitBUtton.interactable = false;
        rb = GetComponent<Rigidbody>();
        //SkinnedMeshRenderer newMesh=mainPlayer.GetComponent<SkinnedMeshRenderer>();
        // newMesh.sharedMesh = meshes[0];
        torchLight.enabled = false;

    }

    void FixedUpdate()
    {


        rb.AddForce(transform.forward * speed * Time.deltaTime);           //forward movement speed

        /////////clamping z and y rotation///////////

        // Debug.Log("Rotation z :" + transform.rotation.z);
        //Debug.Log("Rotation y :" + transform.rotation.y);


        if ((RAD_TO_DEG_EUL * transform.rotation.z) >= 30) { transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y * Mathf.Rad2Deg, 31f)); }
        if ((RAD_TO_DEG_EUL * transform.rotation.z) <= -30) { transform.rotation = Quaternion.Euler(0f, transform.rotation.y * RAD_TO_DEG_EUL, -31f); }
        if ((RAD_TO_DEG_EUL * transform.rotation.y) >= 90) { transform.rotation = Quaternion.Euler(0f, 91f, transform.rotation.z * RAD_TO_DEG_EUL); }
        if ((RAD_TO_DEG_EUL * transform.rotation.y) <= -90) { transform.rotation = Quaternion.Euler(0f, -91f, transform.rotation.z * RAD_TO_DEG_EUL); }

        mainCycle.transform.rotation = Quaternion.Euler(0f, transform.rotation.y * 180, -30 * buttonRotation);
        /////////////clampping done z and y rotation////////////////

        ////////////////////torchLigt Section/////
        if (sun.childCount == 2) { torchLight.enabled = true; }
        else if (sun.childCount == 1) { torchLight.enabled = false; }
        // Debug.Log("Sun rotation : " + sun.rotation.x);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * speed * 10000);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPose = touch.position;

            }
            else if (touch.phase == TouchPhase.Ended)
            {

                endTime = Time.time;
                endPose = touch.position;
            }
            swipeDistance = (endPose - startPose).magnitude;
            swipeTime = (endTime - startTime);
            if (swipeTime < maxTime && swipeDistance > minSwipeDist)
            {
                //swipe();
            }
        }


    }
    void swipe()
    {
        Vector2 distance = endPose - startPose;
        if (distance.y < 0)
        {
            rb.AddForce(-transform.forward * speed * 3 * Time.deltaTime);
        }

    }
    public void turnLeft()
    {
        transform.Rotate(transform.up, turningSpeed * Time.deltaTime * -1);
        mainCycle.transform.rotation = Quaternion.Euler(0f, transform.rotation.y * 180, -30 * buttonRotation);


    }
    public void turnRight()
    {

        transform.Rotate(transform.up, turningSpeed * Time.deltaTime);
        mainCycle.transform.rotation = Quaternion.Euler(0f, transform.rotation.y * 180, -30 * buttonRotation);


    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "weapon")
        {
            GameObject wf = GameObject.Instantiate(weaponEffect, col.gameObject.transform.position, Quaternion.identity,transform)as GameObject;
            hitBUtton.interactable = true;
            //here gose the animation index selector randomly and pass it to raygenerator//

            int aniIndex = Random.Range(startAnimIndex, endAnimIndex);
            RayGenerate.setAnimIndex(aniIndex % 3);
            //Debug.Log("Passed index : " + aniIndex);
            //Debug.Log(col.gameObject);
            Destroy(col.gameObject);
            Destroy(wf, 3.0f);
        }
        else if (col.gameObject.tag == "enemy")
        {
            Menus.Restart();
        }
    }
}

