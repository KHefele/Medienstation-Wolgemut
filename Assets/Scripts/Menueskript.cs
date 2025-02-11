using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menueskript : MonoBehaviour
{
    public void Spiel()
    {
        // load a new scene
        SceneManager.LoadScene("Spiel");
    }
    public void KlareFakten()
    {
        // load a new scene
        SceneManager.LoadScene("KlareFakten");
    }
    public void ZurückZumHauptmenü()
    {
        // load a new scene
        SceneManager.LoadScene("Hauptmenü");
    }
}