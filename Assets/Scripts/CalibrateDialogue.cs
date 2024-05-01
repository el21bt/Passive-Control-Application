using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CalibrateDialogue : MonoBehaviour
{
    public VideoController videoController;
    public GameObject CalibrateUI;
    public GameObject LandR_buttons;
    public LeftOrRight leftOrRight;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public Button NextButton;
    public Button BackButton;
    public bool Left = false;
    public int index;
    private CalibrationController calibrationController; // Reference to your calibration controller script


    // Start is called before the first frame update
    void Start()
    {
        CalibrateUI.SetActive(false);
        LandR_buttons.SetActive(false);
        textComponent.text = string.Empty;
        index = 0;

        // Find the CalibrationController GameObject in the scene and get its CalibrationController script
        GameObject calibrationControllerObject = GameObject.Find("CalibrationController");
        if (calibrationControllerObject != null)
        {
            calibrationController = calibrationControllerObject.GetComponent<CalibrationController>();
        }
        else
        {
            Debug.LogError("CalibrationController GameObject not found!");
        }

        ShowLine();

        NextButton.onClick.AddListener(NextLine);
        BackButton.onClick.AddListener(PreviousLine);
        //yourButton.onClick.AddListener(TaskOnClick);
    }

    void ShowLine()
    {
        textComponent.text = lines[index];
        if (index >= 2) // Start calibration after the 2nd index
        {
            StartCalibration();
        }
        else
        {
            LandR_buttons.SetActive(false);
        }
             
    }

    void NextLine()
    {
        Invoke(nameof(DeselectButton), 0.5f);
        if (index < lines.Length - 1)
        {
            if (index == 2 && leftOrRight.selected == false)
            {
                textComponent.text = "Please choose left or right before proceeding";
            }
            else
            {
                index++;
                ShowLine();
            }
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
            gameObject.SetActive(false);
        }
    }

    void PreviousLine()
    {
        Invoke(nameof(DeselectButton), 0.5f);
        EventSystem.current.SetSelectedGameObject(null);
        if (index == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            switch (index)
            {
                case 2:

                    calibrationController.isCalibratingPlantarflexion = false;
                    break;
                case 3:
                    calibrationController.isCalibratingDorsiflexion = false;
                    break;
                case 4:
                    calibrationController.isCalibratingAbduction = false;
                    break;
                case 5:
                    calibrationController.isCalibratingAdduction = false;
                    break;
            }
            index--;
            ShowLine();
        }
    }

    

    void StartCalibration()
    {
        // Start calibration based on the current index of the dialogue
        switch (index)
        {

            case 2:
                CalibrateUI.SetActive(false);
                LandR_buttons.SetActive(true);

                break;
            case 3:
                LandR_buttons.SetActive(false);
                CalibrateUI.SetActive(true);
                videoController.PlayVideo(index - 3);
                calibrationController.StartCalibrationPlantarflexion();
                break;
            case 4:
                videoController.PlayVideo(index - 3);
                calibrationController.isCalibratingPlantarflexion = false;
                calibrationController.StartCalibrationDorsiflexion();
                break;
            case 5:
                if (Left)
                {
                    videoController.PlayVideo(index - 3);
                }
                else
                {
                    videoController.PlayVideo(index - 2);
                }
                calibrationController.StartCalibrationAbduction();
                calibrationController.isCalibratingDorsiflexion = false;
                
                break;
            case 6:
                if (Left)
                {
                    videoController.PlayVideo(index - 3);
                }
                else
                {
                    videoController.PlayVideo(index - 4);
                }
                CalibrateUI.SetActive(true);
                calibrationController.isCalibratingAbduction = false;
                calibrationController.StartCalibrationAdduction();
                break;
            case 7:
                CalibrateUI.SetActive(false);
                calibrationController.isCalibratingAdduction = false;
                break;
        }
    }

    void DeselectButton()
    {
        EventSystem.current.SetSelectedGameObject(null); // Deselect the current selected game object
    }
}