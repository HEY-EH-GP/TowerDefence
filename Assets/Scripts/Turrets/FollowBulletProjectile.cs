using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBulletProjectile : EntityProjectile
{
    float speed = 5;
    Bloon target;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // TODO Return to bullet pool
            return;
        }

        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.transform.position) < 0.2f)
        {
            HitTarget();
        }
    }

    void HitTarget()
    {
        if (target != null)
            target.TakeDamage(damage);
    }
}
