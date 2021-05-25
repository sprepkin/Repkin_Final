using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private static bool completed = false;
    private static bool playing = false;

    private Animator anim;
    public string parameterName;
    public bool currentTriggerState;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTriggerState = anim.GetBool(parameterName);

        if (Target.triggered == true)
        {
            currentTriggerState = true;
        }

        if (currentTriggerState == true && (playing != true || completed != true))
        {
            playing = true;
            if (!anim.GetBool(parameterName))
            {
                anim.SetBool(parameterName, true);
            }
        }
    }
}
