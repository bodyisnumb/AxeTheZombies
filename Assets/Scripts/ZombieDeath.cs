using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public GameObject ragdollPrefab;

    private Animator animator;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AxeCollider"))
        {
            // Disable the animator
            animator.enabled = false;

            // Instantiate the ragdoll at the same position as the animated zombie
            GameObject ragdoll = Instantiate(ragdollPrefab, transform.position, transform.rotation);
            
            // Destroy the animated zombie
            Destroy(gameObject);
        }
    }
}
