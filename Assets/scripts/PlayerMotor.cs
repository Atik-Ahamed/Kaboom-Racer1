using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour
{

    public float maxTime = 0.5f;
    public float minSwipeDist = 50f;
    private float turningSpeed = 90f;
    float startTime;
    float endTime;
    float swipeDistance;
    float swipeTime;
    Vector3 startPose;
    Vector3 endPose;
    private float speed = 100f;
    private float jumpForce=100f;
    private float leftright;
    private float forwardback; //up down
    public GameObject mainCycle;
    //public GameObject front;
    //public GameObject frontToRotatePoint;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        leftright = Input.acceleration.x;

        // leftright = Input.GetAxis("Horizontal");
       // forwardback = Input.GetAxis("Vertical");

        rb.AddForce(transform.forward * speed * 3 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * speed);
        }

        this.transform.Rotate(Vector3.up, leftright*Time.deltaTime*turningSpeed);

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
                swipe();
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
}
