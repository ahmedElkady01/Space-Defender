using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class Player : MonoBehaviour
{
    public float speed;
    protected Joystick myJoystick;
    protected JoyButton button;
    protected bool shoot;
    public GameObject Bolt;
    // public GameObject enemy1, enemy2, enemy3;
    // public Transform enemyNum1, enemyNum2, enemynum3;
    public Transform shot;
    public float tilt;
    public Boundary br;
    public float fireRate;
    private float nextFire;
    private float timer;

    //public Transform player;
    void Start()
    {
        myJoystick = FindObjectOfType<Joystick>();
        button = FindObjectOfType<JoyButton>();
    }
    private void FixedUpdate()
    {
        // using the rigidbody of the object to control the movement
        var rigidbody = GetComponent<Rigidbody>();

        // getting the values from the x and y coordinates 
        float moveHorizontal = myJoystick.Horizontal + Input.GetAxis("Horizontal");
        float moveVertical = myJoystick.Vertical + Input.GetAxis("Vertical");

        // to get the move coordinates from x axis and y axis 
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // to define the velocity 
        rigidbody.velocity = movement * speed;

        // to limit the position the Ship moves with boundries represented in xMin and xMax etc..
        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, br.xMin, br.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, br.zMin, br.zMax)
            );
        // to make it tilt 
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);

    }
    // Update is called once per frame

    void Update()
    {
        // shoot only when the button is pressed
        if (!shoot && button.Pressed && button)
        {
            shoot = true;
            while (Input.GetButton("Fire1") && Time.time>nextFire)
            {
                nextFire = Time.time + fireRate;
                shootBullet();
            }
            Debug.Log("b down");
        }


        if (shoot && !button.Pressed)
        {
            shoot = false;
            Debug.Log("b released");
        }

        timer += Time.deltaTime;

        if (timer > 5f)
        {

            SumScore.Add(1);
            timer = 0;
        }
    }

    void shootBullet()
    {
        /*
         * create an object of the laser to be shot 
         * The movement of the laser is already configured in the Mover.cs class to move the laser forward.
         * Menaing that we already implemented it on the object itself
         * to use the Instantiation below we need to have the rotation and position and only an object 
         * of class Transform can provide that as I did above.
         */

        GameObject b = Instantiate(Bolt, shot.position, shot.rotation) as GameObject;

    }



    /*
     * to move the ship without consideration to boundries 
   
        
    var rigidbody = GetComponent<Rigidbody>();
    Instantiate(Bolt, shot.position, shot.rotation);
    rigidbody.velocity = new Vector3(myJoystick.Horizontal * 15.0f + Input.GetAxis("Horizontal"),
        rigidbody.velocity.y, myJoystick.Vertical * 15.0f + Input.GetAxis("Vertical"));
    rigidbody.position = new Vector3(

        );
    player.transform.position = new Vector3(myJoystick.Horizontal * 15.0f + Input.GetAxis("Horizontal"),
       rigidbody.velocity.y, myJoystick.Vertical * 15.0f + Input.GetAxis("Vertical"));
           */



}