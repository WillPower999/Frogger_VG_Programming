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
    //private bool canDie;
    public GameObject lost;

    private void Start()
    {
        lost.SetActive(false);
    }

    void Awake()
    {
        Instance = this;
        print(images.Count);
        _amountOfLives = images.Count;
        //canDie = true;
    }

    public void UpdateHealthBar(int currentLives, int maxLives)
    {
        float healthAmount = (float)currentLives / (float)maxLives;
    }

    public void LoseLife()
    {
        //StartCoroutine(DeathBuffer());
        _amountOfLives--;
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
        yield return new WaitForSeconds(3);
        GameManager.Instance.GameOver();
    }

    private void Update()
    {
        if(_amountOfLives <= 0)
        {
            lost.SetActive(true);
            Destroy(Movement.Instance);
            StartCoroutine(Lose());
        }
    }
}
