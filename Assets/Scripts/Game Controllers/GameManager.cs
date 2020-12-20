using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject UI;
    int sceneIndex;

    private void Awake()
    {
        Instance = this;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void EndGame()
    {
        UI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {

    }
}
