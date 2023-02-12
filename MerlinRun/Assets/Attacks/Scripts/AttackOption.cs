using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOption : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AttackType Option;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    
        if (other.gameObject.name == "PlayerShell")
        {
            other.gameObject.GetComponent<PlayerAttack>().SetAttack(Option);
        }
    }
}
