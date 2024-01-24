using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    private float velocityZ;
    private float velocityX;
        void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        // Reset velocities
        velocityZ = 0.0f;
        velocityX = 0.0f;

        // Check for movement input and adjust velocities accordingly
        if (Input.GetKey(KeyCode.W))
        {
            velocityZ = 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocityX = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocityX = 1.0f;
        }

        // Set animator parameters
        animator.SetFloat("VelocityZ", velocityZ);
        animator.SetFloat("VelocityX", velocityX);
    }
}
