using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSpeed : MonoBehaviour
{
    public Image[] images;
    public Button downButton;
    public Button upButton;


    public int speedIndex = 0; // Variable to track the current position

    void Start()
    {
        UpdateImageColors(); // Update image colors based on current position
        downButton.onClick.AddListener(OnDownButtonClick);
        upButton.onClick.AddListener(OnUpButtonClick);
    }

    // Method to handle clicking the up button
    public void OnUpButtonClick()
    {
        if (speedIndex < images.Length - 1) // Check if not already at the top position
        {
            speedIndex++; // Move to the next position
            UpdateImageColors(); // Update image colors
        }
    }

    // Method to handle clicking the down button
    public void OnDownButtonClick()
    {
        if (speedIndex > 0) // Check if not already at the bottom position
        {
            speedIndex--; // Move to the previous position
            UpdateImageColors(); // Update image colors
        }
    }

    // Method to update image colors based on the current position
    void UpdateImageColors()
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (i == speedIndex)
            {
                images[i].color = Color.green; // Highlight the current image
            }
            else
            {
                images[i].color = Color.white; // Reset other images to normal color
            }
        }
    }
}
