using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class PlayerMotor : MonoBehaviour
{
    /// //////////////////////////////////////////Game Objects  section start/////////////////////////////////////
    public GameObject resumeButton;
    public AudioClip[] clips;//0-coin //1-death
    private AudioSource audSrc;
    public Text scoreText;
    public GameObject tlePanel;
    public GameObject left, right;
    public Text timer;
    public GameObject mainCycle;
    Rigidbody rb;
    public Button hitBUtton;
    public GameObject torchLight;
    public Transform sun;
    public Text deathText;
    /// //////////////////////////////////////////Game Objects  section end/////////////////////////////////////



    ///////////////////////////////////////Variables section start/////////////////////////////////////////
    private Color iniColor;
    private int score;
    private int gravity;
    private const float RAD_TO_DEG_EUL = 115.6383f;
    private float speed = 110f;
    private float buttonRotation;
    public float minSwipeDist = 50f;
    private float turningSpeed = 70f;
    float yAsixRotation;
    private float jumpForce = 100f;
    private float leftright;
    private float forwardback;
    private int startAnimIndex = 0;
    private int endAnimIndex = 500;
    private float amntTime = 20f;
    private int doorPos = 0;
    private const string tle = "YOU ARE TIME LIMIT EXCEEDED(TLE)";
    private const string died = "YOU DIED";
    private const string paused = "PAUSED";
    /// /////////////////////////////////////////////variables section end/////////////////////////////////



    //////////////getters and setters start///////////////////////////////////////////
    public void setBUttonRotation(float value) { buttonRotation += value; }
    public float getButtonRotaion() { return buttonRotation; }
    //////////////getters and setters end///////////////////////////////////////////



    void Awake()
    {

        iniColor = timer.color;
        score = 0;
        Time.timeScale = 1;
        hitBUtton.interactable = false;
        rb = GetComponent<Rigidbody>();
        //SkinnedMeshRenderer newMesh=mainPlayer.GetComponent<SkinnedMeshRenderer>();
        // newMesh.sharedMesh = meshes[0];
        torchLight.SetActive( false);
        gravity = PlayerPrefs.GetInt("gravity");
        tlePanel.SetActive(false);
        if (gravity == 1)
        {
            left.SetActive(false);
            right.SetActive(false);
        }
        else
        {
            left.SetActive(true);
            right.SetActive(true);
        }
        audSrc = mainCycle.GetComponent<AudioSource>();
        AudioListener.volume = 1.0f;

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            death(2);
        }

        scoreText.text = score.ToString();

        /////////timer setting////////////

        if (amntTime > 0)
        {
            if (amntTime < 5)
            {
                timer.color = Color.red;
            }
            amntTime -= Time.fixedDeltaTime;
            timer.text = amntTime.ToString("F");
        }
        if (amntTime <= 0 && transform.position.z < doorPos)
        {


            death(0);
        }
        if (transform.position.z > doorPos)
        {
            doorPos += 67;
            amntTime = 20;
            timer.color =iniColor;
            score += 5;
        }
        ////////////      timer setting end////////////////////


        rb.AddForce(transform.forward * speed * Time.deltaTime);           //forward movement speed

        /////////clamping z and y rotation///////////
        if ((RAD_TO_DEG_EUL * transform.rotation.z) >= 30) { transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y * Mathf.Rad2Deg, 31f)); }
        if ((RAD_TO_DEG_EUL * transform.rotation.z) <= -30) { transform.rotation = Quaternion.Euler(0f, transform.rotation.y * RAD_TO_DEG_EUL, -31f); }
        if ((RAD_TO_DEG_EUL * transform.rotation.y) >= 90) { transform.rotation = Quaternion.Euler(0f, 91f, transform.rotation.z * RAD_TO_DEG_EUL); }
        if ((RAD_TO_DEG_EUL * transform.rotation.y) <= -90) { transform.rotation = Quaternion.Euler(0f, -91f, transform.rotation.z * RAD_TO_DEG_EUL); }

        mainCycle.transform.rotation = Quaternion.Euler(0f, transform.rotation.y * 180, -30 * buttonRotation);
        //Debug.Log("maincyclerotation :" + mainCycle.transform.rotation.z);
       // Debug.Log("Button : " + buttonRotation);
        /////////////clampping done z and y rotation////////////////

        ////////////////////torchLigt Section/////
        if (sun.childCount == 2) { torchLight.SetActive(true); }
        else if (sun.childCount == 1) { torchLight.SetActive(false); }


        if (gravity == 1)
        {

            if (Input.acceleration.x > 0.19)
            {

                if (buttonRotation <= 1)
                {
                    buttonRotation += .09f;
                }
                else
                {

                    if (buttonRotation >= 0)
                        buttonRotation -= .09f;
                }
                turnRight();
            }
            else if (Input.acceleration.x < -.19)
            {

                if (buttonRotation >= -1)
                {
                    buttonRotation -= .09f;
                }


                else
                {
                    if (buttonRotation <= 0)
                        buttonRotation += .09f;
                }
                turnLeft();
            }


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

        if (col.gameObject.tag == "enemy")
        {
            death(1);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "weapon")
        {
            hitBUtton.interactable = true;
            int aniIndex = Random.Range(startAnimIndex, endAnimIndex);
            RayGenerate.setAnimIndex(aniIndex % 3);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
            score++;
            audSrc.clip = clips[0];
            audSrc.Play();

        }
    }
    private void death(int cond)
    {
        AudioListener.volume = Mathf.Lerp(1, .2f, 7);

        if (cond == 0)
        {
            
            resumeButton.SetActive(false);
            deathText.text = tle;
            tlePanel.SetActive(true);
            if (score > PlayerPrefs.GetInt("HighScore"))
                PlayerPrefs.SetInt("HighScore", score);
            Time.timeScale = 0;
            audSrc.clip = clips[1];
            audSrc.Play();
        }
        else if (cond == 1)
        {
            resumeButton.SetActive(false);
           
            deathText.text = died;
            tlePanel.SetActive(true);
            if (score > PlayerPrefs.GetInt("HighScore"))
                PlayerPrefs.SetInt("HighScore", score);
            Time.timeScale = 0;
            audSrc.clip = clips[1];
            audSrc.Play();

        }
        else if (cond == 2)
        {
           
            tlePanel.SetActive(true);
            resumeButton.SetActive(true);
            deathText.text = paused;
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
        }
       
    }
}

