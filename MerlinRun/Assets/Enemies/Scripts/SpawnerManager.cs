using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Random.value > 0.5)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else { 
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
            

        if (transform.GetChild(0).gameObject.activeSelf == true)
        {
            transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    
}
