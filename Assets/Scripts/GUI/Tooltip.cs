using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI Titletop;

    public TextMeshProUGUI Content;

    public LayoutElement layoutElement;

    public int characterWrapLimit;

    public RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Settext( string contentText, string title = ""){

        if(string.IsNullOrEmpty(title)){
            Titletop.gameObject.SetActive(false);

        }else{
            Titletop.gameObject.SetActive(true);
            Titletop.text = title;

        }

        Content.text = contentText;

        int titleLength = Titletop.text.Length;
        int contentlength = Content.text.Length;

        layoutElement.enabled = (titleLength > characterWrapLimit || contentlength > characterWrapLimit)? true : false;

        
    }

    private void Update() {
        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width; 
        float pivotY = position.y / Screen.width; 

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
    }
}
