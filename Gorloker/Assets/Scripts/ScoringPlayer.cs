using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringPlayer : MonoBehaviour
{
    public GameObject collectImage;
    public bool scored = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            print("hi");
            //addpoints

            Destroy(gameObject);

            GameObject newGameObject = Instantiate(collectImage);
            newGameObject.transform.position = transform.position;

            scored = true;

            GameManager.Instance.Collect();
        }
    }

}
