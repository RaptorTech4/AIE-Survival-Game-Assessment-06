using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManigmentInGame : MonoBehaviour
{
    //GameObject
    [SerializeField]
    private GameObject CameraSettings;
    //canvas
    [Space]
    [Header("UI Canvas")]
    public Canvas HealthMenu;
    public Canvas PauseMenu;
    public Canvas InventoryMenu;

    private void Start()
    {
        HealthMenu.enabled = true;
        PauseMenu.enabled = false;
        InventoryMenu.enabled = false;

        LockMouse();
    }

    private void Update()
    {
        
    }

    #region PauseMenu
    private void ShowHidePauseMenu()
    {
        switch (PauseMenu.enabled)
        {
            case true:
                PauseMenu.enabled = false;
                Time.timeScale = 1;
                LockMouse();
                break;
            case false:
                PauseMenu.enabled = true;
                Time.timeScale = 0;
                UnLockMouse();
                break;
        }
        
    }
    #endregion PauseMenu

    #region Inventory
    private void ShowHideInventory()
    {
        switch (InventoryMenu.enabled)
        {
            case true:
                InventoryMenu.enabled = false;
                LockMouse();
                break;
            case false:
                InventoryMenu.enabled = true;
                UnLockMouse();
                break;
        }
        
    }
    #endregion Inventory

    #region HealthMenu
    private void ShowHideHealth()
    {
        switch (HealthMenu.enabled)
        {
            case true:
                HealthMenu.enabled = false;
                UnLockMouse();
                break;
            case false:
                HealthMenu.enabled = true;
                LockMouse();
                break;
        }
    }
    #endregion HealthMenu

    #region Mouse Icon
    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CameraSettings.SetActive(false);
    }

    public void UnLockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        CameraSettings.SetActive(true);
    }
    #endregion Mouse Icon
}
