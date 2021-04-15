using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LIVES : MonoBehaviour
{
    // Start is called before the first frame update
    public static LIVES Instance;

    public Image healthBar;
    public TextMeshProUGUI waveText;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateHealthBar(int currentLives, int maxLives)
    {
        float healthAmount = (float)currentLives / (float)maxLives;
        healthBar.fillAmount = healthAmount;
    }

}
