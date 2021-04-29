using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;
    private Vector3 playerStartPosition;
    public GameObject Player;

    public int scoreZonesRemaining;

    private void Awake()
    {
        scoreZonesRemaining = FindObjectsOfType<ScoringPlayer>().Length;
    }

    public void resetLevel()
    {
        Player.transform.position = playerStartPosition;
    }

    public void HandleDeath()
    {
        LIVES.Instance.LoseLife();
        resetLevel();
    }

    public void Collect()
    {
        scoreZonesRemaining--;
        Movement.Instance.StopMovement();
        if (scoreZonesRemaining <= 0)
        {
            CompleteLevel();
        }
        else
        {
            resetLevel();
        }
    }

    public void CompleteLevel()
    {
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        Instance = this;
        playerStartPosition = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
