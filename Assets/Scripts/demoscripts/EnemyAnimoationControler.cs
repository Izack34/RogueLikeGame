using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControl : MonoBehaviour
{

    public Animator animator;
    
    public void Walk(bool walk){
        animator.SetBool("Walk", walk);

    }
    public void Run(bool run){
        animator.SetBool("Run", run);
    }
    public void Attack(bool walk){
        animator.SetTrigger("Attack");
    }
}
