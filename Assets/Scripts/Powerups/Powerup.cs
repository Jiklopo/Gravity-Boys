using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class Powerup : Poolable
{
    [SerializeField] float minSpeed = 10f, maxSpeed = 20f;
    public Rigidbody rb { get; private set; }
    float speed;

    private void Awake()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.velocity = Vector3.left * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Activate(collision.gameObject.GetComponent<PlayerController>());
            pool.AddObject(this);
        }
    }

    protected abstract void Activate(PlayerController player);
}
