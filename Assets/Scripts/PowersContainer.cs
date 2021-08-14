using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "PowerContainer", order = 1)]
public class PowersContainer : ScriptableObject
{
    public List<PowersData> PowersData = new List<PowersData>();

}

[System.Serializable]
public class PowersData {

    public string name;
    public Sprite PictureOfPower; 
    public string content;
    public int MODMax_health;    
    public int MODMax_mana;
    public int MODCrit_chance;
    //resists is percentage
    public int MODFire_resistance;
    public int MODFrost_resistance;
    public int MODLightning_resistance;
    public int MODDark_resistance;
    public int MODHealthRateRegen;
    public int MODManaRateRegen;
    public int MODStrength;
    public int MODAgility;
    public int MODInteligence;
}



