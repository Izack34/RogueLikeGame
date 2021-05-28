using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WitchDoctorController : MonoBehaviour
{
    private WitchDoctorAnimator enemy_animator;
    private NavMeshAgent navAgent;

    private WitchDoctorSpells Spells;
    private State EnemyState;

    private StatisticsController Statistics;

    private PlayerGui Gui;

    public float walk_Speed = 0.5f;
    public float run_Speed = 4f;

    public float chase_Distance = 7f;
    public float current_chase_distance = 1.8f;
    public float caster_attack_distance = 1.8f;
    public float attack_distance = 1.8f;
    public float chase_after_attack_distance = 2f;

    public float patrol_rad_Min = 20f, patrol_rad_Max = 60f;
    public float patrol_for_this_Time = 15f;
    private float patrol_Timer;

    public float wait_Before_Attack = 2f;
    private float attack_Timer;

    private bool DuringAttack = false;
    private Transform target;

    void Awake()
    { 
        enemy_animator = GetComponent<WitchDoctorAnimator>();
        navAgent = GetComponent<NavMeshAgent>();
        Spells = GetComponent<WitchDoctorSpells>();
        Statistics = GetComponent<StatisticsController>();

        target = GameObject.FindWithTag("Player").transform;
        Gui = GameObject.FindWithTag("GUI").GetComponent<PlayerGui>();
    }

    void Start() {
        EnemyState = State.PATROL;

        patrol_Timer = patrol_for_this_Time;

        attack_Timer = wait_Before_Attack;

        current_chase_distance = chase_Distance;

    }

    

    void Update()
    {
        if(EnemyState == State.PATROL){
            Partol();

        }
        if(EnemyState == State.CHASE){
            chase();

        }
        if(EnemyState == State.ATTACK){
            attack();

        }
    }



    void Partol(){
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



    void chase(){
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


    void attack(){
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        attack_Timer += Time.deltaTime;

        Debug.Log(DuringAttack);

        if(Vector3.Distance(transform.position, target.position)
                             > attack_distance + chase_after_attack_distance 
                             & !DuringAttack){
            enemy_animator.Run(true);
            EnemyState = State.CHASE;
        }

        
        //attack_Timer += Time.deltaTime;
        if(!DuringAttack & attack_Timer > wait_Before_Attack){

            if( Statistics.mana_points >= 20){
                DuringAttack = true;
                transform.LookAt(target);

                enemy_animator.Skill();
                attack_Timer = 0f;
            }else{
                DuringAttack = true;
                transform.LookAt(target);

                enemy_animator.Attack();
                attack_Timer = 0f;
            }

        }
    }//attack


    public void UseFireball(){
        Spells.Fireball();
    }

    public void EndAttack(){
        //Debug.Log("endatt");
        DuringAttack = false;
    }

    void setRandomDestination(){

        float rand_Radius = Random.Range(patrol_rad_Min,patrol_rad_Max);

        Vector3 randDir = Random.insideUnitSphere * rand_Radius;

        randDir += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDir, out navHit, rand_Radius, -1);

        navAgent.SetDestination(navHit.position);
    }
    void OnMouseOver()
    {
        Gui.ShowEnemyHP(Statistics);
    }

    void OnMouseExit()
    {
        Gui.EndShowEnemyHP();
    }
}
