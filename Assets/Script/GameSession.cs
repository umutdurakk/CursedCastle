using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI livestext ;
    [SerializeField] TextMeshProUGUI scoretext;
     void Awake()
    {
        int numGameSessions =FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }


    }
     void Start()
    {
        livestext.text = playerLives.ToString();
        scoretext.text = score.ToString();
    }


    public void ProcessPlayerDeath()
    {
        if (playerLives>1)
        {
            TakeLife(); 
        }
        else
        {
            ResetGameSession();
        }
    }
    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoretext.text = score.ToString();
    }
    public void AddToLife(int pointsToAdd)
    {
        playerLives += pointsToAdd;
        livestext.text = playerLives.ToString();
    }
    public void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livestext.text = playerLives.ToString();
    }
     void ResetGameSession()
    {
       // FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    
}
