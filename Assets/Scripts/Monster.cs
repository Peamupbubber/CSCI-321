using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This script is attatched to the Monster game object and requires the player to have tag "Player". The idle point is set in the inspector
public class Monster : MonoBehaviour
{
    private const float MAX_PLAYER_SIGHT_RANGE = 10f;
    private Animator anim;
    private GameObject player;

    public Transform idlePoint;

    private NavMeshAgent agent;
    private bool shouldChasePlayer;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //Detect player
        RaycastHit hit;
        Vector3 monsterToPlayer = player.gameObject.transform.position - transform.position;
        if (Physics.Raycast(transform.position + transform.up, monsterToPlayer.normalized, out hit, MAX_PLAYER_SIGHT_RANGE)) {
            if (hit.transform.gameObject.CompareTag("Player")) {
                shouldChasePlayer = true;
            }
        }
        else {
            shouldChasePlayer = false;
        }

        //Chase player or return to idle point
        if (shouldChasePlayer) {
            agent.SetDestination(player.transform.position);
        }
        else {
            agent.SetDestination(idlePoint.position);
        }
        anim.SetFloat("Forward", agent.velocity.sqrMagnitude);
    }
}
