using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class shipcontrols : MonoBehaviour
{
    public static shipcontrols shipControls;

    private bool engineLock;
    public bool inCombat;
    public int timeSpeedMultiplier;
    public bool timeSpeedUp;

    public float xVel;
    public float yVel;
    public float zVel;
    public Vector3 Velocity;
    public Vector3 trackVel;
    public bool isTracking;

    public float moveSpeed;
    public float RCSspeed;
    public TextMeshProUGUI speedGauge;
    public float velMagCap;

    public float rotSpeed;
    public float slowRot;
    public float maxSpeed;
    public float maxRCSSpeed;
    public Slider ThrustControl;
    private Rigidbody rb;


    void Start()
    {
        shipControls = this;

        //reset speed
        xVel = 0; yVel = 0; zVel = 0;
        rb = GetComponent<Rigidbody>();
        engineLock = false;
        timeSpeedUp = false;

    }
   /* private void Update()
    {

        if (!engineLock)
        {
            //speed up time
            if (Input.GetKey(KeyCode.F))
            {
                Time.timeScale = timeSpeedMultiplier;
                timeSpeedUp = true;
            }
            else 
            {
                Time.timeScale = 1;
                timeSpeedUp = false;
            }
        }
    }*/

    public void EngineEnabled(bool State)
    {
        if(State) { engineLock = false; }
        if(!State) { engineLock = true; }
    }

    void FixedUpdate()
    {
        if (!engineLock)
        {

            Velocity = rb.velocity;

            //acceleration via thruster
            float gauge;
            gauge = ThrustControl.value;
            speedGauge.text = "Thrust Level: " + gauge.ToString();
            if (Velocity.magnitude <= velMagCap)
            {
                rb.AddForce(gameObject.transform.forward * -ThrustControl.value * moveSpeed);
            }


            //all stop
            if (Input.GetKey(KeyCode.Space))
            {
                rb.drag = rb.drag + 0.05f;
                rb.angularDrag = rb.angularDrag + 0.05f;
            }
            if (!Input.GetKey(KeyCode.Space))
            {
                rb.drag = 0;
                rb.angularDrag = 0;
            }

            //Object Lock
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                if (isTracking)
                {
                    rb.velocity = Vector3.MoveTowards(rb.velocity, trackVel, 0.05f);
                }
                else { Debug.Log("No Object Tracked"); }
            }

            //RCS
                //Headway & Astern
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    xVel = RCSspeed;
                    rb.AddForce(gameObject.transform.forward * -xVel);
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    xVel = -RCSspeed;
                    rb.AddForce(gameObject.transform.forward * -xVel);
                }
                else { xVel = 0; }

                //Port and Starboard
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    yVel = RCSspeed;
                    rb.AddForce(gameObject.transform.right * yVel);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    yVel = -RCSspeed;
                    rb.AddForce(gameObject.transform.right * yVel);
                }
                else { yVel = 0; }

                //Heave
                if (Input.GetKey(KeyCode.Q))
                {
                    zVel = RCSspeed;
                    rb.AddForce(gameObject.transform.up * zVel);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    zVel = -RCSspeed;
                    rb.AddForce(gameObject.transform.up * zVel);
                }
                else { zVel = 0; }


            //Rotations
            //Pitch and Yaw
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    gameObject.transform.Rotate(Vector3.right * slowRot);
                }
                else
                {
                    gameObject.transform.Rotate(Vector3.right * rotSpeed);
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    gameObject.transform.Rotate(Vector3.left * slowRot);
                }
                else
                {
                    gameObject.transform.Rotate(Vector3.left * rotSpeed);
                }
            }
            //Port and Starboard
            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    gameObject.transform.Rotate(Vector3.down * slowRot);
                }
                else
                {
                    gameObject.transform.Rotate(Vector3.down * rotSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    gameObject.transform.Rotate(Vector3.up * slowRot);
                }
                else
                {
                    gameObject.transform.Rotate(Vector3.up * rotSpeed);
                }
            }
            //Roll
            if (Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    gameObject.transform.Rotate(Vector3.forward * slowRot);
                }
                else
                {
                    gameObject.transform.Rotate(Vector3.forward * rotSpeed);
                }
            }
            if (Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    gameObject.transform.Rotate(Vector3.back * slowRot);
                }
                else
                {
                    gameObject.transform.Rotate(Vector3.back * rotSpeed);
                }
            }
        }
    }
}
