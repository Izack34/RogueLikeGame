using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InputOutputData {
    public string id;
    public int[] index;
}

[CreateAssetMenu(fileName = "Data", menuName = "Powers", order = 1)]
public class PowerContainers : ScriptableObject
{
    public string name;
    public Sprite PictureOfPower; 
    public string content;

    public List<InputOutputData> nodeData = new List<InputOutputData>();
    
}
