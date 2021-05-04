using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Countdown : MonoBehaviour
{


    float currentime = 0f;
    float startingtime = 60f;
    [SerializeField] Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        currentime = startingtime;
    }

    // Update is called once per frame
    void Update()
    {
        currentime -= 1 * Time.deltaTime;
        countdownText.text = currentime.ToString("00");

        if (currentime <= 10)
        {
            countdownText.color = Color.red;

        }
       
        if (currentime <= 0)
        {

            currentime = 0;

        }
    }
}
