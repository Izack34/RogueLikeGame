using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers : MonoBehaviour
{
    private StatisticsController Stat;

    private void Start() {
        Stat = GetComponent<StatisticsController>();
    }

    public void Addhealth(int Amount){
        Stat.max_health += Amount;
    }

    public void Addmana(int Amount){
        Stat.max_mana += Amount;
    }

    public void AddCrit(int Amount){
        Stat.crit_chance += Amount;
    }

    public void AddFire_resistance(int Amount){
        Stat.Fire_resistance += Amount;
    }

    public void AddFrost_resistance(int Amount){
        Stat.Frost_resistance += Amount;
    }

    public void AddLightning_resistance(int Amount){
        Stat.max_health += Amount;
    }
    public void AddDark_resistance(int Amount){
        Stat.Dark_resistance += Amount;
    }

    public void AddHealthRateRegen(int Amount){
        Stat.HealthRateRegen += Amount;
    }

    public void AddManaRateRegen(int Amount){
        Stat.ManaRateRegen += Amount;
    }

    public void Addstrength(int Amount){
        Stat.strength += Amount;
        Stat.Modstrength();
    }

    public void Addagility(int Amount){
        Stat.agility += Amount;
        Stat.Modagility();
    }

    public void Addinteligence(int Amount){
        Stat.inteligence += Amount;
        Stat.Modinteligence();
    }

}
