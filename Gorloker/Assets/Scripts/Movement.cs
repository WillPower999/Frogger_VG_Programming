using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance;

    [HideInInspector] public bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.13f;
    private float elapsedTime = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void StopMovement()
    {
        StopAllCoroutines();
        isMoving = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));

        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.left));

        if (Input.GetKeyDown(KeyCode.S) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.down));

        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.right));
    }
    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    public void CancelMove()
    {
        StopCoroutine(nameof(MovePlayer));
        elapsedTime = 1;
        isMoving = false;
    }
}
