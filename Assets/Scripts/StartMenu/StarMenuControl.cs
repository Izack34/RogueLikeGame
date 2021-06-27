using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarMenuControl : MonoBehaviour
{   
    public MainMenuCamera MainCamera;
    public GameObject menuObject;
    public menuControl menuAnim;
    public GameObject SaveObject;
    public savesControl saveAnim;
    public GameObject OptionsObject;
    public optionsControl optionsaAnim;

    private void Start() {
        menuObject.SetActive(true);
        menuAnim.AnimationStart();
    }

    public void OpenSaves(){
        menuAnim.HidePauseMenu();
        SaveObject.SetActive(true);
        saveAnim.AnimationStart();
        MainCamera.moveToChoseCharacterLook();
    }

    public void StartPlay(){
        menuAnim.HidePauseMenu();
        SaveObject.SetActive(true);
        saveAnim.AnimationStart();
    }

    public void ShowOptions(){
        menuAnim.HidePauseMenu();
        OptionsObject.SetActive(true);
        optionsaAnim.AnimationStart();
    }

    public void backtoMainMenufromSaves(){
        saveAnim.HidePauseMenu();
        menuObject.SetActive(true);
        menuAnim.AnimationStart();
        MainCamera.moveToStartLook();
    }

    public void backtoMainMenufromOptions(){
        optionsaAnim.HidePauseMenu();
        menuObject.SetActive(true);
        menuAnim.AnimationStart();
    }
    
    public void ExitAplication(){
        Application.Quit();
    }


    
}
