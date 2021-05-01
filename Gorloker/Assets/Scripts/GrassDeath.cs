using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || !Log.Instance.isTag)
        {
            GameManager.Instance.HandleDeath();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" || !Log.Instance.isTag)
        {
            GameManager.Instance.HandleDeath();
        }
    }
}
