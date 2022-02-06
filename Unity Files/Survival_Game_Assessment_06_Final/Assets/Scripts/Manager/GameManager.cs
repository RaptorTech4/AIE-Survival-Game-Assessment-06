using System.Collections;
using UnityEngine;
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
    [Header("UI")]
    [SerializeField] Canvas inventoryUI;
    [SerializeField] Canvas pauseInfo;
    [SerializeField] Canvas deathUI;
    [SerializeField] Canvas quitToMainMenu;
    [SerializeField] Canvas quitToDesctop;

    bool PlayerDied;

    #endregion Canvas

    #region Enemy
    [Header("Enemy prefabs")]
    [SerializeField] GameObject t1Enemy;
    [SerializeField] GameObject t2Enemy;
    [SerializeField] GameObject t3Enemy;

    [SerializeField] float timerToRespawn;
    int SpawnQuintaty;
    [SerializeField] int MaxSpawn;



    [Header("Spawn Locations")]
    [SerializeField] GameObject[] SpawnLocations;
    EnemyTipe enemySpawnTipe;
    #endregion





    private void Start()
    {
        HideAllUI();

        SpawnQuintaty = 0;

        enemySpawnTipe = EnemyTipe.T1;
        StartCoroutine(SpawnEnemy());

        PlayerDied = false;

    }

    private void Update()
    {
        if(!PlayerDied)
        {

        if (Input.GetButtonDown("PauseGame"))
        {
            PauseGame();
        }

        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.enabled = !inventoryUI.enabled;
        }

        }

    }

    #region UI

    public void HideAllUI()
    {
        inventoryUI.enabled =false;
        deathUI.enabled =false;
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

    #region Player
    public void PlayerDie()
    {
        StopCoroutine(SpawnEnemy());
        HideAllUI();
        Time.timeScale = 0.0f;
        deathUI.enabled = true;
        PlayerDied = true;

    }
    #endregion

    #region Enemy
    IEnumerator SpawnEnemy()
    {
        for (; ; )
        {
            SpawnTipe();
            GameObject SpawnLocation = SpawnLocations[(int)Random.Range(0, SpawnLocations.Length - 1)];

            switch (enemySpawnTipe)
            {
                case EnemyTipe.T1:
                    Instantiate(t1Enemy, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
                    break;
                case EnemyTipe.T2:
                    Instantiate(t2Enemy, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
                    break;
                case EnemyTipe.T3:
                    Instantiate(t3Enemy, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
                    break;
                case EnemyTipe.All:

                    int RandomValue = Random.Range(1, 3);

                    switch (RandomValue)
                    {
                        case 1:
                            Instantiate(t1Enemy, SpawnLocation.transform.position, SpawnLocation.transform.rotation);

                            break;
                        case 2:
                            Instantiate(t2Enemy, SpawnLocation.transform.position, SpawnLocation.transform.rotation);

                            break;
                        case 3:
                            Instantiate(t3Enemy, SpawnLocation.transform.position, SpawnLocation.transform.rotation);

                            break;
                        default:
                            break;
                    }

                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds(timerToRespawn);
        }
    }

    void SpawnTipe()
    {
        if (SpawnQuintaty >= MaxSpawn)
        {
            switch (enemySpawnTipe)
            {
                case EnemyTipe.T1:
                    enemySpawnTipe = EnemyTipe.T2;

                    break;
                case EnemyTipe.T2:
                    enemySpawnTipe = EnemyTipe.T3;

                    break;
                case EnemyTipe.T3:
                    enemySpawnTipe = EnemyTipe.All;

                    break;
                case EnemyTipe.All:
                    break;
                default:
                    break;
            }
            SpawnQuintaty = 0;
        }
        else
        {
            SpawnQuintaty++;
        }
    }

    //void SpawnTimer()
    //{
    //    float timerspawn = Time.time;
    //    if(timerToRespawn < timerspawn)
    //    {
    //        timerspawn = 0f;

    //        SpawnEnemy();

    //    }
    //}

    #endregion

}

public enum EnemyTipe { T1, T2, T3, All };
