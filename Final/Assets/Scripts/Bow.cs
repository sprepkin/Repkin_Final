using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    public int arrowDropoff;
    public float slowAmount = .25f;
    public int arrowCount = 2;

    private bool charged;
    private float chargePower;

    Vector3 dragStartPos;//Where on the screen the mouse started when we began dragging
    Vector3 dragEndPos;

    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        
        transform.right = direction;

        //Difference between GetMouseButtonDown vs GetMouseButton is the difference between first frame of just pressing and continuous held down frames

        if (Input.GetMouseButtonDown(0) && arrowCount > 0)
        {//Left mouse button just pressed
            dragStartPos = Input.mousePosition;//Store the position when the left mouse button was first pressed
        }

        if (Input.GetMouseButton(0) && arrowCount > 0)
        {//Left mouse button held
            Vector3 dragDist = dragStartPos - Input.mousePosition;//The direction we've dragged the mouse in is calculated by subtracted the current mouse position from the initial position
            /*Because dragDir is in pixels, we divide by screen width so that larger monitors don't get a huge number compared to small monitors. The same relative distance of each screen
            will now receive the same amount of launch power. Take this out and test without it in some different window scales in the game view to see the difference*/
            dragDist = dragDist / Screen.width;
            charged = true;
            //Now you are ready to launch something with dragDir something like this after spawning the arrow:
            //arrowRigidbody.velocity = dragDir * launchSpeed;
        }

        if (charged == true)
        {
            Time.timeScale = slowAmount;
            Time.fixedDeltaTime = slowAmount * 0.02f;
        }
        else
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }

        if (Input.GetMouseButtonUp(0) && charged == true && arrowCount > 0)
        {
            dragEndPos = Input.mousePosition;
            chargePower = (dragStartPos - dragEndPos).magnitude / arrowDropoff;
            charged = false;
            Shoot();
        }

        if (Arrow.collected == 1)
        {
            arrowCount += 1;
        }

        Arrow.collected = 0;
    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce * chargePower;
        arrowCount -= 1;
    }
}
