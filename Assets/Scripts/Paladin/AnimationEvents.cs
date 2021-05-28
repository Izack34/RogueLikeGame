using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    //used in animations
    [SerializeField]
    private PlayerControler PlayerControler;

    public void Spell1activate(){
        PlayerControler.UselightShock();
    }

    public void Spell1end(){
        PlayerControler.EndAttack();
    }

    public void Spell2activate(){
        PlayerControler.UseRevelation();
    }

    public void Spell2end(){
        PlayerControler.EndAttack();
    }

    public void Spell3activate(){
        PlayerControler.UseLightexplode();
    }

    public void Spell3end(){
        PlayerControler.EndAttack();
    }

    public void AAend(){
        PlayerControler.EndAttack();
    }
}
