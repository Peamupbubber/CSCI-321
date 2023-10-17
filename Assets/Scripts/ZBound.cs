using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZBound : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && !player.GetComponent<Player>().hasKey)
            player.transform.position = player.GetComponent<Player>().respawnPoint;
    }
}
