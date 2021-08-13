using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WitchDoctorController : EnemyController
{
    private WitchDoctorAnimator enemy_animator;

    private WitchDoctorSpells Spells;
    
    void Awake()
    { 
        enemy_animator = GetComponent<WitchDoctorAnimator>();
        navAgent = GetComponent<NavMeshAgent>();
        Spells = GetComponent<WitchDoctorSpells>();
        Statistics = GetComponent<StatisticsController>();
        Statistics.DieDelegate += OnDie;

        target = GameObject.FindWithTag("Player").transform;
        Gui = GameObject.FindWithTag("GUI").GetComponent<PlayerGui>();
    }


    public override void Partol(){
        navAgent.isStopped = false;
        navAgent.speed = walk_Speed;
        enemy_animator.Walk(true);

        patrol_Timer += Time.deltaTime;

        if(patrol_Timer > patrol_for_this_Time){

            setRandomDestination();
            patrol_Timer = 0;

        }

        if(navAgent.velocity.sqrMagnitude >0){
            enemy_animator.Walk(true);
        
        }else
        {
            enemy_animator.Walk(false);
            //stop walk'
        }

        if(Vector3.Distance(transform.position, target.position) <= chase_Distance){
            enemy_animator.Walk(false);
            //walk false;
            enemy_animator.Run(true);
            //run
            EnemyState = State.CHASE;
        }
    }

    public override void chase(){
        navAgent.isStopped = false;
        navAgent.speed = run_Speed;


        enemy_animator.Run(true);
        //running to player
        navAgent.SetDestination(target.position);

        if(navAgent.velocity.sqrMagnitude >0){
            enemy_animator.Run(true);
            //walk anim
        
        }else
        {
            enemy_animator.Run(false);
            //stop walk'
        }

        if(Vector3.Distance(transform.position, target.position) <= attack_distance){
            enemy_animator.Run(false);
            enemy_animator.Walk(false);
            //walk false
            //run false

            EnemyState = State.ATTACK;

        }else if(Vector3.Distance(transform.position, target.position) > chase_Distance) {
            enemy_animator.Run(false);
            //stop runni'ng
            EnemyState = State.PATROL;
        }

    }//chase

    public override void attack(){
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        attack_Timer += Time.deltaTime;
        transform.LookAt(target);
        

        if(Vector3.Distance(transform.position, target.position)
                             > attack_distance + chase_after_attack_distance 
                             & !DuringAttack){
            EnemyState = State.CHASE;

            return;
        }

        
        //attack_Timer += Time.deltaTime;
        if(!DuringAttack & attack_Timer > wait_Before_Attack){

            if( Statistics.mana_points >= 20){
                DuringAttack = true;
                enemy_animator.Skill();
                attack_Timer = 0f;

            }else{
                DuringAttack = true;
                enemy_animator.Attack();
                attack_Timer = 0f;

            }

        }
    }//attack

    public void UseFireball(){
        Spells.Fireball();
    }

    public void OnDie(){
        Gui.EndShowEnemyHP();
        //DuringAttack = true;
        //navAgent.isStopped = true;
        //Debug.Log("delegate works");
        enemy_animator.Dead(true);
        Destroy(gameObject,3f);
    }
}
