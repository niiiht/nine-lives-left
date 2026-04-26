using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuClicks : MonoBehaviour
{
    public string sceneName;
    public void StartGame() 
    {
        SceneManager.LoadScene(sceneName);
    }
}
