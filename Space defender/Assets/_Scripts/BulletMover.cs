using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public Boundary br;
    public float speed;
    private Rigidbody rb;
    void Start()
    {
        /*
         * using the rigidbody of the shot to set the movement of it.
         * In this case we are moving forward on 
         * the z axis 
         */
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    public void Update()
    {
        /*
         *destroying the object whenever it gets out of bound using the Boundary class 
         * We use the z Axis since we have a 90 dgree flibed camera prespective
         */

        if (transform.position.z < br.zMin)
        {
            Destroy(this.gameObject);
        }

    }
}
