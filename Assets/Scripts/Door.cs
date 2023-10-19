using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hinge;

    private Animator anim;
    private void Start()
    {
        anim = hinge.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (player.GetComponent<Player>().hasKey && Input.GetKeyDown(KeyCode.T)) {
            anim.SetBool("Open", true);
            Destroy(this);
        }
    }
}
