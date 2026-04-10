using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuClicks : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene("mainScene");
    }
}
