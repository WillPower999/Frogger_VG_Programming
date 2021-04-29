using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    private Vector3 playerStartPosition;
    public GameObject Player;

    private int _scoreZonesRemaining;

    private void Awake()
    {
        _scoreZonesRemaining = FindObjectsOfType<ScoringPlayer>().Length;
    }

    public void resetLevel()
    {
        Movement.Instance.ResetMovement();
        Player.transform.position = playerStartPosition;
    }

    public void Collect()
    {
        _scoreZonesRemaining--;
        if (_scoreZonesRemaining > 0)
        {
            resetLevel();
        }
        else
        {
            CompleteLevel();
        }
    }

    public void CompleteLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void HandleDeath()
    {
        LIVES.Instance.LoseLife();
        resetLevel();
    }

    void Start()
    {
        Instance = this;
        playerStartPosition = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        { 
            resetLevel();
        }
    }
}
