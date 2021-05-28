using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : MonoBehaviour
{
    private int Damage = 200;
    private int ProjectileSpeed = 10;

    public void SetDamage(int dmg){
        dmg = Damage;

    }

    void Update()
    {
        
        transform.Translate(Vector3.forward * ProjectileSpeed * Time.deltaTime);
    } 

    void OnCollisionEnter(Collision Object)
    {
        Debug.Log("enter colision");
        if (Object.gameObject.CompareTag("Player")){
            Object.gameObject.GetComponent<StatisticsController>().take_FireDamage(80f);
            Destroy(gameObject);
        }else{

            Destroy(gameObject);
        }
    }
}
