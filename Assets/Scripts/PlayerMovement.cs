﻿using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float boostSpeed = 5;
    [SerializeField] private GameManager gameManager;

    private int laneNumber = 1,
                lanesCount = 2;

    public float firstLanePos,
                 laneDistance,
                 SideSpeed;
    private Vector3 startPosition;


    void Start()
    {
        transform.position = new Vector3(2.6f, 0.7f, 0);
        startPosition = transform.position;
        Debug.Log(transform.position);
    }


    // Update is called once per frame
    void Update()
    {
        if (gameManager.canPlay)
        {
            CheckInput();

            Vector3 newPos = transform.position;
            newPos.z = Mathf.Lerp(newPos.z, firstLanePos + (laneNumber * laneDistance), Time.deltaTime * SideSpeed);
            transform.position = newPos;
        }

    }
    void CheckInput()
    {
        if (gameManager.canPlay)
        {

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                laneNumber = 0;

            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                laneNumber = 2;

            }
            else
                laneNumber = 1;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("comet"))
        {
            StartCoroutine(Death());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coins"))
        {
            System.Console.WriteLine("+1");
            gameManager.AdCoins(1);
            Destroy(other.gameObject);
        }
    }

    IEnumerator Death()
    {
        gameManager.canPlay = false;
        yield return new WaitForSeconds(1);
        gameManager.ShowResult();

    }
    public void ResetPosition()
    {
        transform.position = startPosition;
        laneNumber = 1;
    }

}