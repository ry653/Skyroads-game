using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockScr : MonoBehaviour
{
    private GameManager gameManager;
    private Vector3 moveVector;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        moveVector = new Vector3(-1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.canPlay)
        {
            transform.Translate(moveVector * Time.deltaTime * gameManager.moveSpead);
        }
    }
}
