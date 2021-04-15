using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float movementSpeed;
    public Vector3 direction;

    public float maxXPosition;

    [HideInInspector] public float previousXPosition;
    [HideInInspector] public float currentXPosition;

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBoundaries();

        previousXPosition = currentXPosition;
        currentXPosition = transform.position.x;
    }

    void Move()
    {
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    void CheckBoundaries()
    {
        if (transform.position.x > maxXPosition)
        {
            Destroy(gameObject);
            print("bub");
        }
        else if (transform.position.x < -maxXPosition)
        {
            Destroy(gameObject);
            print("bub");
        }

    }








}
