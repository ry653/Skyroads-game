﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject resultObj;
    public GameObject congratulations;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private RoadSpawner roadSpawner;
    [SerializeField] public float moveSpead;
    [SerializeField] private Text pointText;
    [SerializeField] private Text bestPointText;
    [SerializeField] private Text coinsText;
    [SerializeField] private SmoothFollow camera;
    private int point;
    public int bestPoint;
    public int coins;
    private bool boostEnable;

    public bool canPlay;
    public void ShowResult()
    {
        if (bestPoint < point)
        {
            bestPoint = point;
            bestPointText.text = ("Best score:" + bestPoint.ToString());
            congratulations.SetActive(true);
        }
        resultObj.SetActive(true);
        moveSpead = 14;
        StopAllCoroutines();
        SaveManager.Instance.SaveGame();
    }
    private void Start()
    {
        StartCoroutine(Point());
        StartCoroutine(Spead());
    }
    public void SatartGame()
    {
        Debug.Log("clik");
        congratulations.SetActive(false);
        resultObj.SetActive(false);
        camera.height = 5f;
        roadSpawner.StartGame();
        canPlay = true;
        StartCoroutine(Point());
        StartCoroutine(Spead());
        point = 0;
    }
    public void AdCoins(int c)
    {
        coins += c;
        coinsText.text = ("Coins:" + coins.ToString());
    }
    IEnumerator Point()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (boostEnable)
            {
                point += 2;

            }
            else
            {
                point++;
            }
            pointText.text = ("Score:" + point.ToString());
        }
    }
    IEnumerator Spead()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            moveSpead += 0.1f + Time.deltaTime;
            moveSpead = Mathf.Clamp(moveSpead, 14, 140);
        }
    }

    internal void RefreshText()
    {
        coinsText.text = ("Score:" + coins.ToString());
        bestPointText.text = ("Best score:" + bestPoint.ToString());
    }

    private void Update()
    {
        if (canPlay)
        {
            CheckInput();

        }
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!boostEnable)
            {
                moveSpead *= 2;
            }

            boostEnable = true;
            camera.height = 2f;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            boostEnable = false;
            moveSpead /= 2;
            camera.height = 5f;
        }
    }
}