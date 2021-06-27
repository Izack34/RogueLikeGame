using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharcterSelection : MonoBehaviour
{
    public PopupMainMenu PopUp;

    public Transform HeroShowSpot;
    public GameObject[] Heros;
    public int selectedHero = 0;
    
    public void SelectPaladin(){
        Heros[selectedHero].SetActive(false);
        Heros[0].SetActive(true);
        selectedHero = 0;
    }

    public void SelectHero2(){
        Heros[selectedHero].SetActive(false);
        Heros[1].SetActive(true);
        selectedHero = 1;
    }

    public void SelectHero3(){
        Heros[selectedHero].SetActive(false);
        Heros[2].SetActive(true);
        selectedHero = 2;
    }

    public void StartGame(){
        LoadingData.HeroIndentificator = selectedHero;
        LoadingData.SceneNumber = 3;
        SceneManager.LoadScene(1);
    }
}
