﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            triggered = true;
        }
    }
}
