using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static bool triggered = false;
    public AudioSource[] targetAudio;
    public AudioClip targetHitSound;
    public AudioClip targetDing;

    // Start is called before the first frame update
    void Start()
    {
        targetAudio = GetComponents<AudioSource>();
    }

    // Update is called once per frame


    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            triggered = true;
            targetAudio[0].PlayOneShot(targetHitSound, .75f);
            targetAudio[1].PlayOneShot(targetDing, .75f);
        }
    }
}
