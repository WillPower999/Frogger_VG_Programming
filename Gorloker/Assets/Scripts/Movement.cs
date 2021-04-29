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

    public SpriteRenderer playerSprite;
    public Sprite walkLeft;
    public Sprite walkRight;
    public Sprite stand;

    private bool isWalkLeft = false;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            playerSprite.transform.eulerAngles = new Vector3(0, 0, 0);
            StartCoroutine(MovePlayer(Vector3.up));
        }

        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            playerSprite.transform.eulerAngles = new Vector3(0, 0, 90);
            StartCoroutine(MovePlayer(Vector3.left));
        }

        if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            playerSprite.transform.eulerAngles = new Vector3(0, 0, 180);
            StartCoroutine(MovePlayer(Vector3.down));
        }

        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            playerSprite.transform.eulerAngles = new Vector3(0, 0, -90);
            StartCoroutine(MovePlayer(Vector3.right));
        }
    }

    public void ResetMovement()
    {
        StopAllCoroutines();
        isMoving = false;
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        if (isWalkLeft)
        {
            playerSprite.sprite = walkLeft;
            isWalkLeft = false;
        }
        else
        {
            playerSprite.sprite = walkRight;
            isWalkLeft = true;
        }

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

        yield return new WaitForSeconds(.1f);

        if (!isMoving)
        {
            playerSprite.sprite = stand;
        }
    }

    public void CancelMove()
    {
        StopCoroutine(nameof(MovePlayer));
        elapsedTime = 1;
        isMoving = false;
    }
}
