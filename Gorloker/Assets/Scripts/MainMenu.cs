using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public static MainMenu Instance;
    private Button _Start;

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
    void StartForOnePlayer()
    {
        SceneManager.LoadScene(1);
    }
}
