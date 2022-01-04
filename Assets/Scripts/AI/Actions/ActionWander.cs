using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "AI/Actions/Wander", fileName = "ActionWander")]
public class ActionWander : AIAction
{
    public override void Act(StateController controller)
    {
        Wander(controller);
    }

    private void Wander(StateController controller)
    {
        controller.animator.SetBool("Spelling", false);
        bool flip = false;
        bool jump = false;
        if (controller.raycast.forward_top)
        {
            flip = true;

        }
        if (controller.raycast.forward_bottom)
        {
            flip = true;

        }
        if (!controller.raycast.forward_down)
        {
            flip = true;

        }

        if (flip)
        {
            controller.characterFlip.Flip();
        }

        controller.characterMovement.SetHorizontal(controller.raycast.face);
        controller.characterMovement.SetJump(false);

    }
}
