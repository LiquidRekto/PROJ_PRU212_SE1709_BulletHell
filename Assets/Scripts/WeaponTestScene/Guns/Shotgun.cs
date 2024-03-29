using System.Collections.Generic;
using UnityEngine;
using WeaponTestScene.Bullets;
using WeaponTestScene.Guns;

public class Shotgun : BaseRangeWeapon
{
    private const float DIFF = 20f;
    private const int bulletPerShot = 3;
    private List<GameObject> bullets = new();
    private const float angle = 30f;

    public override bool Shoot()
    {
        if (!base.Shoot())
            return false;

        for (int i = 0; i < BulletController.ListTwelveMMBullets.Count; i++)
        {
            if (!BulletController.ListTwelveMMBullets[i].activeInHierarchy)
            {
                bullets.Add(BulletController.ListTwelveMMBullets[i]);
            }
            if (bullets.Count == bulletPerShot)
            {
                break;
            }
        }
        Setup(bullets[0], 0);
        for (int i = 1; i < bullets.Count; i++)
        {
            if (i % 2 != 0)
            {
                Setup(bullets[i], DIFF);
            }
            else
            {
                Setup(bullets[i], -DIFF);
            }
        }
        bullets.Clear();
        return true;
    }

    private void Setup(GameObject bullet, float angle)
    {
        var position = transform.position;
        var rotation = transform.rotation;
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        bullet.GetComponent<BaseBullet>().Direction = GetVectorBaseRotateAngle(angle);
        bullet.GetComponent<BaseBullet>().Damage = damage;
        bullet.SetActive(true);
    }
}
