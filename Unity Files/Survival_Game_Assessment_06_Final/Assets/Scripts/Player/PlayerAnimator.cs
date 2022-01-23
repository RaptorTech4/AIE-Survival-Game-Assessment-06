using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    const float locomationAnimationSmoothTime = 0.1f;

    NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float speedPersent = agent.velocity.magnitude/agent.speed;
        animator.SetFloat("speedPercent", speedPersent, locomationAnimationSmoothTime, Time.deltaTime);
    }
}
