using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPowerUp : MonoBehaviour
{
    public CanvasMenu menu;

    private Collider BoxCollider;

    public ParticleSystem RingParticle1, RingParticle2; 
                        //Blueballparticle1, Blueballparticle2, Blueballparticle3, Blueballparticle4;

    public GameObject Blueballparticle;


    private void Start() {

        //turn off collider
        BoxCollider = GetComponent<Collider>();
        StartCoroutine("TorchParticleCorutine");
    }
    private void PlayRingParticle(){
        RingParticle1.Play();
        RingParticle2.Play();
    }

    /*private void StopBlueBallParticle(){
        Blueballparticle1.Stop();
        Blueballparticle1.Stop();
        Blueballparticle1.Stop();
        Blueballparticle1.Stop();
    }*/

    IEnumerator TorchParticleCorutine(){
        while (true){
            yield return new WaitForSeconds(5);
            PlayRingParticle();
        }
    }

    public void StartPickingPower()
    {
        BoxCollider.enabled = false;
        menu.ShowPowers();
        TurnoffTorch();
        
    }

    private void TurnoffTorch(){
        StopCoroutine("TorchParticleCorutine");
        Blueballparticle.SetActive(false);
    }
}
