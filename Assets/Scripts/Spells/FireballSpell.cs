using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : MonoBehaviour
{
    private int Damage = 80;
    private int ProjectileSpeed = 10;

    private void Start() {
        Destroy(gameObject,8f);
    }
    
    public void SetDamage(int dmg){
        Damage = dmg;

    }

    void Update()
    {
        
        transform.Translate(Vector3.forward * ProjectileSpeed * Time.deltaTime);
    } 

    void OnCollisionEnter(Collision Object)
    {
        Debug.Log("enter colision");
        if (Object.gameObject.CompareTag("Player")){
            Object.gameObject.GetComponent<StatisticsController>().take_FireDamage((float)Damage);
            Destroy(gameObject);
        }else{

            Destroy(gameObject);
        }
    }
}
