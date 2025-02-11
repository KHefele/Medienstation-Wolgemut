using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Guldenzaehler : MonoBehaviour
{
    public int gulden = 600;
    public float zeitBisEnde = 60;

    public TextMeshProUGUI guldenText;
    public TextMeshProUGUI timeLeftText;


    float timeOfLastInput;

    void Start()
    {
        guldenText.text = gulden + " Gulden verbleiben.";
        timeOfLastInput = Time.time;
    }
    
    public void LoseMoney(int amount)
    {
        gulden -= amount;
        if (gulden <= 0)
        {

        }
        guldenText.text = gulden + " Gulden verbleiben.";
    }

    void Update()
    {
        float timeSinceLastInput = Time.time - timeOfLastInput;
        float timeLeft = zeitBisEnde - timeSinceLastInput;
        if (timeLeft < 10)
        {
            timeLeftText.color = Color.red;
        }
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("Hauptmenü");
        }
        timeLeftText.text = timeLeft.ToString("0.") + " Sekunden bis Inaktivität.";
    }

    public void UserInput()
    {
        timeLeftText.color = Color.white;
        timeOfLastInput = Time.time;
    }
}
