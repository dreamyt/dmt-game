using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Follow", fileName = "ActionFollow")]
public class ActionFollow : AIAction
{
    public float minDistanceToFollow = 2f;
    
    public override void Act(StateController controller)
    {
        FollowTarget(controller);
    }

    private void FollowTarget(StateController controller)
    {
        if (controller.Target == null)
        {
            return;
        }
		
        // Follow Horizontal
        if (controller.transform.position.x < controller.Target.position.x)
        {
            controller.characterMovement.SetHorizontal(1);
        }
        else
        {
            controller.characterMovement.SetHorizontal(-1);
        }
        
        // Follow Vertical
        if (controller.transform.position.y+1 < controller.Target.position.y)
        {
            controller.characterMovement.SetJump(true);
        }
        else
        {
            controller.characterMovement.SetJump(false);
        }

        // Stop if min distance reached (Horizontal)
        if (Mathf.Abs(controller.transform.position.x - controller.Target.position.x) < minDistanceToFollow)
        {
            controller.characterMovement.SetHorizontal(0);
        }
        
        // Stop if min distance reached (Vertical)
        if (Mathf.Abs(controller.transform.position.y - controller.Target.position.y) < minDistanceToFollow)
        {
            controller.characterMovement.SetJump(false);
        }     
    }
}
