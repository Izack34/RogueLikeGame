using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianSpells : MonoBehaviour
{
    
    private StatisticsController Statistics;
    
    [SerializeField]
    private GameObject StompEffect;

    private void Start() {
        Statistics = GetComponent<StatisticsController>();
    }

    public void WarStomp(Vector3 point){
        
        //GameObject Rev_effect = Instantiate(Revelation_effect, point, Quaternion.identity) as GameObject;

        Collider[] hitColliders = Physics.OverlapSphere(point, 5f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            GameObject hitCollider = hitColliders[i].gameObject;
            if (hitCollider.CompareTag("Player"))
            {
                //stunEffect
                hitCollider.GetComponent<StatisticsController>().take_FireDamage(30);
            }
        }
        Statistics.mana_use(100);
        //Destroy(Rev_effect,3f);
    }
}
