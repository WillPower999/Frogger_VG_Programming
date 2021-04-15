using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 playerStartPosition;
    public GameObject Player;


    void resetLevel()
    {
        Player.transform.position = playerStartPosition;

    }


    void Start()
    {
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
