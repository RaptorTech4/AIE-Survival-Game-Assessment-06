using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEventReciver : MonoBehaviour
{
    public CharacterCombat combat;

    public void AttackHitEvent()
    {
        combat.Attackhit_AnimationEvent();
    }

}
