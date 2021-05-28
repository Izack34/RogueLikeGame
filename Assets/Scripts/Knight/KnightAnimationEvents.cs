using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimationEvents : MonoBehaviour
{
    [SerializeField]
    private EnemyController EnemyControler;
    public void Attackend(){
        EnemyControler.EndAttack();
    }
}
