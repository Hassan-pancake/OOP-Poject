using UnityEngine;

public class Shoot2 : MonoBehaviour
{
    float speed = 30;
    float rotationSpeed = 360;
    private int damage = 1;
    private void Update()
    {
        // Move backward in the world space (ignoring rotation)
        transform.position += Vector3.back * Time.deltaTime * speed;

        // Rotate around its own Y-axis
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.Self);
        OutOfBounds();
    }
    void OutOfBounds()
    {
        if (transform.position.z < -17)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyBase enemy))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // Destroy bone after hitting
        }
    }
}
