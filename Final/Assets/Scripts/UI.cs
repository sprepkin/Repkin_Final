﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public bool arrow1;
    public float arrowTransparency = 0.15f;
    public static int arrowsDead = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Bow.arrowCount == 2)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else if(Bow.arrowCount <= 0)
        {
            GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, arrowTransparency);
        }
        else if(Bow.arrowCount == 1 && arrow1 == true)
        {
            GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, arrowTransparency);
        }
        else if (Bow.arrowCount == 1 && arrow1 == false)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        if(arrowsDead == 1 && arrow1 == true)
        {
            GetComponent<Image>().color = new Color(1, 0, 0, .3f);
        }
        else if(arrowsDead == 2)
        {
            GetComponent<Image>().color = new Color(1, 0, 0, .3f);
        }

        if (Arrow.destroyed == true)
        {
            arrowsDead += 1;
            Arrow.destroyed = false;
        }
    }
}
