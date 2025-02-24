﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerController>().swimSpeed > 0)
            {
                collision.GetComponent<PlayerController>().swimSpeed = -collision.GetComponent<PlayerController>().swimSpeed;
            }
        }
    }
}
