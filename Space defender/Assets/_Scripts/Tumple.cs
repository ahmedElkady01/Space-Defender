using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumple : MonoBehaviour
{
    public float tumple;
    void Start()
    {
        var rigidbody = GetComponent<Rigidbody>();
         rigidbody.angularVelocity = Random.insideUnitSphere * tumple;
       
    }

}
