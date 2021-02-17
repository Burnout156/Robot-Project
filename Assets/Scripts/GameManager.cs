using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject panelTutorial;
    public GameObject panelPause;
    public Robot robot;

    // Start is called before the first frame update
    void Start()
    {
        panelPause = GameObject.Find("PanelPause");
        panelTutorial = GameObject.Find("PanelTutorial");
        robot = GameObject.FindObjectOfType<Robot>();
        robot.enabled = false;
        panelPause.SetActive(false);
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
