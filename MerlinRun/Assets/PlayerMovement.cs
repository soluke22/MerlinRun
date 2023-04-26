using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forSpeed = 7.5f;
    [SerializeField] float horSpeed = 3.0f;
    float leftLane = -3f;
    float centerLane = 1;
    float rightLane = 4f;
    float minSwipeDistance = 50f;
    float maxSwipeAngle = 45f;
    bool isMoving = false;

    Vector2 startPos;
    private CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        Debug.Log("The player's starting position is " + cc.transform.position);
    }

    // Update is called once per frame
void Update()
{
    Vector3 forwardMovement = transform.forward * forSpeed * Time.deltaTime;

        // Detect touch input
    if (Input.touches.Length > 0)
    {
        Touch touch = Input.touches[0];

        // Detect swipe gesture
        if (touch.phase == TouchPhase.Began)
        {
            startPos = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            Vector2 swipeDelta = touch.position - startPos;
            if (swipeDelta.magnitude > minSwipeDistance)
            {
                // Swipe was long enough, now check if it was a horizontal swipe
                float swipeAngle = Vector2.Angle(swipeDelta, Vector2.right);
                if (swipeAngle < maxSwipeAngle)
                {
                    // Swipe was mostly horizontal, now check if it was left or right
                    if (swipeDelta.x > 0)
                    {
                        // Swipe to the right
                        if (cc.transform.position.x < centerLane && !isMoving)
                        {
                             StartCoroutine(MoveToLaneCoroutine(centerLane));
                        }
                        else if (cc.transform.position.x == centerLane && !isMoving)
                        {
                                StartCoroutine(MoveToLaneCoroutine(rightLane));
                        }
                    }
                    else
                    {
                        if (cc.transform.position.x == centerLane && !isMoving)
                        {
                            StartCoroutine(MoveToLaneCoroutine(leftLane));
                        }
                        else if (cc.transform.position.x > centerLane && !isMoving)
                        {
                            StartCoroutine(MoveToLaneCoroutine(centerLane));
                        }
                    }
                }
            }
        }
    }
    else {
    if (Input.GetKeyDown(KeyCode.D))
    {
        if (cc.transform.position.x < centerLane && !isMoving)
        {
            StartCoroutine(MoveToLaneCoroutine(centerLane));
        }
        else if (cc.transform.position.x == centerLane && !isMoving)
        {
            StartCoroutine(MoveToLaneCoroutine(rightLane));
        }
    }
    else if (Input.GetKeyDown(KeyCode.A))
    {
        if (cc.transform.position.x == centerLane && !isMoving)
        {
            StartCoroutine(MoveToLaneCoroutine(leftLane));
        }
        else if (cc.transform.position.x > centerLane && !isMoving)
        {
            StartCoroutine(MoveToLaneCoroutine(centerLane));
        }
    }
    }
    
    cc.Move(forwardMovement);

}

IEnumerator MoveToLaneCoroutine(float laneX)
{
    Debug.Log("The player is starting at " + cc.transform.position);
    isMoving = true;
    float t = 0f;
    Vector3 startPos = cc.transform.position;
    Vector3 endPos = new Vector3(laneX, startPos.y, startPos.z);

    while (t < .5f)
    {
        Debug.Log("Player is moving to " + endPos);
        t += Time.deltaTime * horSpeed;
        Vector3 sidewaysMovement = Vector3.Lerp(startPos, endPos, Mathf.Clamp01(t)) - cc.transform.position;
        Vector3 forwardMovement = transform.forward * forSpeed * Time.deltaTime;
        cc.Move(sidewaysMovement + forwardMovement);
        yield return null;
    }

    cc.Move(endPos - cc.transform.position);
    isMoving = false;
}
}

