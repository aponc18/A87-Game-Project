using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RespawnMenu : MonoBehaviour
{
    //[SerializeField] public HealthManager healthBar;
    [SerializeField] public GameObject respawnMenu;
    public static bool isDead;
    public HealthManager HealthManager;
    public static bool isRespawning;

    // Start is called before the first frame update
    void Start()
    {
        respawnMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isDead = HealthManager.dead;
        if(isDead)
        {
            Time.timeScale = 0f;
            RespawnGame();
        }
        else{
            Time.timeScale = 1f;
        }
        
    }

    public void RespawnGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        respawnMenu.SetActive(true);
        
    }

    public void GoRespawn()
    {
        respawnMenu.SetActive(false);
        isDead = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        //Application.LoadLevel(Application.loadedLevel);
        //healthBar.ResetHealth();
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1f;
        respawnMenu.SetActive(false);
        isDead = false;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
