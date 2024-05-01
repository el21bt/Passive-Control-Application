using System.ComponentModel;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAngle : MonoBehaviour
{
    public Button plusOneButton;
    public Button plusFiveButton;
    public Button minusOneButton;
    public Button minusFiveButton;
    public CalibrateDialogue calibrateDialogue;

    public AngleData angleData;

    void Start()
    {
        /*if (calibrationController == null)
        {
            Debug.LogError("object not assigned");
            return;
        }*/
        
        plusOneButton.onClick.AddListener(IncrementAngleByOne);
        plusFiveButton.onClick.AddListener(IncrementAngleByFive);
        minusOneButton.onClick.AddListener(DecrementAngleByOne);
        minusFiveButton.onClick.AddListener(DecrementAngleByFive);
    }

    void IncrementAngleByOne()
    {
        ChangeAngleByValue(1);
    }

    void IncrementAngleByFive()
    {
        ChangeAngleByValue(5);
    }

    void DecrementAngleByOne()
    {
        ChangeAngleByValue(-1);
    }

    void DecrementAngleByFive()
    {
        ChangeAngleByValue(-5);
    }

    void ChangeAngleByValue(int value)
    {
        int index = calibrateDialogue.index;

        switch (index)
        {
            case 3:
                angleData.targetPlantarflexion += value;
                if (angleData.targetPlantarflexion <= 0)
                {
                    angleData.targetPlantarflexion = 0;
                }
                    break;
            case 4:
                angleData.targetDorsiflexion += value;
                if (angleData.targetDorsiflexion <= 0)
                {
                    angleData.targetDorsiflexion = 0;
                }
                break;
            case 5:
                angleData.targetAbduction += value;
                if (angleData.targetAbduction <= 0)
                {
                    angleData.targetAbduction = 0;
                }
                break;
            case 6:
                angleData.targetAdduction += value;
                if (angleData.targetAdduction <= 0)
                {
                    angleData.targetAdduction = 0;
                }
                break;
        }
    }
}