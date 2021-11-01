using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        for (int i = 1; i <= 3; i++)
        {
            Bullet tempBullet = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            tempBullet = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            tempBullet.SetDirection(new Vector2(-1f, 0.2f));
            tempBullet = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            tempBullet.SetDirection(new Vector2(-1f, -0.2f));
        }
    }
}