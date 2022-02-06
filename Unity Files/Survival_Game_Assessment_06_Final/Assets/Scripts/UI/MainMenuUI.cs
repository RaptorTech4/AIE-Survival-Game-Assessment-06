using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{

    [SerializeField] Canvas main;
    [SerializeField] Canvas quit;

    void Start()
    {
        HideAllUI();
        main.enabled = true;
    }

    public void HideAllUI()
    {
        main.enabled = false;
        quit.enabled = false;
    }
    

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
