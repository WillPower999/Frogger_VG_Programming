using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LIVES : MonoBehaviour
{
    // Start is called before the first frame update
    public static LIVES Instance;
    public int _amountOfLives;
    //public Image healthBar;
    public List<Image> images;
    public bool died;
    public GameObject lost;
    private bool _canLose;

    private void Start()
    {
        _canLose = true;
        lost.SetActive(false);
    }

    void Awake()
    {
        Instance = this;
        print(images.Count);
        _amountOfLives = images.Count;
        died = false;
    }

    public void UpdateHealthBar(int currentLives, int maxLives)
    {
        float healthAmount = (float)currentLives / (float)maxLives;
    }

    public void LoseLife()
    {
        //StartCoroutine(DeathBuffer());
        _amountOfLives--;
        died = true;
        print(_amountOfLives);
        UpdateHealthUI();
    }

    //private IEnumerator DeathBuffer()
    //{
    //    if (canDie)
    //    {
    //        canDie = false;
    //        _amountOfLives--;
    //        print(_amountOfLives);
    //        UpdateHealthUI();
    //    }
    //    yield return new WaitForSeconds(1);
    //    canDie = true;
    //}

    public void GainLife()
    {
        _amountOfLives++;
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        foreach (Image myImage in images)
        {
            myImage.enabled = false;
        }

        for (int i = 0; i < _amountOfLives; i++)
        {
            images[i].enabled = true;
        }
    }

    private IEnumerator Lose()
    {
        SoundManager.Instance.death.Play();
        yield return new WaitForSeconds(3);
        GameManager.Instance.GameOver();
    }

    private void Update()
    {
        if(_amountOfLives <= 0 && _canLose)
        {
            _canLose = false;
            lost.SetActive(true);
            Destroy(Movement.Instance);
            StartCoroutine(Lose());
        }
    }
}
