using UnityEngine;
using TMPro;

public class RepetitionsDisplay : MonoBehaviour
{
    public TMP_Text repetitionsText;
    public ChooseReps chooseReps;

    private int repetitionsRemaining;

    void Update()
    {
        UpdateRepetitionsText();
    }

    void UpdateRepetitionsText()
    {
        repetitionsRemaining = chooseReps.repsNumber - ArduinoCommunication.Instance.NumberOfOnesReceived;
        repetitionsText.text = "Repetitions remaining: " + repetitionsRemaining;
    }
}
