using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forSpeed = 5.0f;
    [SerializeField] float horSpeed = 5.0f;
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
        Vector3 right = transform.right * horizontal * horSpeed * Time.deltaTime;
        Vector3 forward = transform.forward * forSpeed * Time.deltaTime;

        cc.Move(forward + right);
        }
	   
    }
}
