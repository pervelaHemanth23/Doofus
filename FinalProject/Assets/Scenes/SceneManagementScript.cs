using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{
    int currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    public void PreviousLevel()
    {
        SceneManager.LoadScene(currentScene - 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}