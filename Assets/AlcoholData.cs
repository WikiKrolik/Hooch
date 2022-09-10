using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Alcohol", menuName = "Alcohol", order = 1)] 
public class AlcoholData : ScriptableObject
{
    public string name;
    public string description;
    public float voltage;

    [Header("Mixture settings")]
    public float ingredients;

    [Header("Appearance")]
    public Sprite sprite;
    public Color color;
    public Color fluidColor;
}
