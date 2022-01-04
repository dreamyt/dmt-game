using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Wander&Track", fileName = "ActionWanderTrack")]
public class ActionWanderTrack : AIAction
{
    public override void Act(StateController controller)
    {
        WanderTrack(controller);
    }

    private void WanderTrack(StateController controller)
    {

        controller.animator.SetBool("Spelling", false);
        bool flip = false;
        bool jump = false;
        
            if (controller.raycast.forward_top)
            {
                flip = true;
                
            }
            if (!controller.raycast.forward_down)
            {
                flip = true;

            }

            if (controller.raycast.forward_bottom)
            {
                flip = true;
            }
            if (controller.raycast.player_behind)
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
