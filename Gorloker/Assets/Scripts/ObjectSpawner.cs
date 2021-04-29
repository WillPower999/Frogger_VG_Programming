using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static ObjectSpawner Instance;
    public MovableObject objectPrefab;
    public int goThisWay;
    public int randomGeneration;

private void Awake()
{
    Instance = this;
}
    void Start()
    {
        DelayServe(goThisWay);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    ServeBall();
        //}
    }

    public void ServeBall()
    {
        MovableObject newObject = Instantiate(objectPrefab, transform.position,transform.rotation,null);
        newObject.direction = new Vector3(goThisWay,  0);
        
    }

    public void DelayServe(int newServeXDirection)
    {
        StartCoroutine(DelayServeCo(newServeXDirection));
    }

    private IEnumerator DelayServeCo(int newServeXDirection)
    {
        yield return new WaitForSeconds(randomGeneration);
        goThisWay = newServeXDirection;
        ServeBall();
        DelayServe(goThisWay);
    }
}
