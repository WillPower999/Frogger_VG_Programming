using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    private Vector3 playerStartPosition;
    public GameObject Player;
    
    public void resetLevel()
    {
        Player.transform.position = playerStartPosition;
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
