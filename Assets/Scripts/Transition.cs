using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public Image before;

    // Start is called before the first frame update
    private void OnEnable()
    {
        Material material = new Material(Shader.Find("Shader Graphs/BlendTextures"));

        Image image = GetComponent<Image>();
        image.material = material;

        Texture2D fromTexture;
        if (before)
        {
            fromTexture = (Texture2D)before.material.GetTexture("_ToTexture");
        }
        else
        {
            fromTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            fromTexture.SetPixel(0, 0, new Color(0, 0, 0, 0));
            fromTexture.Apply();
        }

        image.material.SetFloat("_StartTime", Time.time);
        image.material.SetTexture("_FromTexture", fromTexture);
        image.material.SetTexture("_ToTexture", image.sprite.texture);
        image.material.SetTexture("_HighlightTexture", image.sprite.texture);
    }
}
