using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    Image timerbar;
    public float maxTime = 90f;
    public float timeLeft;
    public GameObject timeOut;
    public GameObject timeAddUI;
    public float timeAdd;

    private void Start()
    {
        Instance = this;
        timeOut.SetActive(false);
        timeAddUI.SetActive(false);
        timerbar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    public void AddTime()
    {
        timeLeft = timeLeft + timeAdd;
        if(timeAdd > maxTime)
        {
            timeLeft = maxTime;
        }

        if (GameManager.Instance._scoreZonesRemaining > 0)
        {
            timeAddUI.SetActive(true);
            StartCoroutine(UItime());
        }
    }

    private IEnumerator UItime()
    {
        yield return new WaitForSeconds(2.5f);
        timeAddUI.SetActive(false);
    }

    private IEnumerator TimingOut()
    {
        yield return new WaitForSeconds(3);
        GameManager.Instance.GameOver();
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
            Destroy(Movement.Instance);
            //Time.timeScale = 0;
            StartCoroutine(TimingOut());
        }        
    }
}
