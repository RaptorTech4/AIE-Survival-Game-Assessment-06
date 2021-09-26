using UnityEngine;

public class UIManigmentInGame : MonoBehaviour
{
    //GameObject
    //[SerializeField]
    //private GameObject CameraSettings;
    //canvas
    [Space]
    [Header("UI Canvas")]
    public Canvas HealthMenu;
    public Canvas PauseMenu;
    public Canvas InventoryMenu;

    //Bool
    private bool PauseActive;
    private bool InventoryActive;

    private void Start()
    {
        HealthMenu.enabled = true;
        PauseActive = false;
        PauseMenu.enabled = false;
        InventoryActive = false;
        InventoryMenu.enabled = false;

        LockMouse();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            InventoryUI();
        }
        if (Input.GetButtonDown("Exit"))
        {
            PauseMenuUI();
        }
    }

    #region PauseMenu
    public void PauseMenuUI()
    {
        if(PauseActive)
        {
            ShowHealth();
            HidePauseMenu();
            LockMouse();
        }
        else
        {
            HideHealth();
            ShowPauseMenu();
            UnLockMouse();
        }
    }
    private void ShowPauseMenu()
    {
        PauseMenu.enabled = true;
        Time.timeScale = 0;
        PauseActive = true;
    }
    private void HidePauseMenu()
    {
        PauseMenu.enabled = false;
        Time.timeScale = 1;
        PauseActive = false;
    }
    #endregion PauseMenu

    #region Inventory
    public void InventoryUI()
    {
        if(InventoryActive)
        {
            HideInventory();
            ShowHealth();
            LockMouse();
        }else
        {
            HideHealth();
            ShowInventory();
            UnLockMouse();
        }
    }
    private void ShowInventory()
    {
        InventoryMenu.enabled = true;
        InventoryActive = true;
    }
    private void HideInventory()
    {
        InventoryMenu.enabled = false;
        InventoryActive = false;
    }
    #endregion Inventory

    #region HealthMenu
    private void ShowHealth()
    {
        HealthMenu.enabled = true;
    }

    private void HideHealth()
    {
        HealthMenu.enabled = false;
    }
    #endregion HealthMenu

    #region Mouse Icon
    private void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //CameraSettings.SetActive(false);
    }

    private void UnLockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        //CameraSettings.SetActive(true);
    }
    #endregion Mouse Icon
}
