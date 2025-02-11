using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitThisGame()
    {
        //Just to make sure its working
        UnityEngine.Debug.LogError("Exit Game");
        Application.Quit();
    }
}
