using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public AttackType weakness;
    AttackType playerAttack;
    public AudioSource enemySound;
    // Start is called before the first frame update
    void Start()
    {
        enemySound= transform.GetChild(1).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        /*else
        {
            Time.timeScale = 0f;
        }*/
    }


    public void CheckAttack()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().GetAttack();
        if (playerAttack == weakness)
        {
            Debug.Log("Enemy Hit!");
            Destroy(gameObject);
            GameObject.Find("AttackWallHitBox").SetActive(false);
        }
        else
        {
            enemySound.Play();
        }
    }
}
