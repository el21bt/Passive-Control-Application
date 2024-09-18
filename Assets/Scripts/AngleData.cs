using UnityEngine;

[CreateAssetMenu(fileName = "AngleData", menuName = "ScriptableObjects/AngleData", order = 1)]
public class AngleData : ScriptableObject
{
    //Scriptable object to store data
    public int targetPlantarflexion = 0;
    public int targetDorsiflexion = 0;
    public int targetAbduction = 0;
    public int targetAdduction = 0;
    public bool hasCalibrated = false;
    public bool chosenRoutines;
}
