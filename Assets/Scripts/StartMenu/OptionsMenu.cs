using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public PopupMainMenu PopUp;
    //here seves options

    public void PopUpAskApply(){
        PopUp.Askthismethod(ApplyOptions, "Apply new options?");
    }

    public void ApplyOptions(){
        Debug.Log("options saved");
    }
}
