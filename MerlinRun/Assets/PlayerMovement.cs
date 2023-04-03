using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forSpeed = 7.5f;
    [SerializeField] float horSpeed = 5.0f;
    [SerializeField] float laneWidth = 3.3f;
    Vector3 startPos;
    private CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //plan is to move the player between 3 lanes, lanes should be about 3.33 units. an idea is to make it when input is given, the player moves to the middle of the lane in that direction. 
        // how will we determine what lane the player is and how they will move tot he right lane?
        // get the x position of the player, if the input is to the right, they move to the right unless at the wall. same for the left
        // if at the wall, they move to the edge and then move back to the center of their current lane

        Vector3 playerPosition = cc.center;
        if(Input.touches.Length > 0) //checks if a finger has touched the screen
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                startPos = Input.touches[0].position;
            }
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                var horTouch = Input.touches[0].position.x - startPos.x; 
                Vector3 right = transform.right * horTouch * Time.deltaTime;
                Vector3 forward = transform.forward * forSpeed * Time.deltaTime;

                cc.Move(forward + right);
            }
        }
        else //if there's no finger, then moves based on the screen moving
        {
        float horizontal = Input.GetAxis("Horizontal");

        
        Vector3 right = transform.right * horizontal * laneWidth * Time.deltaTime;
        Vector3 forward = transform.forward * forSpeed * Time.deltaTime;

        cc.Move(forward + right);
        }
	   
    }
}
