using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Custom/Animal", order = 0)]
public class AnimalData : ScriptableObject
{
    [field:SerializeField] public AnimalStats Stats { get; private set; }
    [field:SerializeField] public GameObject AnimalVisuals { get; private set; }
}

[Serializable]
public struct AnimalStats
{
    public string name;
    public float speed;
}