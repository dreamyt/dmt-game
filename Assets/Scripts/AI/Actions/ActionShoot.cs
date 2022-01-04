using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Shoot", fileName = "ActionShoot")]
public class ActionShoot : AIAction
{

public override void Act(StateController controller)
    {
        ShootPlayer(controller);
    }

    private void ShootPlayer(StateController controller)
    {
        // Stop enemy
        if (controller.characterController.isGrounded)
        {
            controller.characterMovement.SetHorizontal(0);
            controller.characterMovement.SetJump(false);
        }

        // Shoot
        if (controller.characterSpell != null)
        {
            controller.characterSpell.useSpell();
        }
    }
    
}
