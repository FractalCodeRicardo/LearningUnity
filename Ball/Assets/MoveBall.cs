using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            rb.AddForce(10f, 0 ,0);
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            rb.AddForce(-10f, 0 ,0);
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            rb.AddForce(0, 0 ,-10f);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            rb.AddForce(0, 0 ,10f);
        }
    }
}
