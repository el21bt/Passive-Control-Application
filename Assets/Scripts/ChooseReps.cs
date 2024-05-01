using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChooseReps : MonoBehaviour
{
    public GameObject numbersObject;
    public GameObject modeObject;
    public Image[] position1Numbers; // Array of Image components for position 1
    public Image[] position2Numbers; // Array of Image components for position 2
    public Button downButton;
    public Button upButton;
    public Button selectButton;
    public Button modeButton;
    public bool selectedNumbers = true;
    public int repsNumber = 1; // Current number
    private Color unselectedColour = Color.grey;
    private Color defaultColour = Color.white;

    void Start()
    {
        // Show only the number 1 at the initial position
        ShowCurrentNumber();
        downButton.onClick.AddListener(OnDownButtonClick);
        upButton.onClick.AddListener(OnUpButtonClick);
        selectButton.onClick.AddListener(SelectNumbers);
        modeButton.onClick.AddListener(SelectMode);
        selectButton.gameObject.SetActive(false);
        modeButton.image.color = unselectedColour;

    }

    // Method to handle clicking the up button
    public void OnUpButtonClick()
    {
        if (repsNumber < 99) // Check if not already at the last number
        {
            repsNumber++; // Increment to the next number
            ShowCurrentNumber(); // Update displayed number
        }
    }

    // Method to handle clicking the down button
    public void OnDownButtonClick()
    {
        if (repsNumber > 1) // Check if not already at the first number
        {
            repsNumber--; // Decrement to the previous number
            ShowCurrentNumber(); // Update displayed number
        }
    }

    // Method to show the current number and hide others
    private void ShowCurrentNumber()
    {
        // Determine the tens and ones digits of the current number
        int tens = repsNumber / 10;
        int ones = repsNumber % 10;

        // Show current number for position 1
        for (int i = 0; i < position1Numbers.Length; i++)
        {
            if (i == tens)
            {
                position1Numbers[i].enabled = true;
            }

        }
        for (int i = 0; i < position1Numbers.Length; i++)
        {
            if (i != tens)
            {
                position1Numbers[i].enabled = false;
            }
        }
        for (int i = 0; i < position2Numbers.Length; i++)
        {
            if (i == ones)
            {
                position2Numbers[i].enabled = true;
            }

        }
        for (int i = 0; i < position2Numbers.Length; i++)
        {
            if (i != ones)
            {
                position2Numbers[i].enabled = false;
            }
        }
    }

        void SelectNumbers()
        {
            if(selectedNumbers != true)
            {
                selectButton.gameObject.SetActive(false);
                selectedNumbers = true;
                UpdateButtonColours();
            }
        }

        void SelectMode()
        {
            if (selectedNumbers == true)
            {
                selectButton.gameObject.SetActive(true);
                selectedNumbers = false;
                UpdateButtonColours();
            }
        }

        void UpdateButtonColours()
        {
            Image[] numberImages = numbersObject.GetComponentsInChildren<Image>();

            if (selectedNumbers)
            {
                foreach(Image image in numberImages)
                {
                    image.color = defaultColour;
                }
                modeButton.image.color = unselectedColour;
            }
            else
            {
                foreach (Image image in numberImages)
                {
                    image.color = unselectedColour;
                }
                modeButton.image.color = defaultColour;
        }
       
    }
}

