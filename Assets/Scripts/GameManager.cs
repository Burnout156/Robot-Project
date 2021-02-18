using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelTutorial;
    public GameObject panelPause;
    public GameObject panelVictory;
    public Robot robot;
    public Platform platform;

    void Start()
    {
        panelPause = GameObject.Find("PanelPause");
        panelTutorial = GameObject.Find("PanelTutorial");
        panelVictory = GameObject.Find("PanelVictory");
        robot = GameObject.FindObjectOfType<Robot>();
        platform = GameObject.FindObjectOfType<Platform>();
        robot.enabled = false;
        panelPause.SetActive(false);
        panelVictory.SetActive(false);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!panelPause.activeSelf)
            {
                Pause();
            }

            else
            {
                Continue();
            }
        }
    }

    public void StartGame()
    {
        panelTutorial.SetActive(false);
        Time.timeScale = 1;
        robot.enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Victory()
    {
        panelVictory.SetActive(true);
        robot.enabled = false;
        Time.timeScale = 0;
    }

    public void CheckVictory()
    {
        if(platform.blocks.Count >= 1)
        {
            Victory();
        }
    }

    public void Pause()
    {
        panelPause.SetActive(true);
        robot.enabled = false;
        Time.timeScale = 0;
    }

    public void Continue()
    {
        panelPause.SetActive(false);
        robot.enabled = true;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
