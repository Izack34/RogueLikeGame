using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsController : MonoBehaviour
{
    public int max_health;
    public int health_points;


    public int Attack_damage = 100;
    public int crit_chance;
    public int max_mana;
    public int mana_points;
    public int armor;

    //resists is percentage
    public int Fire_resistance;
    public int Frost_resistance;
    public int Lightning_resistance;
    public int Dark_resistance;

    private int HealthRateRegen = 5;
    private int ManaRateRegen = 3;
    
    //health and melee dmg
    public int strength = 100;
    //attack speed and mv speed generaly
    public int agility = 100;
    //mana pool magic dmg
    public int inteligence = 100;

    public delegate void Die();
    public Die DieDelegate;
    
    private void Start() {
        health_points = max_health;
        mana_points = max_mana;
        StartCoroutine(ManaRegen());
        StartCoroutine(HealthRegen());

        //DieDelegate = die;

    }

    public int melee_damage(){
        float damage = Attack_damage*((float)strength/100f);

        if(Random.Range(0f, 100f) <= crit_chance){
            damage*=1.5f;
        }
        return (int)damage; 
    }

    public float Spell_damage(){
        return (float)inteligence/100f; 
    }

    public bool mana_use(int Used_mana_points){
        if(mana_points >= Used_mana_points){
            mana_points -= Used_mana_points;
            return true;
        }else{
            return false;
        }
    }

    public void recieveHealing(int HealAmount){
        health_points += HealAmount;
        health_points = Mathf.Clamp(health_points, 0, max_health);
    }
    public void take_PhysicalDamage(float PhysicalDamage){
        
        PhysicalDamage -= (((float)armor*3)/1000) * PhysicalDamage;
        //Debug.Log( PhysicalDamage);
        health_points -= (int)PhysicalDamage;
        if(health_points <= 0){
            die();
        }
    }
    public void take_FireDamage(float FireDamage){
        FireDamage -= FireDamage/100 * (float)Fire_resistance;

        health_points -= (int)FireDamage;
        if(health_points <= 0){
            die();
        }
    }
    public void take_FrostDamage(float FrostDamage){
        FrostDamage -= FrostDamage/100 * (float)Frost_resistance;

        health_points -= (int)FrostDamage;
        if(health_points <= 0){
            die();
        }
    }
    public void take_LightningDamage(float LightningDamage){
        LightningDamage -= LightningDamage/100 * (float)Lightning_resistance;

        health_points -= (int)LightningDamage;
        if(health_points <= 0){
            die();
        }
    }

    public void take_DarkDamage(float DarkDamage){
        DarkDamage -= DarkDamage/100 * (float)Dark_resistance;

        health_points -= (int)DarkDamage;
        if(health_points <= 0){
            die();
        }
    }

    IEnumerator ManaRegen(){
        while (true){ 
            mana_points += ManaRateRegen;
            mana_points = Mathf.Clamp(mana_points, 0, max_mana);
            yield return new WaitForSeconds(1);
            
        }
    }
   IEnumerator HealthRegen(){
        while (true){ 
            health_points += HealthRateRegen;
            health_points = Mathf.Clamp(health_points, 0, max_health);
            yield return new WaitForSeconds(1);
        }
   }
   

    public void die(){
        //Destroy(gameObject);
        DieDelegate();
        //Debug.Log("dead");
    }

}
