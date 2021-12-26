using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterInfoScript : MonoBehaviour
{
    private StatisticsController Stat;
    public TextMeshProUGUI Character_Name;
    public TextMeshProUGUI AgilityText;
    public TextMeshProUGUI StrengthText;
    public TextMeshProUGUI IntelligenceText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI HealthRegenText;
    public TextMeshProUGUI ManaText;
    public TextMeshProUGUI ManaRegenText;
    public TextMeshProUGUI Armor_text;
    public TextMeshProUGUI Fire_Res_Text;
    public TextMeshProUGUI Frost_Res_Text;
    public TextMeshProUGUI Lightning_Res_Text;
    public TextMeshProUGUI Dark_Res_Text;
    public TextMeshProUGUI Auto_Attack_damage;
    public TextMeshProUGUI AutoAttackSpeed;
    public TextMeshProUGUI CritChance_text;
    public TextMeshProUGUI CritMultiply_text;
    public TextMeshProUGUI Movement_Speed_text;


    private void Awake() {
        GameObject Player = GameObject.FindWithTag("Player");
        //used to block action when menu is open
        Stat = Player.GetComponent<StatisticsController>();
    }

    public void OnEnable(){
        AgilityText.text = Stat.agility.ToString();
        StrengthText.text = Stat.strength.ToString();
        IntelligenceText.text = Stat.inteligence.ToString();

        HealthText.text = Stat.max_health.ToString();
        HealthRegenText.text = Stat.HealthRateRegen.ToString();

        ManaText.text = Stat.max_mana.ToString();
        ManaRegenText.text = Stat.ManaRateRegen.ToString();

        Armor_text.text = Stat.armor.ToString();
        Fire_Res_Text.text = Stat.Fire_resistance.ToString();
        Frost_Res_Text.text = Stat.Fire_resistance.ToString();
        Lightning_Res_Text.text = Stat.Lightning_resistance.ToString();
        Dark_Res_Text.text = Stat.Dark_resistance.ToString();

        Auto_Attack_damage.text = Stat.Attack_damage.ToString();        
        AutoAttackSpeed.text = Stat.AAspeed.ToString();

        CritChance_text.text = Stat.crit_chance.ToString();
        CritMultiply_text.text = "1.5";
        Movement_Speed_text.text = (6*((float)Stat.agility/110)).ToString();
    }
}
