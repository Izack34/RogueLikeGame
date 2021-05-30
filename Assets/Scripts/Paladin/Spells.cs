using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    private StatisticsController Statistics;
    private AnimController PlayerAnimator;

    private Vector3 target;

    [SerializeField]
    private GameObject lightShock_effect;

    [SerializeField]
    private GameObject Revelation_effect;

    [SerializeField]
    private GameObject LE_effect;

    private void Start() {
        Statistics = GetComponent<StatisticsController>();
        PlayerAnimator = GetComponent<AnimController>();
    }


    public void Spell1(Vector3 point){
        target = point;
        PlayerAnimator.Spell1();
    }

    public void Spell2(Vector3 point){
        target = point;
        PlayerAnimator.Spell2();
    }

    public void Spell3(Vector3 point){
        target = point;
        PlayerAnimator.Spell3();
    }

    public void UselightShock(){
        
        castlightShock(target);
    }

    public void UseRevelation(){
        
        castRevelation(target);
    }

    public void UseLightexplode(){
        
        castLightexplode(target);
    }
    //******************spells*********************
    private void castlightShock(Vector3 point){
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
        
        private void castRevelation(Vector3 point){

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

        private void castLightexplode(Vector3 point){

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

