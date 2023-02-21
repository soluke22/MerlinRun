using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    float counter;
    public TMP_Text numericalScore;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        numericalScore.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

    if (counter >= 5)
    {
        increaseScore();
        counter = 0;
    }
   
    }

    void increaseScore()
    {
        score = score + 1;
        numericalScore.text = "Score : " + score;
    }
}
