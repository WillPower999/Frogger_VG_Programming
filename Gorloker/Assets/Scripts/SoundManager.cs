using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource move;
    public AudioSource hurt;
    public AudioSource death;
    public AudioSource win;
    public AudioSource gameWin;

    void Awake()
    {
        Instance = this;
    }

}
