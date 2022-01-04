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
            Debug.Log("forward_top");
            flip = true;

        }

        if (!controller.raycast.forward_down)
        {
            Debug.Log("forward_down" + name);
            flip = true;

        }

        /*if (controller.raycast.forward_bottom)
        {
            flip = true;
        }*/
        if (controller.raycast.player_behind)
        {
            Debug.Log("player_behind");
            flip = true;
        }

        if (flip)
        {
            Debug.Log("action" + " flip");
            controller.characterFlip.Flip();
            controller.raycast.face = (-controller.raycast.face);
        }

        Debug.Log("action " + controller.raycast.face);
        controller.characterMovement.SetHorizontal(controller.raycast.face);
        controller.characterMovement.SetJump(false);
    }


}
