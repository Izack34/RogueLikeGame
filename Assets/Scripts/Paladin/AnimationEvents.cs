using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    //used in animations
    [SerializeField]
    private PlayerControler PlayerControler;

    [SerializeField]
    private Spells spellbook;

    public void Spell1activate(){
        spellbook.UselightShock();
    }

    public void Spell1end(){
        PlayerControler.EndAttack();
    }

    public void Spell2activate(){
        spellbook.UseRevelation();
    }

    public void Spell2end(){
        PlayerControler.EndAttack();
    }

    public void Spell3activate(){
        spellbook.UseLightexplode();
    }

    public void Spell3end(){
        PlayerControler.EndAttack();
    }

    public void AAend(){
        PlayerControler.EndAttack();
    }
}
