using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotWeapon : Weapon
{
    
    private Vector3 ProjectileGeneratePosition;
    public Vector3 projectileGeneratePosition;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update ()
    {
        base.Update();
    }
    
    
    protected override void StartShooting()
    {
        base.StartShooting();
    }

    protected override void RequestShoot()
    {
        base.RequestShoot();
        if (canShoot)
        {
            GameObject projectilePooled = Pooler.GetObjectFromPool();
            EvaluateProjectileSpawnPosition();
            projectilePooled.transform.position = ProjectileGeneratePosition;
            projectilePooled.SetActive(true);

            Projectile projectile = projectilePooled.GetComponent<Projectile>();
            projectile.SetDirection(WeaponOwner.GetComponent<CharacterFlip>().FacingRight ? Vector2.right : Vector2.left);
            //nextShotTime = Time.time + timeBtwShots;
            canShoot = false;
        }
    }

    // Spawns a projectile from the pool, setting it's new direction based on the character's direction (WeaponOwner)
    private void SpawnProjectile(Vector2 spawnPosition)
    {
        /* To be filled later */

    }

    // Calculates the position where our projectile is going to be fired
    private void EvaluateProjectileSpawnPosition()
    {
        if (WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
        {
            // Right side
            ProjectileGeneratePosition = transform.position + projectileGeneratePosition;
            //ProjectileGeneratePosition = transform.position + transform.rotation * projectileGeneratePosition;
        }
        else
        {
            // Left side
            ProjectileGeneratePosition = transform.position - projectileGeneratePosition;
            //ProjectileGeneratePosition = transform.position - transform.rotation * projectileGeneratePosition;
        }       
    }



}
