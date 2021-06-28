using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarMenuControl : MonoBehaviour
{   
    public MainMenuCamera MainCamera;
    public GameObject menuObject;
    public menuControl menuAnim;
    public GameObject CharacterSelectionObject;
    public savesControl CharacterSelectionAnim;
    public GameObject OptionsObject;
    public optionsControl optionsaAnim;
    public GameObject QuicktutorialObject;
    public QuickTutorialControl QuickTutorialAnim;


    private void Start() {
        menuObject.SetActive(true);
        menuAnim.AnimationStart();
    }

    public void OpenSaves(){
        menuAnim.HidePauseMenu();
        CharacterSelectionObject.SetActive(true);
        CharacterSelectionAnim.AnimationStart();
        MainCamera.moveToChoseCharacterLook();
    }

    public void StartPlay(){
        menuAnim.HidePauseMenu();
        CharacterSelectionObject.SetActive(true);
        CharacterSelectionAnim.AnimationStart();
    }

    public void ShowOptions(){
        menuAnim.HidePauseMenu();
        OptionsObject.SetActive(true);
        optionsaAnim.AnimationStart();
    }

    public void ShowQuicktutorial(){
        menuAnim.HidePauseMenu();
        QuicktutorialObject.SetActive(true);
        QuickTutorialAnim.AnimationStart();
    }


    public void backtoMainMenufromSaves(){
        CharacterSelectionAnim.HidePauseMenu();
        menuObject.SetActive(true);
        menuAnim.AnimationStart();
        MainCamera.moveToStartLook();
    }

    public void backtoMainMenufromOptions(){
        optionsaAnim.HidePauseMenu();
        menuObject.SetActive(true);
        menuAnim.AnimationStart();
    }
    
    public void backtoMainMenufromQuicktutorial(){
        QuickTutorialAnim.HidePauseMenu();
        menuObject.SetActive(true);
        menuAnim.AnimationStart();
    }

    public void ExitAplication(){
        Application.Quit();
    }


    
}
