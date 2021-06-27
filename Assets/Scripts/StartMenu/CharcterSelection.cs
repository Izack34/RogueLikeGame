using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharcterSelection : MonoBehaviour
{
    public PopupMainMenu PopUp;

    public Button Playbutton;
    public Transform HeroShowSpot;
    public GameObject[] Heros;
    public int selectedHero = 0;
    private void Start() {
        Playbutton.interactable = false;
    }

    public void SelectPaladin(){
        Playbutton.interactable = true;
        Heros[selectedHero].SetActive(false);
        Heros[0].SetActive(true);
        selectedHero = 0;
    }

    public void SelectHero2(){
        Playbutton.interactable = false;
        Heros[selectedHero].SetActive(false);
        Heros[1].SetActive(true);
        selectedHero = 1;
    }

    public void SelectHero3(){
        Playbutton.interactable = false;
        Heros[selectedHero].SetActive(false);
        Heros[2].SetActive(true);
        selectedHero = 2;
    }

    public void StartGame(){
        LoadingData.HeroIndentificator = selectedHero;
        LoadingData.SceneNumber = 2;
        SceneManager.LoadScene(1);
    }
}
