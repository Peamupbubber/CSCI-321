using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<Player>().hasKey) {
            Destroy(gameObject);
        }
    }
}
