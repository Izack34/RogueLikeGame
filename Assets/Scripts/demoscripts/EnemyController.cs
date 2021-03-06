using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State{
    PATROL,
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    protected private NavMeshAgent navAgent;

    protected private PlayerGui Gui;

    protected private State EnemyState;

    public float walk_Speed = 0.5f;
    public float run_Speed = 4f;

    public float chase_Distance = 7f;
    public float current_chase_distance = 1.8f;
    public float attack_distance = 1.8f;
    public float chase_after_attack_distance = 2f;
    public float patrol_rad_Min = 20f, patrol_rad_Max = 60f;
    public float patrol_for_this_Time = 15f;
    protected private float patrol_Timer;

    public Renderer Mrenderer;
    public float wait_Before_Attack = 2f;
    protected private float attack_Timer;
    protected private Color emmisionColor = new Color(0.3f, 0.04f, 0.04f, 1f);
    protected private StatisticsController Statistics;
    protected private bool DuringAttack = false;
    protected private Transform target;
    protected private NavMeshHit navHit;

    void Awake()
    { 
        
        navAgent = GetComponent<NavMeshAgent>();
        Statistics = GetComponent<StatisticsController>();
        

        target = GameObject.FindWithTag("Player").transform;
        Gui = GameObject.FindWithTag("GUI").GetComponent<PlayerGui>();
    }

    public void Start() {
        EnemyState = State.PATROL;

        patrol_Timer = patrol_for_this_Time;

        attack_Timer = wait_Before_Attack;

        current_chase_distance = chase_Distance;

    }

    

    public void Update()
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



    public virtual void Partol(){

        navAgent.isStopped = false;
        navAgent.speed = walk_Speed;
        

        patrol_Timer += Time.deltaTime;

        if(patrol_Timer > patrol_for_this_Time){

            setRandomDestination();
            patrol_Timer = 0;

        }

        

        if(Vector3.Distance(transform.position, target.position) <= chase_Distance){
            
            EnemyState = State.CHASE;
        }
    }



    public virtual void chase(){
        navAgent.isStopped = false;
        navAgent.speed = run_Speed;


        
        //running to player
        navAgent.SetDestination(target.position);


        if(Vector3.Distance(transform.position, target.position) <= attack_distance){

            EnemyState = State.ATTACK;

        }else if(Vector3.Distance(transform.position, target.position) > chase_Distance) {
            
        
            EnemyState = State.PATROL;
        }

    }//chase


    public virtual void attack(){
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        attack_Timer += Time.deltaTime;
        transform.LookAt(target);
        
        //Debug.Log(DuringAttack);

        if(Vector3.Distance(transform.position, target.position)
                             > attack_distance + chase_after_attack_distance 
                             & !DuringAttack){
            
            EnemyState = State.CHASE;
        }

        //attack_Timer += Time.deltaTime;
        if(!DuringAttack & attack_Timer > wait_Before_Attack){

            DuringAttack = true;
            
            target.gameObject.GetComponent<StatisticsController>().take_PhysicalDamage(Statistics.melee_damage());
            attack_Timer = 0f;
        }
    }//attack

    
    public void EndAttack(){
        //Debug.Log("endatt");
        DuringAttack = false;
    }

    public void setRandomDestination(){

        float rand_Radius = Random.Range(patrol_rad_Min,patrol_rad_Max);

        Vector3 randDir = Random.insideUnitSphere * rand_Radius;

        randDir += transform.position;

        NavMesh.SamplePosition(randDir, out navHit, rand_Radius, -1);

        navAgent.SetDestination(navHit.position);
    }
    public void OnMouseOver()
    {
        Gui.ShowEnemyHP(Statistics);
        Mrenderer.material.SetColor("_EmissionColor", emmisionColor);
    }

    public void OnMouseExit()
    {
        Gui.EndShowEnemyHP();
        Mrenderer.material.SetColor("_EmissionColor", Color.black);
    }
}
