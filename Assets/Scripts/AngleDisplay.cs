using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class AngleDisplay : MonoBehaviour
{
    public CalibrateDialogue calibrateDialogue;
    public TMP_Text angleText;
    public AngleData angleData;


    void Update()
    {
        //show current angle
        switch (calibrateDialogue.index)
        {
            case 4:
                angleText.text = "Current angle: " + angleData.targetPlantarflexion + "°";
                break;
            case 5:
                angleText.text = "Current angle: " + angleData.targetDorsiflexion + "°";
                break;
            case 6:
                angleText.text = "Current angle: " + angleData.targetAbduction + "°";
                break;
            case 7:
                angleText.text = "Current angle: " + angleData.targetAdduction + "°";
                break;
        }
    }
}

