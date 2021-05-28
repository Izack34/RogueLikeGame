using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianAnimationEvent : MonoBehaviour
{
    [SerializeField]
    private BarbarianController EnemyControler;

    public void WarStompAT(){
        EnemyControler.UseWarstomp();
    }
    public void Attackend(){
        EnemyControler.EndAttack();
    }
}
