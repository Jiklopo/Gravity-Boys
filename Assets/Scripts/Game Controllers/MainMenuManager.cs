using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Slider playersValue;
    public void StartGame()
    {
        PlayersManager.playerNumber = (int)playersValue.value;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
