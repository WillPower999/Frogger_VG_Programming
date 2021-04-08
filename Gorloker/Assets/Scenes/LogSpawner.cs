using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public static LogSpawner Instance;
    public Log logPrefab;
    public int goThisWay;

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
        Log newLog = Instantiate(logPrefab,transform.position,transform.rotation,null);
        newLog.direction = new Vector3(goThisWay,  0);
        
    }

    public void DelayServe(int newServeXDirection)
    {
        print("test");
        StartCoroutine(DelayServeCo(newServeXDirection));

    }

    private IEnumerator DelayServeCo(int newServeXDirection)
    {
        yield return new WaitForSeconds(2);
        goThisWay = newServeXDirection;
        ServeBall();
        DelayServe(goThisWay);
    }
}
