using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Game Play");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
