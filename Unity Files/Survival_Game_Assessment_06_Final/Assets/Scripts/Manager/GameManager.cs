using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;
    }
    #endregion

    #region Canvas
    [SerializeField] Canvas mainInfo;
    [SerializeField] GameObject inventoryUI;
    [SerializeField] Canvas pauseInfo;
    [SerializeField] Canvas quitToMainMenu;
    [SerializeField] Canvas quitToDesctop;
    #endregion Canvas


    private void Start()
    {
        HideAllUI();
        mainInfo.enabled = true;
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("PauseGame"))
        {
            PauseGame();
        }
    }

    #region UI

    public void HideAllUI()
    {
        mainInfo.enabled = false;
        inventoryUI.SetActive(false);
        pauseInfo.enabled = false;
        quitToMainMenu.enabled = false;
        quitToDesctop.enabled = false;
    }

    public void PauseGame()
    {
        

        switch (pauseInfo.enabled)
        {
            case false:
                HideAllUI();
                pauseInfo.enabled = true;
                Time.timeScale = 0.0f;
                break;
            case true:
                HideAllUI();
                Time.timeScale = 1.0f;
                break;
        }
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitToDesctop()
    {
        Application.Quit();
    }

    #endregion UI
}
