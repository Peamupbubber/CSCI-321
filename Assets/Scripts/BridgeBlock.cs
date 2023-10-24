using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBlock : MonoBehaviour
{
    private Rigidbody rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(currentRb != null) currentRb.isKinematic = false;
        // currentRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject == GameObject.Find("Player"))
            rb.isKinematic = false;
    }
}
