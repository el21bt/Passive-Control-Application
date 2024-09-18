using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//controls calibration process
public class CalibrateDialogue : MonoBehaviour
{
    public RectTransform panelRectTransform;
    public VideoController videoController;
    public GameObject CalibrateUI;
    public GameObject EquillibriumUI;
    public GameObject LandR_buttons;
    public LeftOrRight leftOrRight;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public Button NextButton;
    public Button BackButton;
    public bool Left = false;
    public int index;
    public MotorControlCalibration MotorControlCalibration;
    private Vector2 originalOffsetMin;
    private Vector2 originalOffsetMax;
    public AngleData angleData;

    void Start()
    {
        angleData.targetPlantarflexion = 0;
        angleData.targetDorsiflexion = 0;
        angleData.targetAdduction = 0;
        angleData.targetAbduction = 0;
        CalibrateUI.SetActive(false);
        EquillibriumUI.SetActive(false);   
        LandR_buttons.SetActive(false);
        textComponent.text = string.Empty;
        index = 0;
        originalOffsetMin = panelRectTransform.offsetMin;
        originalOffsetMax = panelRectTransform.offsetMax;
        ShowLine();
        NextButton.onClick.AddListener(NextLine);
        BackButton.onClick.AddListener(PreviousLine);
    }

    void ShowLine()
    {
        textComponent.text = lines[index];
        if (index >= 2) 
        {
            StartCalibration();
        }
        else
        {
            LandR_buttons.SetActive(false);
        }
    }

    //on next line do necessary actions
    void NextLine()
    {
        
            Invoke(nameof(DeselectButton), 0.5f);

             switch (index)
            {
                case 2:
                    MotorControlCalibration.ChooseLeftorRight();
                    MotorControlCalibration.EnterSetEquilibrium();
                    break;
                case 3:
                    MotorControlCalibration.ExitSetEquilibrium();
                    MotorControlCalibration.EnterCalibration();
                    break;
                case 4:
                    MotorControlCalibration.NextCalibrationStage();
                    break;
                case 5:
                    MotorControlCalibration.NextCalibrationStage();
                    break;
                case 6:
                    MotorControlCalibration.NextCalibrationStage();
                    break;
                case 7:
                    MotorControlCalibration.NextCalibrationStage();
                    break;
            } 

            //make sure they choose left or right
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
                //check if they entered through clicking routines with calibrating first
                if (angleData.chosenRoutines)
                {
                    angleData.hasCalibrated = true;
                    SceneManager.LoadScene("Routines");
                }
                else
                {
                    angleData.hasCalibrated = true;
                    SceneManager.LoadScene("MainMenu");
                    //gameObject.SetActive(false);
                }
        }

    }

    //similar to next line
    void PreviousLine()
    {
        //deselect the button
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
                case 3:
                    panelRectTransform.offsetMin = originalOffsetMin;
                    panelRectTransform.offsetMax = originalOffsetMax;
                    EquillibriumUI.SetActive(false);
                    MotorControlCalibration.ExitSetEquilibrium();
                    break;
                case 4:
                    CalibrateUI.SetActive(false);
                    MotorControlCalibration.EnterSetEquilibrium();
                    MotorControlCalibration.PreviousCalibrationStage();
                    break;
                case 5:
                    MotorControlCalibration.PreviousCalibrationStage();
                    break;
                case 6:
                    MotorControlCalibration.PreviousCalibrationStage();
                    break;
                case 7:
                    MotorControlCalibration.PreviousCalibrationStage();
                    break;
                case 8:
                    CalibrateUI.SetActive(true);
                    MotorControlCalibration.EnterCalibration();
                    // enters calibration then skips forward 3 because it had exited process in arduino
                    for(int i = 0; i < 3; i++)
                    {
                        MotorControlCalibration.NextCalibrationStage();
                    }

                   break;
            } 
            index--;
            ShowLine();
        }
    }

    
    //sets relative UI
     void StartCalibration()
    {
        switch (index)
        {

            case 2:
                LandR_buttons.SetActive(true);
                break;
            case 3:
                panelRectTransform.offsetMin = new Vector2(panelRectTransform.offsetMin.x, 890f);
                panelRectTransform.offsetMax = new Vector2(panelRectTransform.offsetMax.x, 0f);
                EquillibriumUI.SetActive(true);
                LandR_buttons.SetActive(false);
                break;
            case 4:
                angleData.targetPlantarflexion = 0;
                panelRectTransform.offsetMin = originalOffsetMin;
                panelRectTransform.offsetMax = originalOffsetMax;
                EquillibriumUI.SetActive(false);
                CalibrateUI.SetActive(true);
                videoController.PlayVideo(index - 4);
                break;
            case 5:
                angleData.targetDorsiflexion = 0;
                videoController.PlayVideo(index - 4);
                break;
            case 6:
                angleData.targetAbduction = 0;
                if (Left)
                {
                    videoController.PlayVideo(index - 4);
                }
                else
                {
                    videoController.PlayVideo(index - 3);
                }
                break;
            case 7:
                angleData.targetAdduction = 0;
                if (Left)
                {
                    videoController.PlayVideo(index - 4);
                }
                else
                {
                    videoController.PlayVideo(index - 5);
                }
                break;
            case 8:
                CalibrateUI.SetActive(false);
                angleData.hasCalibrated = true;
                break;
        }
    } 

    void DeselectButton()
    {
        EventSystem.current.SetSelectedGameObject(null); 
    }
} 