using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MotorControl : MonoBehaviour
{
    
    public ChooseSpeed SpeedController;
    public ChooseReps repsController;
    //public BluetoothController bluetoothController; // Reference to the Bluetooth controller
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
        repsProgressScreen.SetActive(false);
        modeProgressScreen.SetActive(false);
        startPlantarflexionButton.onClick.AddListener(StartPlantarflexion);
        startAbductionButton.onClick.AddListener(StartAbduction);
        startBothButton.onClick.AddListener(StartBothMovements);
        stopBothButtonReps.onClick.AddListener(StopMovements);
        stopBothButtonMode.onClick.AddListener(StopMovements);
    }


    void MovePlantar()
    {
        print("plantar");
    }

    void MoveAbduc()
    {
        print("abduc");
    }

    void MoveBoth()
    {
        print("both");
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
        if (repsController.repsNumber < 10)
        {
            repsString = "0" + repsController.repsNumber.ToString();
        }
        else
        {
            repsString = repsController.repsNumber.ToString();
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
        if (repsController.repsNumber < 10)
        {
            repsString = "0" + repsController.repsNumber.ToString();
        }
        else
        {
            repsString = repsController.repsNumber.ToString();
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
        if (repsController.repsNumber < 10)
        {
            repsString = "0" + repsController.repsNumber.ToString();
        }
        else
        {
            repsString = repsController.repsNumber.ToString();
        }
        string data = "c" + (SpeedController.speedIndex + 1) + repsString;
        arduinoCommunication.WriteToArduino(data);
        print("data sent both");
    }

    public void StopMovements()
    {
        arduinoCommunication.ResetNumberOfOnesReceived();
        string data = "d000";
        arduinoCommunication.WriteToArduino(data);
        repsProgressScreen.SetActive(false);
        modeProgressScreen.SetActive(false);
        motorOutputPlantar = 0;
        motorOutputAbduc = 0;
    }
}