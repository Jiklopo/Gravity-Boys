using UnityEngine;

public class Mine : Obstacle
{
    [SerializeField] float power = 10000f, radius = 15f;
    protected override void OnPlayerCollision(PlayerController player)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius);
        }
        pool.AddObject(this);
    }
}
