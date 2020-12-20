using UnityEngine;

public class Boost : Powerup
{
    [SerializeField] float force = 200;
    protected override void Activate(PlayerController player)
    {
        Debug.Log("Boost Activated!!");
        player.rb.AddForce(Vector3.right * force, ForceMode.Impulse);
    }
}
