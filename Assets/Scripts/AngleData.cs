using UnityEngine;

[CreateAssetMenu(fileName = "AngleData", menuName = "ScriptableObjects/AngleData", order = 1)]
public class AngleData : ScriptableObject
{
    public int targetPlantarflexion;
    public int targetDorsiflexion;
    public int targetAbduction;
    public int targetAdduction;
}
