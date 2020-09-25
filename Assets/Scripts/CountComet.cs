using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountComet : MonoBehaviour
{
    [SerializeField] private GameManager GameManager;
    public int countComet;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("comet"))
        {
            countComet++;
            GameManager.AddPointToComet(5);
        }
    }
}
