using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
   
    void Start()
    {
        var rigidbody = GetComponent<Rigidbody>();
          rigidbody.angularVelocity = Random.insideUnitSphere * -speed;
       // RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);

    }
   
   /*
    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation",Time.time * speed);
    }
    */
}
