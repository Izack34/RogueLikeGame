using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimationEvents : MonoBehaviour
{
   
    [SerializeField]
    private SkeletonController SKControler;

    public void Attackend(){
        SKControler.EndAttack();
    }

}
