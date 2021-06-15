using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltiptrigger : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{

    //private static LTDescr delay;
    public string content;
    public string title;

    public void updatetext(string _content, string _title = ""){
        content = _content;
        title = _title;
    }

    public void OnPointerEnter(PointerEventData eventData){
        //delay = LeanTween.delayedCall(0.3f, ()=>
        //{
            TooltipSystem.Show(content , title);
        //});
        
    }

    public void OnPointerExit(PointerEventData eventData){
        //LeanTween.cancel(delay.uniqueId);
        TooltipSystem.Hide();
    
    }
}
