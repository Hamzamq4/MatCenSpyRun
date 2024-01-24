using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is the primary script for the player's movement in the game. With Touch controls.
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    Vector3 movec = Vector3.zero;
    bool canmove = true;
    int line = 1;
    int targetLine = 1;
    public float speed = 20f; // added variable for speed
    float jumpHeight = 20f; // added variable for jump height
    float jumpDuration = 0.5f; // added variable for jump duration
    float gravity = -50f; // added variable for gravity
    private Animator pAnimator;

    // added variables for speed increase
    public float maxSpeed = 25f;
    public float speedIncreasePerSecond = 0.01f;

    private inputManager inputManager;

    private int trafficLayer;
    private int schoolLayer;
    private GameObject player;

    private void Awake()
    {
        inputManager = GetComponent<inputManager>();
    }
    //Activates swipe functions from "PlayerControls" in the "TouchSetupScripts" folder
    private void OnEnable()
    {
        inputManager.OnSwipeLeft += OnSwipeLeft;
        inputManager.OnSwipeRight += OnSwipeRight;
        inputManager.OnSwipeUp += OnSwipeUp;
    }

    private void OnDisable()
    {
        inputManager.OnSwipeLeft -= OnSwipeLeft;
        inputManager.OnSwipeRight -= OnSwipeRight;
        inputManager.OnSwipeUp -= OnSwipeUp;
    }

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        pAnimator = GetComponent<Animator>();

        trafficLayer = LayerMask.NameToLayer("TrafficTerrain");
        schoolLayer = LayerMask.NameToLayer("SchoolTerrain");
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //Detects alive state from "ScoreManager" script, if player is "dead" it plays death animation. 
        if (!ScoreManager.isPlayerAlive)
        {
            pAnimator.SetTrigger("Death_b");
            return;
        }
        //Following if statements administer the positions of the player on the 3 different lanes on each terrain.
        Vector3 pos = gameObject.transform.position;
        if (!line.Equals(targetLine))
        {
            //left lane is set to -4.1 on the x-axis
            if (targetLine == 0 && pos.x < -4.1)
            {
                gameObject.transform.position = new Vector3(-2, pos.y, pos.z);
                line = targetLine;
                movec.x = 0;
                canmove = true;
            }
            //middle lane is set to 0
            else if (targetLine == 1 && (pos.x > 0 || pos.x < 0))
            {
                if (line == 0 && pos.x > 0)
                {
                    gameObject.transform.position = new Vector3(0, pos.y, pos.z);
                    line = targetLine;
                    movec.x = 0;
                    canmove = true;
                }
                else if (line == 2 && pos.x < 0)
                {
                    gameObject.transform.position = new Vector3(0, pos.y, pos.z);
                    line = targetLine;
                    movec.x = 0;
                    canmove = true;
                }
            }
            //right lane is set to 4.1 on the x-axis
            else if (targetLine == 2 && pos.x > 4.1)
            {
                gameObject.transform.position = new Vector3(2, pos.y, pos.z);
                line = targetLine;
                movec.x = 0;
                canmove = true;
            }
        }

        // added code for continuous movement along the Z axis
        movec.z = speed;

        // added code for gravity
        if (!cc.isGrounded)
        {
            movec.y += gravity * Time.deltaTime;
        }
        cc.Move(movec * Time.deltaTime);

        checkInputs();

        // added code for gradual speed increase, with a maximum speed threshhold of 25 units (listed in beginning of script)
        if (speed < maxSpeed)
        {
            speed += speedIncreasePerSecond * Time.deltaTime;
        }
    }
    //Script for jumping funtionality, that activates when "OnSwipeUp" is called. Resets animation trigger when method is completed. 
    IEnumerator Jump()
    {
        Debug.Log("Jump animation started");
        float timeInAir = 0.0f;
        movec.y = jumpHeight;

        while (timeInAir < jumpDuration)
        {
            timeInAir += Time.deltaTime;
            float percentComplete = timeInAir / jumpDuration;
            movec.y = Mathf.Lerp(jumpHeight, 0, percentComplete);
            yield return null;
        }

        pAnimator.ResetTrigger("Jump_b"); // Reset the Jump_b animation trigger
        movec.y = 0.0f;
    }
    //Makes arrowkeys able to control the character movements as swipes. 
    void checkInputs()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && canmove && line > 0)
        {
            OnSwipeLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && canmove && line < 2)
        {
            OnSwipeRight();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && cc.isGrounded)
        {
            OnSwipeUp();

        }
    }
    // Checks current lane and which lane is possible to switch to.
    private void OnSwipeLeft(){

        if (canmove && line > 0)
        {
            Debug.Log("Left swipe detected"); 
            targetLine--;
            canmove = false;
            movec.x = -15f;
        }   
    }
    // Checks current lane and which lane is possible to switch to.
    private void OnSwipeRight(){

        if (canmove && line < 2)
        {
            Debug.Log("Right swipe detected");
            targetLine++;
            canmove = false;
            movec.x = 15f;
        }
    }
    //Sets jumping animation and method to true. 
    private void OnSwipeUp(){

        if (cc.isGrounded)
        {
            bool isJumping = true;
            if (isJumping)
            {
                //Activates jump animation.
                pAnimator.SetTrigger("Jump_b");
            }

            StartCoroutine(Jump());

            Debug.Log("Up swipe detected");
            return;
        }
    }
}
