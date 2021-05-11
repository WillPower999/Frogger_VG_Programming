using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Movement>().CancelMove();
            GameManager.Instance.HandleDeath();
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        collision.GetComponent<Movement>().CancelMove();
    //        GameManager.Instance.HandleDeath();
    //    }
    //}
}
