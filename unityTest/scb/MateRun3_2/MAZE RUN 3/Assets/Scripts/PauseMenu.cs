using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu; //SerializeField, because we want it as private but also it should show up in the editor

  
    public void Pause()
    {
        InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate; //The UI stops working when time is stopped, so you have to change the InputMode
        pauseMenu.SetActive(true); //enable the pause menu
        Time.timeScale = 0f; //TimeScale = 0 pauses the game, time stops

    }

    public void Resume()
    {
        InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate; //back to "normal" InputMode
        pauseMenu.SetActive(false); //disable the pause menu
        Time.timeScale = 1f; //time is normal again
    }

    public void Home()
    {
        InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate; //back to "normal" InputMode
        Time.timeScale = 1f; //time normal
        SceneManager.LoadScene("Lobby"); //Load Lobby Scene
    }

    
}
