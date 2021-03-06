using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsControl : MonoBehaviour
{

    public Transform SavesMenu;
    public CanvasGroup Savesbackground;

     public void AnimationStart() {

        Savesbackground.alpha = 0;
        Savesbackground.LeanAlpha(1, 1f);

        SavesMenu.localPosition = new Vector2(0, +Screen.height);
        SavesMenu.LeanMoveLocalY(0, 1f).setEaseOutExpo().delay = 0.1f;
    }

    public void HidePauseMenu() {

        Savesbackground.LeanAlpha(0, 0.5f);
        SavesMenu.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
    }

    void OnComplete(){
        gameObject.SetActive(false);
    }
}
