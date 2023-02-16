using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOption : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AttackType Option;
    GameObject[] Enemies;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerAttack>().SetAttack(Option);
        }
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in Enemies)
        {
            enemy.GetComponent<Enemy>().CheckAttack();
        }
        

    }
}
