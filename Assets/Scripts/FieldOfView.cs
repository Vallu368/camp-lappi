using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject player;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public PlayerMovement playerMov;

    public bool canSeePlayer;

    private void Start()
    {
        StartCoroutine(FOVRoutine());
        playerMov = GameObject.Find("Player").GetComponentInChildren<PlayerMovement>();
    }
    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while(true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask); //looks for player

        if (rangeChecks.Length != 0) // found player
        {
            playerMov.inFearAura = true;
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2) //player in range
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position); //how far away the player is

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)) //raycast from the center to the player, stops if it hits anything on obstructionMask
                {
                    canSeePlayer = true;
                }
                else canSeePlayer = false;
            }
            else
                canSeePlayer = false; //player not in range
        }
        else if (canSeePlayer) //if player was in view but no longer is, cancels canseeplayer
        {
            canSeePlayer = false;
        }
        else playerMov.inFearAura = false;
    }
}
