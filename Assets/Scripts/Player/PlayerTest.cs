using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTest : MonoBehaviour
{
    PlayerController controller;
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
            controller.Move();
    }

    private void OnDisable()
    {
        GameManager.Instance.EndGame();
    }
}
