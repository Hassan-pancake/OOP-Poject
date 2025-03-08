using UnityEngine;

public class EnemyBase : MonoBehaviour   //all enemy function
{
    protected Rigidbody rb;
   [SerializeField] protected float speed;
   [SerializeField] protected int health;
    protected float upperBound = 20;
    protected float lowerBound = -20;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Move() { }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        Move();
        OutOfBounds();
    }
    protected void OutOfBounds()
    {
        if (transform.position.z > upperBound || transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
