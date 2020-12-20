using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float force = 10;
    [SerializeField] float maxVelocity = 20;
    public Rigidbody rb { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        float velocityCoef = Mathf.Abs(maxVelocity - rb.velocity.y);
        rb.AddForce(Vector3.up * force * velocityCoef * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        PlayersManager.Instance.PlayerDied();
    }
}
