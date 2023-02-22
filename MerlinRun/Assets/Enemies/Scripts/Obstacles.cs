using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Enemy = GameObject.Instantiate(Resources.Load<GameObject>("Assets/Enemies/Resources/Enemy"));
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        GameObject Enemy = Instantiate(Resources.Load("Obstacle", typeof(GameObject))) as GameObject;
        Enemy.transform.position = gameObject.transform.GetChild(Random.Range(0, 2)).transform.position;
        Enemy.transform.position = new Vector3(Enemy.transform.position.x, Enemy.transform.position.y + 0.5f, Enemy.transform.position.z);

        Enemy.gameObject.GetComponent<Enemy>().weakness = (AttackType)Random.Range(1, 4);
        Debug.Log(Enemy.gameObject.GetComponent<Enemy>().weakness);
    }
}
