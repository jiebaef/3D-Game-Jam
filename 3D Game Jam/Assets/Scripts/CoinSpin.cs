﻿using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float speed = 100f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }
}
