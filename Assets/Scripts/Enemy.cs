using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fovAngle = 110f;
    [HideInInspector] public bool playerInSight = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Player in range...");
            RaycastHit hit;
            Vector3 enemyToPlayer = other.gameObject.transform.position - transform.position;
            float angleToPlayer = Vector3.Angle(enemyToPlayer, transform.forward);
            bool isAngleUnderHalfAngleOfView = angleToPlayer < fovAngle * 0.5f;

            if (isAngleUnderHalfAngleOfView && Physics.Raycast(transform.position + transform.up, enemyToPlayer.normalized, out hit, 8)) {
                playerInSight = true;
                Debug.Log("Player sighted!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            playerInSight = false;
        }
    }
}
