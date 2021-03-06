using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControler : MonoBehaviour
{
    public Camera Cam;
    public RaycastHit hit;
    public NavMeshAgent Agent;
    private AnimController PlayerAnimator;
    private StatisticsController Statistics;
    private Spells SpellsScript;
    //private float GDC = 1f; //globalcooldown
    private Vector3 point;
    public bool during_attack = false;
    private Ray MouseRaytarget;


    private void Start() {
        PlayerAnimator = GetComponent<AnimController>();
        SpellsScript = GetComponent<Spells>();
        Statistics = GetComponent<StatisticsController>();
        Statistics.DieDelegate += OnDie;
        Cam = Camera.main;

    }

    void Update()
    {
        if(Input.GetMouseButton(0) & !during_attack){

            hit = Mousetarget();

            float dist = Distancetotarget(hit.collider.transform.position);

            if(hit.collider.tag == "Enemy"){
                if(dist <= 3){

                    Agent.velocity = Vector3.zero;
                    Agent.isStopped = true;
                    
                    Agent.ResetPath();
                    hit.transform.gameObject.GetComponent<StatisticsController>().take_PhysicalDamage(Statistics.melee_damage());
                    RotateTowards(hit.transform);
                    meleeAttack();

                }else{

                    Agent.SetDestination(hit.point);
                    PlayerAnimator.Run(true);

                }
            }else if(hit.collider.tag == "PowerTorch"){
                if(dist <= 3){
                    
                    Agent.velocity = Vector3.zero;
                    Agent.ResetPath();
                    hit.transform.gameObject.GetComponent<TorchPowerUp>().StartPickingPower();

                }else{
                    Agent.SetDestination(hit.point);

                }
            }else{

                //Debug.Log(hit.collider.tag);
                Agent.SetDestination(hit.point);
            }

        }

        if(Input.GetKey(KeyCode.Q) & !during_attack){
            if(Statistics.mana_points >= 20){

                Agent.isStopped = true;
                Agent.ResetPath();
                //RotateTowards(hit.transform);
                point = Mousetarget().point;
                Spell1();
            }
        }

        if(Input.GetKey(KeyCode.W) & !during_attack){
            if(Statistics.mana_points >= 60){

                Agent.isStopped = true;
                Agent.ResetPath();
                Spell2();
            }
        }

        if(Input.GetKey(KeyCode.E)  & !during_attack){
            if(Statistics.mana_points >= 30){
                Agent.isStopped = true;
                Agent.ResetPath();
                Spell3();
            }
        }


        if(Agent.velocity.sqrMagnitude > 0){
            PlayerAnimator.Run(true);
        }else{
            PlayerAnimator.Run(false);
        }

        
    }

    private float Distancetotarget(Vector3 _point){
        return Vector3.Distance(transform.position, _point);
    }

    private RaycastHit Mousetarget(){
        MouseRaytarget = Cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(MouseRaytarget, out hit);

        return hit;
    }
    private void RotateTowards (Transform target) {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
            transform.rotation = lookRotation;
    }

    private void Spell1(){
        during_attack = true; 
        SpellsScript.Spell1(point);
    }

    private void Spell2(){
        during_attack = true; 
        SpellsScript.Spell2(transform.position);
    }

    private void Spell3(){
        during_attack = true; 
        SpellsScript.Spell3(transform.position);
    }

    private void meleeAttack(){
        during_attack = true; 
        PlayerAnimator.Attack();
    }

    public void EndAttack(){
        during_attack = false;
        Agent.isStopped = false;
    }


    public void OnDie(){
        during_attack = true;
        Agent.isStopped = true;
        //Debug.Log("delegate works");
        PlayerAnimator.Dead(true);
        Destroy(this,4f);
    }

}
