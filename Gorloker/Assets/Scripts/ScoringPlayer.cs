using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringPlayer : MonoBehaviour
{
    public GameObject collectImage;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Destroy(gameObject);

            GameObject newGameObject = Instantiate(collectImage);
            newGameObject.transform.position = transform.position;
            GameManager.Instance.Collect();
        }
    }

}
