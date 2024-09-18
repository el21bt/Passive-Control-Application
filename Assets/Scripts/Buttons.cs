using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button backButton;
    public Button infoPlantarButton;
    public Button infoAbducButton;
    public Button startPlantarButton;
    public Button startAbducButton;
    public GameObject infoPanelPlantar;
    public GameObject infoPanelAbduc;

    //add listeners for buttons and set UI
    void Start()
    {
        backButton.onClick.AddListener(EnterMainMenu);
        infoPlantarButton.onClick.AddListener(PlantarInfo);
        infoAbducButton.onClick.AddListener(AbducInfo);
        infoPanelPlantar.SetActive(false);
        infoPanelAbduc.SetActive(false);

    }

    public void EnterMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlantarInfo()
    {
        infoPanelAbduc.SetActive(false);
        infoPanelPlantar.SetActive(!infoPanelPlantar.activeSelf);
    }

    public void AbducInfo()
    {
        infoPanelPlantar.SetActive(false);
        infoPanelAbduc.SetActive(!infoPanelAbduc.activeSelf);
    }

}
