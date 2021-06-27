using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenu : MonoBehaviour
{
    private PlayerControler PlayerScript;
    public GameObject BackGround;
    public GameObject powers;
    public GameObject InGameMenu;
    public GameObject CharacterInfo;

    private bool isOpen = false;

    private void Start() {
        GameObject Player = GameObject.FindWithTag("Player");
        //used to block action when menu is open
        PlayerScript = Player.GetComponent<PlayerControler>();
    }

    private void Update() {
        if(Input.GetKey(KeyCode.Escape)){
            if(!isOpen){
                ShowInMenu();
            }
        }    
        if(Input.GetKey(KeyCode.C)){
            if(!isOpen){
                ShowCharacterInfo();
            }
        }    
    }

    public void ShowPowers(){
        BackGround.SetActive(true);
        powers.SetActive(true);
        isOpen = true;
        PlayerScript.during_attack = true;
        Time.timeScale = 0;
        powers.GetComponent<Powers>().SelectrandomPowers();
    }

    public void hidePowers(){
        powers.SetActive(false);
        BackGround.SetActive(false);
        isOpen = false;
        PlayerScript.during_attack = false;
        Time.timeScale = 1;
    }

    public void ShowInMenu(){
        InGameMenu.SetActive(true);
        BackGround.SetActive(true);
        isOpen = true;
        PlayerScript.during_attack = true;
        Time.timeScale = 0;
    }

    public void hideInGameMenu(){
        InGameMenu.SetActive(false);
        BackGround.SetActive(false);
        isOpen = false;
        PlayerScript.during_attack = false;
        Time.timeScale = 1;
    }

    public void ShowCharacterInfo(){
        CharacterInfo.SetActive(true);
        BackGround.SetActive(true);
        isOpen = true;
        PlayerScript.during_attack = true;
        Time.timeScale = 0;
    }

    public void hideCharacterInfo(){
        CharacterInfo.SetActive(false);
        BackGround.SetActive(false);
        isOpen = false;
        PlayerScript.during_attack = false;
        Time.timeScale = 1;
    }
}
