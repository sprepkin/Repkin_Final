using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public bool arrow1;
    public float arrowTransparency = 0.15f;
    public float deadArrowTransparency = 0.35f;
    public static int arrowsDead = 0;
    public AudioSource UIAudio;
    public AudioClip arrowLost;
    public static bool notStart = false;
    public int arrowNum = 0;
    public static bool updated = false;

    bool accounted = false;

    // Start is called before the first frame update
    void Start()
    {
        UIAudio = GetComponent<AudioSource>();
        accounted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Bow.arrowCount == 2 && updated == false)
        {
            arrowNum = 2;
            ArrowShot();
        }
        else if(Bow.arrowCount <= 0 && updated == false)
        {
            arrowNum = 0;
            ArrowShot();
        }
        else if(Bow.arrowCount == 1 && updated == false)
        {
            arrowNum = 1;
            ArrowShot();
        }


        if (Arrow.destroyed == true)
        {
            Arrow.destroyed = false;
            ArrowLost();
        }

        if(arrowsDead == 2 && accounted == false)
        {
            GetComponent<Image>().color = new Color(1, 0, 0, deadArrowTransparency);
            ArrowLost();
        }
    }

    void ArrowLost()
    {
        if(arrowsDead == 1 && arrow1 == true)
        {
            GetComponent<Image>().color = new Color(1, 0, 0, deadArrowTransparency);
            UIAudio.PlayOneShot(arrowLost, .5f);
        }
        
        if(arrowsDead == 2 && accounted == false)
        {
            UIAudio.PlayOneShot(arrowLost, .5f);
            accounted = true;
        }
        updated = true;
    }

    void ArrowShot()
    {
        if(arrowNum == 2 && arrowsDead == 0)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else if(arrowNum == 1 && arrow1 == true && arrowsDead == 0)
        {
            GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, arrowTransparency);
        }
        else if(arrowNum == 1 && arrow1 == false && arrowsDead <= 1)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else if(arrowNum == 0 && arrow1 == false && arrowsDead <= 1)
        {
            GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, arrowTransparency);
        }
        updated = false;
    }
}
