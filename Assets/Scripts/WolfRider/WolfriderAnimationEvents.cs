using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfriderAnimationEvents : MonoBehaviour
{
    [SerializeField]
    private WolfRiderControler WolfRiderControler;

    public void Attackend(){
        Debug.Log("wykonana");
        WolfRiderControler.EndAttack();
    }

}
