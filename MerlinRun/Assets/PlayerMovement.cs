using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
	    Vector3 right = transform.right * horizontal * speed * Time.deltaTime;
        Vector3 forward = transform.forward * speed * Time.deltaTime;

        cc.Move(forward + right);
    }
}
