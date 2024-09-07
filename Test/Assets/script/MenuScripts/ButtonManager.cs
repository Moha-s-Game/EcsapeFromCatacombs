using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }public void MenuGame()
    {
        SceneManager.LoadScene(0);
    }public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }public void QuitGame()
    {
        Application.Quit();
    }
}
