using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public AttackType weakness;
    AttackType playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerAttack = GameObject.Find("PlayerShell").GetComponent<PlayerAttack>().GetAttack();
        if (playerAttack == weakness)
        {
            gameObject.SetActive(false);
        }
    }
}
