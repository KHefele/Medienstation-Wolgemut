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


    public GameObject gameOverPanel;
    public GameObject successPanel_600Gulden;
    public GameObject successPanel_400Gulden;
    public GameObject successPanel_200Gulden;
    public GameObject successPanel_0Gulden;
    public GameObject confetti;

    public GameObject fallendeNeg200_1;
    public GameObject fallendeNeg200_2;
    public GameObject fallendeNeg200_3;

    public Image ganzerAltar;


    float timeOfLastInput;

    void Start()
    {
        guldenText.text = gulden + " Gulden verbleiben.";
        timeOfLastInput = Time.time;
    }
    
    public void LoseMoney(int amount)
    {
        gulden -= amount;
        if (gulden < 0)
        {
            gameOverPanel.SetActive(true);
        }
        guldenText.text = gulden + " Gulden verbleiben.";

        float duration = 1.5f;
        float deltaPerSecond = 1 / duration;

        if (gulden == 400)
        {
            fallendeNeg200_1.SetActive(true);
        }
        else if (gulden == 200)
        {
            fallendeNeg200_2.SetActive(true);
        }
        else if (gulden == 0)
        {
            fallendeNeg200_3.SetActive(true);
        }
    }

    public void Success()
    {
        StartCoroutine(WaitAndSuccess());
    }

    public IEnumerator WaitAndSuccess()
    {
        yield return new WaitForSeconds(1);

        // Einblenden.

        float duration = 3;
        float deltaPerSecond = 1 / duration;

        ganzerAltar.gameObject.SetActive(true);
        Color color = ganzerAltar.color;
        while (color.a < 1)
        {
            color.a += Time.deltaTime * deltaPerSecond;
            ganzerAltar.color = color;

            yield return null;
        }

        yield return new WaitForSeconds(1);

        if (gulden == 600)
        {
            successPanel_600Gulden.SetActive(true);
            confetti.SetActive(true);
        }
        else if (gulden == 400)
        {
            successPanel_400Gulden.SetActive(true);
            confetti.SetActive(true);
        }
        else if (gulden == 200)
        {
            successPanel_200Gulden.SetActive(true);
        }
        else if (gulden == 0)
        {
            successPanel_0Gulden.SetActive(true);
        }
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
