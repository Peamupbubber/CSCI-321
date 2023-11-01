// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Patroller : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    
    private Animator anim;
    private Enemy enemy;
    private GameObject player;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player");

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        if (ShouldChasePlayer())
        {
            ChasePlayer();
        }
        else
        {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
        anim.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }

    private bool ShouldChasePlayer() {
        return enemy.playerInSight;
    }

    private void ChasePlayer() {
        agent.SetDestination(player.transform.position);
    }
}