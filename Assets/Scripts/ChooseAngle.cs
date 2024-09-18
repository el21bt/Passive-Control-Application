using UnityEngine;
using UnityEngine.UI;

public class ChooseAngle : MonoBehaviour
{
    public Button plusOneButton;
    public Button plusFiveButton;
    public Button minusOneButton;
    public Button minusFiveButton;
    public CalibrateDialogue calibrateDialogue;
    public bool angleDecreasedFromFiveToZero = false;
    public bool angleDecreasedFromOneToZero = false;

    public AngleData angleData;

    void Start()
    {
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
            //includes a flag to know if it goes from 5 to 0 or 1 to 0 or else it is missed
            case 4:
                if (angleData.targetPlantarflexion == 5 && value == -5)
                {
                    angleDecreasedFromFiveToZero = true;
                }
                else if (angleData.targetPlantarflexion == 1 && value == -1)
                {
                    angleDecreasedFromOneToZero = true;
                }
                angleData.targetPlantarflexion += value;
                angleData.targetPlantarflexion = Mathf.Max(angleData.targetPlantarflexion, 0);
                break;
            case 5:
                if (angleData.targetDorsiflexion == 5 && value == -5)
                {
                    angleDecreasedFromFiveToZero = true;
                }
                else if (angleData.targetDorsiflexion == 1 && value == -1)
                {
                    angleDecreasedFromOneToZero = true;
                }
                angleData.targetDorsiflexion += value;
                angleData.targetDorsiflexion = Mathf.Max(angleData.targetDorsiflexion, 0);
                break;
            case 6:
                if (angleData.targetAbduction == 5 && value == -5)
                {
                    angleDecreasedFromFiveToZero = true;
                }
                else if (angleData.targetAbduction == 1 && value == -1)
                {
                    angleDecreasedFromOneToZero = true;
                }
                angleData.targetAbduction += value;
                angleData.targetAbduction = Mathf.Max(angleData.targetAbduction, 0);
                break;
            case 7:
                if (angleData.targetAdduction == 5 && value == -5)
                {
                    angleDecreasedFromFiveToZero = true;
                }
                else if (angleData.targetAdduction == 1 && value == -1)
                {
                    angleDecreasedFromOneToZero = true;
                }
                angleData.targetAdduction += value;
                angleData.targetAdduction = Mathf.Max(angleData.targetAdduction, 0);
                break;
        }
    }

}