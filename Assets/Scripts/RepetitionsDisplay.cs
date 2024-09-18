using UnityEngine;
using TMPro;

//updates reptitions remaining number when movement is in progress

public class RepetitionsDisplay : MonoBehaviour
{
    public TMP_Text repetitionsText;
    public ChooseReps chooseReps;
    public ArduinoCommunication arduinoCommunication;

    private int repetitionsRemaining;

    private void Start()
    {
        arduinoCommunication = ArduinoCommunication.Instance;

        if (arduinoCommunication == null)
        {
            Debug.LogError("ArduinoCommunication script not found in the scene.");
        }
    }

    void Update()
    {
        UpdateRepetitionsText();
    }

    //depends on how many 1s it recieves from arduino
    void UpdateRepetitionsText()
    {
        repetitionsRemaining = chooseReps.repsNumber - arduinoCommunication.NumberOfOnesReceived;
        repetitionsText.text = "Repetitions remaining: " + repetitionsRemaining;
    }
}
