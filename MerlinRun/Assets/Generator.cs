using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Generator : MonoBehaviour
{
    public GameObject platformShape;
    public GameObject player; 
    private Vector3 platformStartPoint;
    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformShape.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > platformStartPoint.z)
        {
            transform.position = new Vector3(platformShape.transform.position.x, platformShape.transform.position.y, platformShape.transform.position.z + 70);
            platformStartPoint = transform.position;
            GameObject oldPlatform = platformShape;
            GameObject newPlatform = Instantiate(platformShape, transform.position, transform.rotation);
            platformShape = newPlatform;
            Destroy(oldPlatform);

        }
    }
}
