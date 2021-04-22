using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LIVES : MonoBehaviour
{
    // Start is called before the first frame update
    public static LIVES Instance;
    private int _amountOfLives;
    //public Image healthBar;
    public List<Image> images;

    void Awake()
    {
        Instance = this;
        print(images.Count);
        _amountOfLives = images.Count;
    }

    public void UpdateHealthBar(int currentLives, int maxLives)
    {
        float healthAmount = (float)currentLives / (float)maxLives;
    }

    public void LoseLife()
    {
        _amountOfLives--;
        print(_amountOfLives);
        UpdateHealthUI();
    }

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
}
