using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using System;
using System.Reflection;
using Unity.VisualScripting;

public class AngleDisplay : MonoBehaviour
{
    public CalibrateDialogue calibrateDialogue;
    //public ChooseAngle angle;
    public TMP_Text angleText;
    public AngleData angleData;


    void Update()
    {

        UpdateAngleText();
    }

    void UpdateAngleText()
    {
        switch (calibrateDialogue.index)
        {
            case 3:
                angleText.text = "Current angle: " + angleData.targetPlantarflexion + "°";
                break;
            case 4:
                angleText.text = "Current angle: " + angleData.targetDorsiflexion + "°";
                break;
            case 5:
                angleText.text = "Current angle: " + angleData.targetAbduction + "°";
                break;
            case 6:
                angleText.text = "Current angle: " + angleData.targetAdduction + "°";
                break;
        }
    }
}