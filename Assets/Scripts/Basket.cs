using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Basket : MonoBehaviour
{
    private bool isRunning;

    public void Start()
    {
        isRunning = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isRunning == true)
        {
            isRunning = false;
            Managers.Game.GameOver();
        }
    }
}
