using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public Button routinesButton;
    public Button calibrateButton;
    public Button optionsButton;


    void Start()
    {
        routinesButton.onClick.AddListener(EnterRoutines);
        //infoPlantarButton.onClick.AddListener();
        calibrateButton.onClick.AddListener(EnterCalibration);
        //optionsButton.onClick.AddListener(GoToOptions);
        //mainMenuButton.onClick.AddListener(GoToMainMenu);

    }

    public void EnterRoutines()
    {
        SceneManager.LoadScene("Routines");
    }
    public void EnterCalibration()
    {
        SceneManager.LoadScene("Calibration");
    }
    public void EnterOptions()
    {
        //SceneManager.LoadScene("Routines");
    }
}