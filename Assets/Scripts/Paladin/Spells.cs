using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    private StatisticsController Statistics;

    [SerializeField]
    private GameObject lightShock_effect;

    [SerializeField]
    private GameObject Revelation_effect;

    [SerializeField]
    private GameObject LE_effect;

    private void Start() {
        Statistics = GetComponent<StatisticsController>();
    }
    public void lightShock(Vector3 point){
        //Debug.Log("spell started");
        GameObject LSEffect = Instantiate(lightShock_effect, point, Quaternion.identity) as GameObject;
        Collider[] hitColliders = Physics.OverlapSphere(point, 3f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            GameObject hitCollider = hitColliders[i].gameObject;
            if (hitCollider.CompareTag("Enemy"))
            {
                hitCollider.GetComponent<StatisticsController>().take_FireDamage(150);
            }
        }
        Statistics.mana_use(40);
        Destroy(LSEffect,2f);
    }

    public void Revelation(Vector3 point){

        GameObject Rev_effect = Instantiate(Revelation_effect, point, Quaternion.identity) as GameObject;

        Statistics.recieveHealing(80);

        Collider[] hitColliders = Physics.OverlapSphere(point, 5f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            GameObject hitCollider = hitColliders[i].gameObject;
            if (hitCollider.CompareTag("Enemy"))
            {
                hitCollider.GetComponent<StatisticsController>().take_FireDamage(30);
            }
        }
        Statistics.mana_use(100);
        Destroy(Rev_effect,3f);
    }

    public void Lightexplode(Vector3 point){

        GameObject Lightexplode_effect = Instantiate(LE_effect, point, Quaternion.identity) as GameObject;

        Collider[] hitColliders = Physics.OverlapSphere(point, 5f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            GameObject hitCollider = hitColliders[i].gameObject;
            if (hitCollider.CompareTag("Enemy"))
            {
                Statistics.recieveHealing(5);
                hitCollider.GetComponent<StatisticsController>().take_FireDamage(200);
            }
        }
        Statistics.mana_use(60);

        Destroy(Lightexplode_effect,3f);

    }

}
