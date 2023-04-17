using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        //Enemy = GameObject.Instantiate(Resources.Load<GameObject>("Assets/Enemies/Resources/Enemy"));
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        int enemyNum = SetEnemy();
        if (enemyNum == 0)
            enemyNum += 1;
        Debug.Log("EnemySpawn" + enemyNum);
        GameObject Enemy = Instantiate(Resources.Load("Enemy_"+ enemyNum.ToString(), typeof(GameObject))) as GameObject;
        Enemy.transform.position = gameObject.transform.GetChild(Random.Range(0,2)).transform.position;
        Enemy.transform.position = new Vector3(Enemy.transform.position.x, Enemy.transform.position.y + 0.5f, Enemy.transform.position.z);
        
        Enemy.gameObject.GetComponent<Enemy>().weakness = (AttackType)enemyNum;
        Debug.Log("Weakness: " + Enemy.gameObject.GetComponent<Enemy>().weakness);
    }


    int SetEnemy()
    {
        return Random.Range((int)AttackType.none, (int)AttackType.earth + 1);
    }
}
