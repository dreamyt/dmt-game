using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleShotWeapon : Weapon
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
            SpawnProjectile(new Vector2(0.0f,0.2f));
            SpawnProjectile(new Vector2(0.0f,0.0f));
            SpawnProjectile(new Vector2(0.0f,-0.2f));
        }
    }

    // Spawns a projectile from the pool, setting it's new direction based on the character's direction (WeaponOwner)
    // private void SpawnProjectile(Vector2 spawnPosition)
    private void SpawnProjectile(Vector2 direction)
    {
        /* To be filled later */
        GameObject projectilePooled1 = Pooler.GetObjectFromPool();
        EvaluateProjectileSpawnPosition();
        projectilePooled1.transform.position = ProjectileGeneratePosition;
        projectilePooled1.SetActive(true);

        Projectile projectile = projectilePooled1.GetComponent<Projectile>();
        projectile.SetDirection(WeaponOwner.GetComponent<CharacterFlip>().FacingRight ? Vector2.right + direction : Vector2.left + direction);
        //nextShotTime = Time.time + timeBtwShots;
        canShoot = false;
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
