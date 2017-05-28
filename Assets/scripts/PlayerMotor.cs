using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class PlayerMotor : MonoBehaviour
{
  /// //////////////////////////////////////////Game Objects  section start/////////////////////////////////////
    public GameObject mainCycle;
    //public WheelCollider front1;
    // public WheelCollider front2;
    private WheelCollider back;
    //public GameObject front;
    //public GameObject frontToRotatePoint;
    Rigidbody rb;
    public Button hitBUtton;
    /// //////////////////////////////////////////Game Objects  section end/////////////////////////////////////



  ///////////////////////////////////////Variables section start/////////////////////////////////////////
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
    /// /////////////////////////////////////////////variables section end/////////////////////////////////



   //////////////getters and setters start///////////////////////////////////////////
    public void setBUttonRotation(float value) { buttonRotation += value;}
    public float getButtonRotaion() { return buttonRotation; }
    //////////////getters and setters end///////////////////////////////////////////



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hitBUtton.interactable = false;

    }

    void FixedUpdate()
    {
      //  Debug.Log("Button rotaion" + buttonRotation);

        //Debug.Log(front1.steerAngle);
       // leftright = Input.acceleration.x != 0 ? Input.acceleration.x : Input.GetAxis("Horizontal");
        //front1.motorTorque = speed;
        // front2.motorTorque = speed;
        //front1.steerAngle = turningSpeed * leftright;
        // front2.steerAngle = turningSpeed * leftright;

        yAsixRotation = transform.rotation.y;

        rb.AddForce(transform.forward * speed * Time.deltaTime);

        transform.Rotate(transform.up, turningSpeed * Time.deltaTime * leftright);
        //Debug.Log(yAsixRotation);

        mainCycle.transform.rotation = Quaternion.Euler(0f, transform.rotation.y * 180, -30 * leftright);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * speed*10000);
        }

        // this.transform.Rotate(Vector3.up, leftright*Time.deltaTime*turningSpeed);
        //mainCycle.transform.Rotate(mainCycle. transform.forward, turningSpeed *Time.deltaTime* leftright);
        //front.transform.Rotate(-frontToRotatePoint.transform.up, 2 * leftright);

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
        //Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "weapon")
        {
            hitBUtton.interactable = true;
            //Debug.Log(col.gameObject);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "enemy")
        {
            Menus.Restart();
        }
    }
}

