using UnityEngine;

public class Tank2 : EnemyBase   //inheritance
{
    protected override void Move()   //polymorphism
    {
        rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);
    }
}
