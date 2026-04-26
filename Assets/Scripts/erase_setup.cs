using UnityEngine;
using UnityEngine.UI;

public class CopyTextureToRenderTexture : MonoBehaviour
{
    public RawImage eraseTarget;      // assign your RawImage here
    public Texture2D sourceTexture;   // assign the image you want to erase
    public RenderTexture eraseTexture; // assign the RenderTexture here

    void Start()
    {
        Graphics.Blit(sourceTexture, eraseTexture);
        eraseTarget.texture = eraseTexture;
    }
}