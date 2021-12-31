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
        newDirection = controller.Path.CurrentPoint - controller.transform.position;
        newDirection = newDirection.normalized;
        
        controller.CharacterMovement.SetHorizontal(newDirection.x);
        if (newDirection.y > 0)
        {
            controller.CharacterMovement.SetJump(true);
        }
        else
        {
            controller.CharacterMovement.SetJump(false);
        }
    }
}
