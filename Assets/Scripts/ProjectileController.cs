using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 10f; // Velocità del proiettile
    public int damage = 1; // Danno del proiettile

    private Bloon target;

    public void SetTarget(Bloon newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
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

        if(target.health <= 0)
            Destroy(gameObject); // TODO RETURN TO POOL
    }
}