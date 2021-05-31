using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootText : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.firstShot == false)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (PlayerMovement.firstShot == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
