using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Boundary br;
    public float speed;
    private Rigidbody rb;
    public GameObject bolt;
    public Transform shot;
    public float fireRate;
    private float nextFire;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = (transform.forward * speed) * -1;

    }


    void Update()
    {
        if (Time.time>nextFire) {
            nextFire = Time.time * fireRate;
            shootBullet();
        }
         if (transform.position.z < br.zMin)
        {
            Destroy(this.gameObject);
           
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

        GameObject b = Instantiate(bolt, shot.position, shot.rotation) as GameObject;

    }
}
