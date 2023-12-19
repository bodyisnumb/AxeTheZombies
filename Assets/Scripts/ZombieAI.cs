using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public float stoppingDistance = 1.0f; // Distance to stop when close to the player
    public Animator zombieAnimator;

    private Transform player; // Reference to the player's head Transform
    private NavMeshAgent zombieAgent;

    void Start()
    {
        zombieAgent = GetComponent<NavMeshAgent>();
        FindPlayerHead();
    }

    void FindPlayerHead()
    {
        GameObject playerHead = GameObject.FindGameObjectWithTag("PlayerHead"); // Assuming the head has a tag "PlayerHead"
        if (playerHead != null)
        {
            player = playerHead.transform;
        }
        else
        {
            Debug.LogError("Player head reference is missing!");
        }
    }

    void Update()
    {
        if (player == null)
        {
            FindPlayerHead(); // Attempt to find the player head again if it's missing
            return;
        }

        // Set destination to the player's position
        zombieAgent.SetDestination(player.position);

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        zombieAnimator.SetBool("IsAttacking", distanceToPlayer <= stoppingDistance);

        if (distanceToPlayer > stoppingDistance)
        {
            // Move the zombie using NavMeshAgent
            zombieAgent.isStopped = false;
        }
        else
        {
            // Stop the zombie when it's close to the player
            zombieAgent.isStopped = true;
        }
    }
}
