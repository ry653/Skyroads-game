using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCoins : MonoBehaviour
{
    [SerializeField] private int coinsChange;
    [SerializeField] GameObject coins;
    void Start()
    {
        coins.SetActive(Random.Range(0, 101) <= coinsChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
