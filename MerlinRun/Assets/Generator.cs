using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Generator : MonoBehaviour
{
    public GameObject platformShape;
    public GameObject enemySpawn;
    public GameObject player; 
    private Vector3 platformStartPoint;
    private Vector3 enemySpawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformShape.transform.position;
        enemySpawnPoint = enemySpawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > platformStartPoint.z +20 )
        {
            transform.position = new Vector3(platformShape.transform.position.x, platformShape.transform.position.y, platformShape.transform.position.z + 40);
            platformStartPoint = transform.position;
            GameObject oldPlatform = platformShape;
            GameObject newPlatform = Instantiate(platformShape, transform.position, transform.rotation);
            platformShape = newPlatform;
            Destroy(oldPlatform);

        }
        if(player.transform.position.z > enemySpawnPoint.z+30)
        {
            transform.position = new Vector3(enemySpawn.transform.position.x, enemySpawn.transform.position.y, enemySpawn.transform.position.z + 60);
            enemySpawnPoint = transform.position;
            GameObject oldEnemy = enemySpawn;
            GameObject newEnemy = Instantiate(enemySpawn, transform.position, transform.rotation);
            enemySpawn = newEnemy;
            Destroy(oldEnemy);
        }
    }
}
