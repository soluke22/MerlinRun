using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forSpeed = 7.5f;
    [SerializeField] float horSpeed = 5.0f;
    float leftLane = -3f;
    float centerLane = 1;
    float rightLane = 4f;
    bool isMoving = false;

    Vector3 startPos;
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
    if (Input.GetKeyDown(KeyCode.D))
    {
        if (cc.transform.position.x < centerLane && !isMoving)
        {
            StartCoroutine(MoveToLaneCoroutine(centerLane, forwardMovement));
        }
        else if (cc.transform.position.x == centerLane && !isMoving)
        {
            StartCoroutine(MoveToLaneCoroutine(rightLane, forwardMovement));
        }
    }
    else if (Input.GetKeyDown(KeyCode.A))
    {
        if (cc.transform.position.x == centerLane && !isMoving)
        {
            StartCoroutine(MoveToLaneCoroutine(leftLane, forwardMovement));
        }
        else if (cc.transform.position.x > centerLane && !isMoving)
        {
            StartCoroutine(MoveToLaneCoroutine(centerLane, forwardMovement));
        }
    }
    
    cc.Move(forwardMovement);

}

IEnumerator MoveToLaneCoroutine(float laneX, Vector3 forwardMovement)
{
    isMoving = true;
    float t = 0f;
    Vector3 startPos = cc.transform.position;
    Vector3 endPos = new Vector3(laneX, startPos.y, startPos.z);

    while (t < 2f)
    {
        t += Time.deltaTime * horSpeed;
        cc.Move(forwardMovement + Vector3.Lerp(startPos, endPos, Mathf.Clamp01(t)));
        yield return null;
    }

    isMoving = false;
}
}

