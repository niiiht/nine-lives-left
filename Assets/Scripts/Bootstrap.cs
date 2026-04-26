using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    public GameObject musicManagerPrefab;

    void Awake()
    {
        if (MusicManager.Instance == null)
        {
            Instantiate(musicManagerPrefab);
        }
    }

    void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
