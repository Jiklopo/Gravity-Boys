using UnityEngine;

public abstract class Obstacle : Poolable
{
    
    public Rigidbody rb { get; private set; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pool = FindObjectOfType<GameObjectPool>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerCollision(collision.gameObject.GetComponent<PlayerController>());
        }
    }

    private void OnBecameInvisible()
    {
        pool.AddObject(this);
    }

    protected abstract void OnPlayerCollision(PlayerController player);
}
