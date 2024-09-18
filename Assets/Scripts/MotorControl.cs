using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MotorControl : MonoBehaviour
{
    //sends signals for motor control of routines, sends a unique code depending
    //on movement chosen, speed and reps. Interpreted by arduino
    
    public ChooseSpeed SpeedController;
    public ChooseReps repsController;
    public GameObject repsProgressScreen;
    public GameObject modeProgressScreen;
    public Button startPlantarflexionButton;
    public Button startAbductionButton;
    public Button startBothButton;
    public Button stopBothButtonReps;
    public Button stopBothButtonMode;
    public TMP_Text repsText;
    public bool movingTowardsMaxPlantar;
    public bool movingTowardsMaxAbduc;
    public bool movingTowardsMaxBoth;
    public float currentPositionPlantar;
    public float currentPositionAbduc;
    public float motorOutputPlantar;
    public float motorOutputAbduc;
    public AngleData angleData;
    public ArduinoCommunication arduinoCommunication;
    private String repsString;

    private void Start()
    {
        arduinoCommunication = ArduinoCommunication.Instance;

        if (arduinoCommunication == null)
        {
            Debug.LogError("ArduinoCommunication script not found in the scene.");
        }
        else
        {
            FlushBuffer();
            repsProgressScreen.SetActive(false);
            modeProgressScreen.SetActive(false);
            startPlantarflexionButton.onClick.AddListener(StartPlantarflexion);
            startAbductionButton.onClick.AddListener(StartAbduction);
            startBothButton.onClick.AddListener(StartBothMovements);
            stopBothButtonReps.onClick.AddListener(StopMovements);
            stopBothButtonMode.onClick.AddListener(StopMovements);
        }
    }

    public void Update()
    {
        if(arduinoCommunication.NumberOfOnesReceived == repsController.repsNumber && repsController.selectedNumbers)
        {
            arduinoCommunication.ResetNumberOfOnesReceived();
            repsProgressScreen.SetActive(false);
        }
    }

    public void StartPlantarflexion()
    {
        if (repsController.selectedNumbers)
        {
            repsProgressScreen.SetActive(true);
        }
        else
        {
            modeProgressScreen.SetActive(true);
        }
        if (!repsController.selectedNumbers)
        {
            repsString = "AA";
        }
        else
        {
            if (repsController.repsNumber < 10)
            {
                repsString = "0" + repsController.repsNumber.ToString();
            }
            else
            {
                repsString = repsController.repsNumber.ToString();
            }
        }
        string data = "a" + (SpeedController.speedIndex + 1) + repsString;
        arduinoCommunication.WriteToArduino(data);
        print("data sent plantar");

    }


    public void StartAbduction()
    {
        if (repsController.selectedNumbers)
        {
            repsProgressScreen.SetActive(true);
        }
        else
        {
            modeProgressScreen.SetActive(true);
        }
        if (!repsController.selectedNumbers)
        {
            repsString = "AA";
        }
        else
        {
            if (repsController.repsNumber < 10)
            {
                repsString = "0" + repsController.repsNumber.ToString();
            }
            else
            {
                repsString = repsController.repsNumber.ToString();
            }
        }
        string data = "b" + (SpeedController.speedIndex + 1) + repsString;
        arduinoCommunication.WriteToArduino(data);
        print("data sent abduc");
    }


    public void StartBothMovements()
    {
        if (repsController.selectedNumbers)
        {
            repsProgressScreen.SetActive(true);
        }
        else
        {
            modeProgressScreen.SetActive(true);
        }
        if (!repsController.selectedNumbers)
        {
            repsString = "AA";
        }
        else
        {
            if (repsController.repsNumber < 10)
            {
                repsString = "0" + repsController.repsNumber.ToString();
            }
            else
            {
                repsString = repsController.repsNumber.ToString();
            }
        }
        
        string data = "c" + (SpeedController.speedIndex + 1) + repsString;
        arduinoCommunication.WriteToArduino(data);
        print("data sent both");
    }

    public void StopMovements()
    {
        arduinoCommunication.ResetNumberOfOnesReceived();
        string data = "d";
        arduinoCommunication.WriteToArduino(data);
        repsProgressScreen.SetActive(false);
        modeProgressScreen.SetActive(false);
        FlushBuffer();
    }

    public void FlushBuffer()
    {
        string data = "d000";
        arduinoCommunication.WriteToArduino(data);
    }
}