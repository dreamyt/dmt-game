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
        bool flip = false;
        if (controller.characterController.isGrounded)
        {

            if (controller.raycast.forward_top || controller.raycast.forward_bottom)
            {
                flip = true;
                
            }
            else if (!controller.raycast.forward_down)
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
}
