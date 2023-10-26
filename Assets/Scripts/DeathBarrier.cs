using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathBarrier : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided");
            OnPlayerDeath?.Invoke();
        }
    }
}
