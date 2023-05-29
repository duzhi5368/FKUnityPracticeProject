using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] int Value = 1;
    public int Count = 0;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += Value;
        gameManager.UpdateTextNotice();
    }
}
