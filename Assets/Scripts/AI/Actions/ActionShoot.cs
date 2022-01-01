using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Shoot", fileName = "ActionShoot")]
public class ActionShoot : AIAction
{
    private Vector2 aimDirection;

    public override void Act(StateController controller)
    {
        DeterminateAim(controller);
        ShootPlayer(controller);
    }

    private void ShootPlayer(StateController controller)
    {
        // Stop enemy
        controller.characterMovement.SetHorizontal(0);
        controller.characterMovement.SetJump(false);

        // Shoot
        
        controller.characterSpell.useSpell();
    }

    private void DeterminateAim(StateController controller)
    {
        aimDirection = controller.Target.position - controller.transform.position;
    }
}
