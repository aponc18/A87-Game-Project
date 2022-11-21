using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RespawnMenu : MonoBehaviour
{


    [SerializeField] public GameObject respawnMenu;
    public static bool isDead;

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
            RespawnGame();
        }
        
    }

    public void RespawnGame()
    {
        respawnMenu.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void GoRespawn()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
        isDead = false;
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        isDead = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
