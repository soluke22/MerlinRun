using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton_Home : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       GetComponent<Button>().onClick.AddListener(PlayGame); 
    }

    // Update is called once per frame
    void PlayGame()
    {
        SceneManager.LoadScene("Movement");
    }
}
