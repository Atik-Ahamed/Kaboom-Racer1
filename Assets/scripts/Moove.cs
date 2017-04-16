using UnityEngine;
using System.Collections;

public class Moove : MonoBehaviour
{
    private float speed = 5f;
    private float jumpForce = 500f;
    private float leftright;
    private float forwardback; //up down
    public GameObject mainCycle;
    public GameObject fTire;
    public GameObject bTire;
    public GameObject padal;
    public GameObject padal1;
    public GameObject padalCenter;
    public GameObject padalCenter1;
    public GameObject boole1;
    public GameObject boole2;
    Rigidbody rb;
    CharacterController cr;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        cr = GetComponent<CharacterController>();
    }

    void Update()
    {
        leftright = Input.GetAxis("Horizontal");
        forwardback = Input.GetAxis("Vertical");

        // this.transform.position += new Vector3(-leftright, 0, -forwardback) * Time.deltaTime * speed;
        // rb.AddForce(-Vector3.forward*200);
        cr.Move(new Vector3(leftright,0,forwardback) * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {

           // rb.AddForce(Vector3.up * jumpForce);
        }
       // mainCycle.transform.Rotate(0f, 0f, leftright, relativeTo: Space.Self);
        this.transform.Rotate(Vector3.up, leftright);
        if (leftright == 0)
        {
            // Vector3 dest = new Vector3(0, 0, 0);
            // transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, dest, Time.deltaTime);
            while (transform.rotation != Quaternion.identity)
            {
                mainCycle.transform.Rotate(Vector3.forward, 1f);

            }

        }
       // fTire.transform.Rotate(Vector3.right, -forwardback * speed);
       // bTire.transform.Rotate(Vector3.right, -forwardback * speed);
        //padal.transform.RotateAround(padalCenter.transform.position, Vector3.right, -forwardback * speed);
        //padal1.transform.RotateAround(padalCenter1.transform.position, Vector3.right, -forwardback * speed);
        //boole1.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //boole2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);



    }
}
