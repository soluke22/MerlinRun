using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWall : MonoBehaviour
{
    AudioSource soundSFX;
    private void Start()
    {
        soundSFX= GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            soundSFX.Play();
            GameManager.instance.UpdateState(GameManager.GameState.Lost);
        }
    }
}
