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
        
        FireballPrefab.GetComponent<FireballSpell>().SetDamage(80*(Statistics.inteligence/100));
        Statistics.mana_use(20);
    }
}
