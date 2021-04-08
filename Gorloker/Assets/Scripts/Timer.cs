using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timerbar;
    public float maxTime = 90f;
    float timeLeft;
    public GameObject timeOut;

    private void Start()
    {
        timeOut.SetActive(false);
        timerbar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerbar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            timeOut.SetActive(true);
            Time.timeScale = 0;
        }
    }
}