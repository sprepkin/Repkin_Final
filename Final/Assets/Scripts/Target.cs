using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static bool triggered = false;
    public AudioSource targetAudio;
    public AudioClip targetDing;
    public int animCounter = 0;
    public GameObject associatedBridge;
    public string triggerName;

    Animator bridgeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        targetAudio = GetComponent<AudioSource>();
        bridgeAnimator = associatedBridge.GetComponent<Animator>();
    }

    // Update is called once per frame


    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Arrow" && triggered == false)
        {
            bridgeAnimator.SetTrigger(triggerName);
            targetAudio.PlayOneShot(targetDing, .75f);
        }
    }
}
