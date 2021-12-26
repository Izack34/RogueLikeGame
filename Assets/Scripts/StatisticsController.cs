using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsController : MonoBehaviour
{
    public Animator animator;
    public UnityEngine.AI.NavMeshAgent Agent;

    private int BaseHealth = 200;
    private int BaseMana = 50;

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

    public int HealthRateRegen = 5;
    public int ManaRateRegen = 3;
    
    //health and melee dmg
    public int strength = 100;
    //attack speed and mv speed generaly
    public int agility = 100;
    //mana pool magic dmg
    public int inteligence = 100;

    public float AAspeed;
    public float Castspeed;

    public delegate void Die();
    public Die DieDelegate;
    
    private void Start() {

        Modstrength();
        Modagility();
        Modinteligence();

        health_points = max_health;
        mana_points = max_mana;
        
        StartCoroutine(ManaRegen());
        StartCoroutine(HealthRegen());
    }

    public void ModificationToStats(int[] Amounts){
        BaseHealth += Amounts[0];
        BaseMana += Amounts[1];

        crit_chance += Amounts[2];
        Fire_resistance += Amounts[3];
        Frost_resistance += Amounts[4];
        Dark_resistance += Amounts[5];
        Lightning_resistance += Amounts[6];
        HealthRateRegen += Amounts[7];
        ManaRateRegen += Amounts[8];

        strength += Amounts[9];
        Modstrength();
        agility += Amounts[10];
        Modagility();
        inteligence += Amounts[11];
        Modinteligence();
    }

    public void Modstrength(){
        max_health = BaseHealth + strength * 4;
    }

    public void Modagility(){    
        AAspeed = (float)agility/70;
        animator.SetFloat("AASpeed",AAspeed);
    
        Agent.speed = 6*((float)agility/110);
    }

    public void Modinteligence(){
        max_mana = inteligence * 2;

        Castspeed = (float)inteligence/100;

        animator.SetFloat("CastSpeed",Castspeed);
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
