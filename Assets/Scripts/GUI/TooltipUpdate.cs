using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipUpdate : MonoBehaviour
{
    public Tooltiptrigger Healthbar;
    public Tooltiptrigger Manabar;
    public Tooltiptrigger SkillQ;
    public Tooltiptrigger SkillW;
    public Tooltiptrigger SkillE;

    public void updateManaHealthBar(int Currenthp, int Maxhp, int CurrentMana, int MaxMana ){
        Healthbar.updatetext(Currenthp+"/" + Maxhp);
        Manabar.updatetext(CurrentMana+"/" + MaxMana);
    }
 
    public void updateSkill(){
        
    }
}
