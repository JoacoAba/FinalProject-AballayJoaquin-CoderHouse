using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public static void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public static void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public static void Volver()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
