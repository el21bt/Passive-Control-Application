using UnityEngine;
using UnityEngine.UI;

public class LeftOrRight : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public CalibrateDialogue calibrateDialogue;
    private Color defaultColour = Color.grey;
    private Color selectedColour = Color.green;     //used to indicate selected option
    private Color deselectedColour = Color.red;
    public bool selected;

    void Start()
    {
        selected = false;
        leftButton.onClick.AddListener(SelectLeft);
        rightButton.onClick.AddListener(SelectRight);
        leftButton.image.color = defaultColour;
        rightButton.image.color = defaultColour;

    }

    void SelectLeft()
    {
        selected = true;
        calibrateDialogue.Left = true;
        UpdateButtonColors();
    }

    void SelectRight()
    {
        selected = true;
        calibrateDialogue.Left = false;
        UpdateButtonColors();
    }

    void UpdateButtonColors()
    {
        if (calibrateDialogue.Left)
        {

            leftButton.image.color = selectedColour;
            rightButton.image.color = deselectedColour;
        }
        else
        {
            leftButton.image.color = deselectedColour;
            rightButton.image.color = selectedColour;
        }
    }
}