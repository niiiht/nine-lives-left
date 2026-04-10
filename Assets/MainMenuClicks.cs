using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuClicks : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quited");
    }
    public void StartGame() 
    {
        SceneManager.LoadScene("mainScene");
    }
}
