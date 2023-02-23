using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;  
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject quitButton;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PauseMenu);
        resumeButton.GetComponent<Button>().onClick.AddListener(ResumeGame);
        quitButton.GetComponent<Button>().onClick.AddListener(QuitGame);
    }
    public void PauseMenu() 
    {
        Time.timeScale = 0.0f;
        resumeButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        resumeButton.SetActive(false);
        quitButton.SetActive(false);
    }

    public void QuitGame()
    {

    }
}
