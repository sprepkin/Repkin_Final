using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveableBridge : MonoBehaviour
{
    private static bool completed = false;
    private static bool playing = true;

    // Update is called once per frame
    void Update()
    {
        if (Target.triggered == true)
        {
            completed = true;
        }
    }
}
