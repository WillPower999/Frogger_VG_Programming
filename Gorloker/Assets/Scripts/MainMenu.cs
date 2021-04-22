using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public static MainMenu Instance;
    public Button _Start;

    private void Awake()
    {
        Instance = this;
    }
    void OnEnable()
    {
        _Start.onClick.AddListener(StartForOnePlayer);
    }
    void onDisable()
    {
        _Start.onClick.RemoveListener(StartForOnePlayer);
    }
    public void StartForOnePlayer()
    {
        SceneManager.LoadScene(1);
    }
}
