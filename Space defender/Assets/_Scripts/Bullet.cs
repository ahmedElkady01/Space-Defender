using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 50.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

   // public GameObject explosion; // until i get an explosion effect

    // Use this for initialization
    void Start()
    {

        
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed,speed );
          rb.velocity = transform.forward * speed;
      //  screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }

    // Update is called once per frame
    void Update()
    {
       /* 
        if (transform.position.y > screenBounds.y * -2)
        {
            Destroy(this.gameObject);
        }
        */
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "asteroid")
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
    */
}