using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    [SerializeField] private float spinSpeed;

    [HideInInspector] public bool won = false;

    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    private void Spin()
    {
        Vector3 rotation = new Vector3(0f, 5f, 0f);
        transform.Rotate(rotation * Time.deltaTime * spinSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        won = true;
    }
}
