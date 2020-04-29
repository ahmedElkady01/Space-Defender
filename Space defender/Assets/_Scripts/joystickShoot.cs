using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[System.Serializable]
public class Boundry {
    public float xMin, xMax, zMin, zMax;
}
*/
public class joystickShoot : MonoBehaviour
{

    public Transform player;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public float speed = 15.0f;
    public GameObject bulletPrefab;

    public Transform circle;
    public Transform outerCircle;

    private Vector2 startingPoint;
    private int leftTouch = 99;


    // Update is called once per frame
    void Update()
    {

        // to get the mouse movement 
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.z, Camera.main.transform.position.z));

            circle.transform.position = pointA; // multiply by -1 to get it to appear on the contrary side of where you pressed
            outerCircle.transform.position = pointA;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.z, Camera.main.transform.position.z)); // witched the x and y 

        }
        else
        {
            touchStart = false;
        }



        // to get the touch movement 

        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            Vector2 touchPos = getTouchPosition(t.position); // * -1 for perspective cameras
            if (t.phase == TouchPhase.Began)
            {
                if (t.position.x > Screen.width / 2)
                {
                    shootBullet();
                }
                else
                {
                    leftTouch = t.fingerId;
                    startingPoint = touchPos;
                }
            }
            else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
            {
                Vector2 offset = touchPos - startingPoint;
                Vector2 direction = Vector2.ClampMagnitude(offset, 5.0f);

                moveCharacter(direction);

                circle.transform.position = new Vector2(outerCircle.transform.position.x + direction.x, outerCircle.transform.position.z + direction.y);

            }
            else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
            {
                leftTouch = 99;
                circle.transform.position = new Vector2(outerCircle.transform.position.x, outerCircle.transform.position.y);
            }
            ++i;
        }

    }


    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }



    // for the mouse 
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector3 offset = pointB - pointA;
            Vector3 direction = Vector3.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction); // multiply by *-1 to make it go other direction 

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        }
        else
        {
            // circles will not appear if we do not press
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

    }


    // to move the object
    void moveCharacter(Vector3 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }

    // to shoot 

    void shootBullet()
    {
        // here we instantiate an object which is the laser or the bulletprefab 
        GameObject b = Instantiate(bulletPrefab) as GameObject;

        // we hide it under the ship and we set the position to be the position of the ship
        b.transform.position = player.transform.position;
    }
}