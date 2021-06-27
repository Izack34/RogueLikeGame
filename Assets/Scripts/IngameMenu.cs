using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IngameMenu : MonoBehaviour
{
    public void OpenOptions(){
        Debug.Log("options");
    }

    public void BacktoMainMenu(){
        Time.timeScale = 1;

        LoadingData.SceneNumber = 0;

        SceneManager.LoadScene(1);
    }
}
