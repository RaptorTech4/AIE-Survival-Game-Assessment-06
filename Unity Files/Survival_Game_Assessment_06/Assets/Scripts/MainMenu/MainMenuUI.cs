using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    public Canvas _MainMenuCanvas;
    public Canvas _PlayCanvas;
    public Canvas _OptionsCanvas;
    public Canvas _QuitCanvas;

    private void Start()
    {
        _MainMenuCanvas.enabled = true;
        _PlayCanvas.enabled = false;
        _OptionsCanvas.enabled = false;
        _QuitCanvas.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
