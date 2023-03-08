using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchMovement : MonoBehaviour
{
    Vector3 startPos;
    float minSwipeDistX, minSwipeDistY;
    private CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        minSwipeDistX = minSwipeDistY = Screen.width / 6;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began){
                startPos = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                var horTouch = touch.position.x - startPos.x; 
                Vector3 right = transform.right * horTouch * Time.deltaTime;
            }
        }
    }
}
