using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bool isFullScreen = true;
        int desiredFPS = 60;

        int height = Screen.height;
        int width = Screen.height * 9 / 16; // Umdrehen, wenn Breitbild.

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
