using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private AttackType AttackChoice = AttackType.none;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public AttackType GetAttack()
    {
        
        return AttackChoice;
    }
    public void SetAttack(AttackType attack)
    {
        AttackChoice = attack;
        Debug.Log(AttackChoice);
    }
}
