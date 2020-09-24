using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotetionMeteors : MonoBehaviour
{
    [SerializeField] int speed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
