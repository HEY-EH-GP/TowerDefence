using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowBulletProjectile : EntityProjectile
{
    float speed = 5;
    Bloon target;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); //TODO Return to bullet pool
            return;
        }

        // Muovere il proiettile verso il bersaglio
        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Distruggere il proiettile se colpisce
        if (Vector3.Distance(transform.position, target.transform.position) < 0.2f)
        {
            HitTarget();
        }
    }

    void HitTarget()
    {
        if (target != null)
            target.TakeDamage(damage);

        if (target.health <= 0)
            Destroy(gameObject); // TODO RETURN TO POOL
    }
}
