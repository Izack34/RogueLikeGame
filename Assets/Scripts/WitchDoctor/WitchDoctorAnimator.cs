using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchDoctorAnimator : MonoBehaviour
{
    public Animator animator;
    
    public void Walk(bool walk){
        animator.SetBool("Walk", walk);

    }
    public void Run(bool run){
        animator.SetBool("Run", run);
    }
    public void Attack(){
        animator.SetTrigger("Attack");
    }

    public void Skill(){
        animator.SetTrigger("Skill");
    }

    public void Dead(bool d){
        animator.SetBool("Dead", d);
    }
}
