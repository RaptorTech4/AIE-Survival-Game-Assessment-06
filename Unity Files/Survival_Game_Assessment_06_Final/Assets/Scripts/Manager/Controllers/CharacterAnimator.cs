using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{

    public AnimationClip repaceableAttackAnimation;

    public AnimationClip[] defaultAttackAnimationSet;
    protected AnimationClip[] currentAttackAnimationSet;

    const float locomationAnimationSmoothTime = 0.1f;

    NavMeshAgent agent;
    protected Animator animator;

    protected CharacterCombat combat;
    protected AnimatorOverrideController overrideController;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();

        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;

        currentAttackAnimationSet = defaultAttackAnimationSet;

        combat.OnAttack += OnAttack;
    }

    protected virtual void Update()
    {
        float speedPersent = agent.velocity.magnitude/agent.speed;
        animator.SetFloat("speedPercent", speedPersent, locomationAnimationSmoothTime, Time.deltaTime);

        animator.SetBool("inCombat", combat.InCombat);


    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("attack");
        int attackIndex = Random.Range(0, currentAttackAnimationSet.Length);
        overrideController[repaceableAttackAnimation.name] = currentAttackAnimationSet[attackIndex];
    }
}
