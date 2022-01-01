using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Can See Player", fileName = "DecisionCanSeePlayer")]
public class DecisionCanSeePlayer : AIDecision
{
    public float detectArea = 6f;
    public LayerMask targetMask;
    private Collider2D targetCollider2D;
    public override bool Decide(StateController controller)
    {
        return CanSeePlayer(controller);
    }

    private bool CanSeePlayer(StateController controller)
    {
        targetCollider2D = Physics2D.OverlapCircle(controller.transform.position, detectArea, targetMask);
        if (targetCollider2D != null)
        {
            controller.Target = targetCollider2D.transform;
            //player is at the left side of the enemy
            if (targetCollider2D.transform.position.x < controller.transform.position.x)
            {
                if (controller.GetComponent<CharacterFlip>().FacingRight)
                {
                    controller.GetComponent<CharacterFlip>().Flip();
                }
            }
            else
            {
                if (!controller.GetComponent<CharacterFlip>().FacingRight)
                {
                    controller.GetComponent<CharacterFlip>().Flip();
                }
            }
            return true;
        }

        return false;		
    }	
    
}
