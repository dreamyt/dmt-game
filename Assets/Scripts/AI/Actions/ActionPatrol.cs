using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="AI/Actions/Patrol", fileName="ActionPatrol")]
public class ActionPatrol : AIAction
{
    private Vector2 newDirection;
    public override void Act(StateController controller)
    {
        PatrolPath(controller);
    }

    private void PatrolPath(StateController controller)
    {
        Vector2 newDirection = controller.Path.CurrentPoint - controller.transform.position;
        Vector2 NewDirection = newDirection.normalized;
        controller.characterMovement.SetHorizontal(NewDirection.x);
        if (!controller.characterController.jump)
        {
            if (newDirection.y > 0.15f)
            {
                controller.characterMovement.SetJump(true);
            }
            else if (newDirection.y < -0.15f)
            {
                if (!controller.raycast.forward_down)
                {
                    controller.characterMovement.SetJump(true);
                }
            }
        }
        else
        {
            controller.characterMovement.SetJump(false);
        }
        controller.raycast.face = controller.transform.localScale.x;
       
        
    }
}
