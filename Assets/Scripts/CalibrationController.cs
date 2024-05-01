using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationController : MonoBehaviour
{
    // Keys for PlayerPrefs
    private const string PlantarflexionKey = "Plantarflexion";
    private const string DorsiflexionKey = "Dorsiflexion";
    private const string AbductionKey = "Abduction";
    private const string AdductionKey = "Adduction";

    public static int targetPlantarflexion;
    public static int targetDorsiflexion;
    public static int targetAbduction;
    public static int targetAdduction;

    // Flags to track if calibration is complete for each direction
    public bool isCalibratingPlantarflexion;
    public bool isCalibratingDorsiflexion;
    public bool isCalibratingAbduction;
    public bool isCalibratingAdduction;

    /*void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }*/
    void Update()
    {
        PlayerPrefs.SetInt(PlantarflexionKey, targetPlantarflexion);
        PlayerPrefs.SetInt(DorsiflexionKey, targetDorsiflexion);
        PlayerPrefs.SetInt(AbductionKey, targetAbduction);
        PlayerPrefs.SetInt(AdductionKey, targetAdduction);
        
    }

    /* public void UpdateRotationValues(int plantarflexion, int dorsiflexion, int abduction, int adduction)
    {
        if (isCalibratingPlantarflexion)
        {
            targetPlantarflexion = plantarflexion;
        }
        else if (isCalibratingDorsiflexion)
        {
            targetDorsiflexion = dorsiflexion;
        }
        else if (isCalibratingAbduction)
        {
            targetAbduction = abduction;
        }
        else if (isCalibratingAdduction)
        {
            targetAdduction = adduction;
        }
    } */

    public void SetLeftRight(bool left)
    {

    }

    public void StartCalibrationPlantarflexion()
    {
        isCalibratingPlantarflexion = true;
        // Additional instructions for user can go here if needed
    }

    public void StartCalibrationDorsiflexion()
    {
        isCalibratingDorsiflexion = true;
        // Additional instructions for user can go here if needed
    }

    public void StartCalibrationAbduction()
    {
        isCalibratingAbduction = true;
        // Additional instructions for user can go here if needed
    }

    public void StartCalibrationAdduction()
    {
        isCalibratingAdduction = true;
        // Additional instructions for user can go here if needed
    }


}
