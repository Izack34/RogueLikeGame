using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadaScene : MonoBehaviour
{
    [SerializeField]
    private Image ProgrresBar;
    private void Start() {
        if(LoadingData.SceneNumber != null){
            StartCoroutine(LoadAsyncOperation());
        }
        //else to return
    }

    IEnumerator LoadAsyncOperation(){
        

        AsyncOperation Loadingscene = SceneManager.LoadSceneAsync(LoadingData.SceneNumber);
        
        while(Loadingscene.progress < 1){
            ProgrresBar.fillAmount = Loadingscene.progress;

            yield return new WaitForEndOfFrame();
        }
        
        yield return new WaitForSeconds(1);
        yield return new WaitForEndOfFrame();
    }

}
