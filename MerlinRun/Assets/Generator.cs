using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Generator : MonoBehaviour
{
    public List<GameObject> Plane;
    public List<GameObject> Spawner;
    public GameObject platformShape;
    public GameObject enemySpawn;
    public GameObject player; 
    private Vector3 platformStartPoint;
    private Vector3 enemySpawnPoint;
    private Queue<GameObject> platform;
    private Queue<GameObject> enemies;
    private int newPlatformSpace = 230;
    private int newEnemySpace = 230;
    private int platformSpace = 270;
    private int enemySpace = 60;
    
    // Start is called before the first frame update
    void Start()
    {
        platform.Enqueue(Plane[0]);
        platform.Enqueue(Plane[1]);
        platform.Enqueue(Plane[2]);
        platform.Enqueue(Plane[3]);
        platform.Enqueue(Plane[4]);
        enemies.Enqueue(Spawner[0]);
        enemies.Enqueue(Spawner[1]);
        enemies.Enqueue(Spawner[2]);
        enemies.Enqueue(Spawner[3]);
        enemies.Enqueue(Spawner[4]);
        platformStartPoint = platformShape.transform.position;
        enemySpawnPoint = enemySpawn.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > platformStartPoint.z + newPlatformSpace )
        {
            newPlatformSpace += newPlatformSpace;
            transform.position = new Vector3(platformShape.transform.position.x, platformShape.transform.position.y, platformShape.transform.position.z + platformSpace);
            GameObject newPlatform = Instantiate(platformShape, transform.position, transform.rotation);
            platform.Enqueue(platformShape);
            platformStartPoint = transform.position;
            platformShape = newPlatform;
            platform.Dequeue();

        }
        if(player.transform.position.z > enemySpawnPoint.z + newEnemySpace)
        {
            newEnemySpace += newEnemySpace;
            transform.position = new Vector3(enemySpawn.transform.position.x, enemySpawn.transform.position.y, enemySpawn.transform.position.z + enemySpace);
            GameObject newEnemy = Instantiate(enemySpawn, transform.position, transform.rotation);
            enemies.Enqueue(enemySpawn);
            enemySpawnPoint = transform.position;
            enemySpawn = newEnemy;
            enemies.Dequeue();
        }
    }
}
