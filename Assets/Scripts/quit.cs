﻿using UnityEngine;
using UnityEngine.UI;

public class quit : MonoBehaviour
{
    private Button quitButton;

    void Start ()
    {
        quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
