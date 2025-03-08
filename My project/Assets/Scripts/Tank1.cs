using UnityEngine;

public class Tank1 : EnemyBase //inheritance
{
    protected override void Move() //polymorphism
    {
        rb.MovePosition(transform.position + Vector3.back * speed * Time.deltaTime);
    }
}
