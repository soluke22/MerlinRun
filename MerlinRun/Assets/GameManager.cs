using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state;

    public static event Action<GameState> OnStateChange;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        UpdateState(GameState.Play);
    }
    public void UpdateState(GameState newState)
    {
        state = newState;
        Debug.Log(state.ToString());
        switch (state)
        {
            case GameState.Play:
                Time.timeScale = 1;
                break;

            case GameState.Lost:
                Debug.Log("You Lose");
                Time.timeScale = 0;
                break;
            
        }

        OnStateChange?.Invoke(newState);
    }
    public enum GameState
    {
        Play, Lost
    }
}
