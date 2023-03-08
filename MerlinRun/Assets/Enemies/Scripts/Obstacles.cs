using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Enemy = GameObject.Instantiate(Resources.Load<GameObject>("Assets/Enemies/Resources/Enemy"));
        Destroy(GameObject.FindGameObjectWithTag("Obstacle"));
            
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        Debug.Log("Obstacle Spawn");
        GameObject Obstacle = Instantiate(Resources.Load("Obstacle", typeof(GameObject))) as GameObject;
        Obstacle.transform.position = gameObject.transform.GetChild(Random.Range(0, 2)).transform.position;
        Obstacle.transform.position = new Vector3(Obstacle.transform.position.x, Obstacle.transform.position.y + 0.5f, Obstacle.transform.position.z);
                
    }
}
