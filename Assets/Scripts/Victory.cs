using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Victory : MonoBehaviour
{
    public static event Action OnPlayerVictory;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Victory");
            OnPlayerVictory?.Invoke();
        }
    }
}
