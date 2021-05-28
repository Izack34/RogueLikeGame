using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
     public Animator animator;
    
    public void Run(bool run){
        animator.SetBool("Run", run);
    }
    public void Attack(){
        animator.SetTrigger("Attack");
    }
    public void Dead(bool d){
        animator.SetBool("Dead", d);
    }
    public void Spell1(){
        animator.SetTrigger("Spell1");
    }
    
    public void Spell2(){
        animator.SetTrigger("Spell2");
    }

    public void Spell3(){
        animator.SetTrigger("Spell3");
    }
}
