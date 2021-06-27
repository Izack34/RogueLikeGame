using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavesMenu : MonoBehaviour
{
    // path to folder with saves
    public PopupMainMenu PopUp;
    //syart shold show what saves is empty
    

    public void PopUpAskSave1(){
        PopUp.Askthismethod(LoadSave1, "Load save1?");
    }

    public void PopUpAskSave2(){
        PopUp.Askthismethod(LoadSave2,  "Load save2?");
    }

    public void PopUpAskSave3(){
        PopUp.Askthismethod(LoadSave3,  "Load save3?");
    }

    public void PopUpAskSave4(){
        PopUp.Askthismethod(LoadSave4, "Load save4?");
    }

    public void LoadSave1(){

        LoadingData.SceneNumber = 2;
        //LoadingData.SaveNumber = 1;

        SceneManager.LoadScene(1);
    }

    public void LoadSave2(){
        LoadingData.SceneNumber = 2;
        //LoadingData.SaveNumber = 2;

        SceneManager.LoadScene(1);
    }

    public void LoadSave3(){
        LoadingData.SceneNumber = 2;
        //LoadingData.SaveNumber = 3;

        SceneManager.LoadScene(1);
    }

    public void LoadSave4(){
        LoadingData.SceneNumber = 2;
        //LoadingData.SaveNumber = 4;
        SceneManager.LoadScene(1);
    }
}
