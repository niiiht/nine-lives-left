using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    public AudioClip music;

    void Start()
    {
        MusicManager.Instance.PlayMusic(music);
    }
}