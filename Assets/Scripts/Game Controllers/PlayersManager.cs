using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersManager : MonoBehaviour
{
    public static int playerNumber = 2;
    public static PlayersManager Instance { get; private set; }
    [SerializeField] PlayerController playerPrefab;
    PlayerController[] players;
    int alivePlayers;
    private void Awake()
    {
        Instance = this;
        playerNumber = Mathf.Clamp(playerNumber, 2, 4);
        alivePlayers = playerNumber;
        CreatePlayers(playerNumber);
    }


    private void Update()
    {
        if (Touchscreen.current == null)
        {
            int playerNumber = GetPlayerNumber(Mouse.current.position.ReadValue());
            players[playerNumber].Move();
        }
        else
        {
            var touches = Touchscreen.current.touches;
            foreach (var t in touches)
            {
                if (!t.isInProgress)
                    continue;
                int playerNumber = GetPlayerNumber(t.position.ReadValue());
                players[playerNumber].Move();
            }
        }        
    }

    void CreatePlayers(int number)
    {
        players = new PlayerController[number];
        for (int i = 0; i < number; i++)
        {
            players[i] = Instantiate(playerPrefab);
            players[i].transform.position = Vector3.up * (15 - i * 10);
        }
    }

    public static int GetPlayerNumber(Vector2 screenPosition)
    {
        int player = 0;
        float w = screenPosition.x / Screen.width;
        float h = screenPosition.y / Screen.height;

        if(playerNumber == 2)
        {
            if (w > .5f) player++;
        }

        else if (playerNumber == 3)
        {
            if (w > .5f) player = 1;
            if (h > .5f) player = 2;
        }

        else if (playerNumber == 4)
        {
            if (w > .5f) player++;
            if (h > .5f) player += 2;
        }

        return player;
    }

    public void PlayerDied()
    {
        alivePlayers--;
        if(alivePlayers == 0)
        {
            GameManager.Instance.EndGame();
        }
    }
}
