using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchDoctorSpells : MonoBehaviour
{
    private StatisticsController Statistics;

    [SerializeField]
    private Transform ProjectileTransform;
    
    [SerializeField]
    private GameObject FireballPrefab;

    private void Start() {
        Statistics = GetComponent<StatisticsController>();
    }

    public void Fireball(){
        
        Instantiate(FireballPrefab, ProjectileTransform.position, ProjectileTransform.rotation);
        
        
        Statistics.mana_use(20);
        //Destroy(Rev_effect,3f);
    }
}
