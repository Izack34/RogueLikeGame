using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchDoctorAnimtionEvents : MonoBehaviour
{
    [SerializeField]
    private WitchDoctorController EnemyControler;

    public void FireballAT(){
        EnemyControler.UseFireball();
    }
    public void Attackend(){
        EnemyControler.EndAttack();
    }
}
