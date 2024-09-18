using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//adds listeners for buttons and changes scenes
public class MainMenuButtons : MonoBehaviour
{
    public Button routinesButton;
    public Button calibrateButton;
    public Button optionsButton;
    public AngleData angleData;


    void Start()
    {
        routinesButton.onClick.AddListener(EnterRoutines);
        calibrateButton.onClick.AddListener(EnterCalibration);
    }

    public void EnterRoutines()
    {
        if(angleData.hasCalibrated)
        {
            angleData.chosenRoutines = false;
            SceneManager.LoadScene("Routines");
        }
        else
        {
            angleData.chosenRoutines = true;
            SceneManager.LoadScene("Calibration");
        }
        
    }
    public void EnterCalibration()
    {
        angleData.chosenRoutines = false;
        SceneManager.LoadScene("Calibration");
    }
    public void EnterOptions()
    {
        //SceneManager.LoadScene("Options");
    }
}