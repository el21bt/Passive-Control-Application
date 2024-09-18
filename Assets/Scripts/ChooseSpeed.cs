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
        UpdateImageColours(); // Update image colours based on current position
        downButton.onClick.AddListener(OnDownButtonClick);
        upButton.onClick.AddListener(OnUpButtonClick);
    }


    public void OnUpButtonClick()
    {
        if (speedIndex < images.Length - 1) // Check if not already at the top position
        {
            speedIndex++; // Move to the next position
            UpdateImageColours(); // Update image colours
        }
    }


    public void OnDownButtonClick()
    {
        if (speedIndex > 0) // Check if not already at the bottom position
        {
            speedIndex--; // Move to the previous position
            UpdateImageColours(); // Update image colours
        }
    }


    void UpdateImageColours()
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (i == speedIndex)
            {
                images[i].color = Color.green; // Highlight the current image
            }
            else
            {
                images[i].color = Color.white; // Reset other images to normal colour
            }
        }
    }
}
