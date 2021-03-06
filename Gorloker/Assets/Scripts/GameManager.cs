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
    public GameObject win;

    public int _scoreZonesRemaining;

    private void Awake()
    {
        _scoreZonesRemaining = FindObjectsOfType<ScoringPlayer>().Length;
    }

    public void resetLevel()
    {
        //if (LIVES.Instance.died)
        //{
        //    Movement.Instance.ResetMovement();
        //    DeathAnim();
        //}
        //else
        //{
            Movement.Instance.ResetMovement();
            Player.transform.position = playerStartPosition;
        //}
    }

    public void DeathAnim()
    {

        StartCoroutine(DeathBuffer());
    }

    private IEnumerator DeathBuffer()
    {

        yield return new WaitForSeconds(3);
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
        SoundManager.Instance.gameWin.Play();
        win.SetActive(true);
        Destroy(Player);
        Destroy(Movement.Instance);
        StartCoroutine(Win());
    }

    public void HandleDeath()
    {
        SoundManager.Instance.hurt.Play();
        LIVES.Instance.LoseLife();
        resetLevel();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        Instance = this;
        playerStartPosition = Player.transform.position;
        win.SetActive(false);
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
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
