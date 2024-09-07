using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject MenuPause;
    public GameObject dot;
    public static bool isPaused = true;
    public CameraController controller;
    public AudioSource[] audioSource;
    public PlayerController playerController;
    public GameObject StaminaBar;

    private void Start()
    {        
        dot.SetActive(true);
        MenuPause.SetActive(false);
        controller = GetComponent<CameraController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            GameMenu();
        }
    }
    public void GameMenu()
    {
        MenuPause.SetActive(true);
        dot.SetActive(false);
        Time.timeScale = 0f;
        isPaused = false;
        controller.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StaminaBar.SetActive(false);
    }
    public void ContinueGame()
    {
        dot.SetActive(true);
        MenuPause.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = true;
        controller.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StaminaBar.SetActive(true);
        audioSource[0].enabled = true;
        audioSource[1].enabled = true;
        audioSource[2].enabled = true;
        audioSource[3].enabled = true;
        audioSource[4].enabled = true;
        audioSource[5].enabled = true;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

