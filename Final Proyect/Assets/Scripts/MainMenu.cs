using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject[] Panel;

    void Start() 
    {
        Cursor.lockState = CursorLockMode.Confined;

        Panel[0].SetActive(true);
        Panel[1].SetActive(false);
        Panel[2].SetActive(false);
    }
    public static void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Controls()
    {
        Panel[0].SetActive(false);
        Panel[1].SetActive(true);
        Panel[2].SetActive(false);
    }

    public void Credits()
    {
        Panel[0].SetActive(false);
        Panel[1].SetActive(false);
        Panel[2].SetActive(true);
    }

    public void Volver()
    {
        Panel[0].SetActive(true);
        Panel[1].SetActive(false);
        Panel[2].SetActive(false);
    }
}
