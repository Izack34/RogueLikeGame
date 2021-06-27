using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupMainMenu : MonoBehaviour
{
    public GameObject Bg;
    public GameObject AskBox;
    public TextMeshProUGUI  Ask_Text;
    public delegate void SaveDelegate();
    public SaveDelegate saveDelegate;

    private void Start() {
        Bg.SetActive(false);
        AskBox.SetActive(false);
    }

    public void Askthismethod(SaveDelegate AskedMethod, string _text){
        //show Ask box
        Bg.SetActive(true);
        AskBox.SetActive(true);
        Ask_Text.SetText(_text);
        saveDelegate = AskedMethod;
    }

    public void Usemethod(){
        saveDelegate();
        Bg.SetActive(false);
        AskBox.SetActive(false);
    }

    public void Cancelmethod(){
        saveDelegate = null;
        Bg.SetActive(false);
        AskBox.SetActive(false);
        //hide ask box
    }

}
