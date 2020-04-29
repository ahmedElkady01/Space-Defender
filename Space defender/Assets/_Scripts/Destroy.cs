using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject explosion;
    private bool isExploded;
    private GameObject b;
    private void OnTriggerEnter(Collider other)
    {
        b = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        Destroy(other.gameObject);
        Destroy(gameObject);
        Destroy(b, 2);
        SumScore.Add(5);
    }


}
