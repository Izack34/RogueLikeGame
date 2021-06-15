using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    //singleton
    private static TooltipSystem tooltipsystem;

    public Tooltip tooltip;
    void Awake()
    {
        tooltipsystem = this;
    }

    // Update is called once per frame
    public static void Show(string content, string title = ""){

        tooltipsystem.tooltip.Settext(content, title );
        tooltipsystem.tooltip.gameObject.SetActive(true);

    }

    public static void Hide(){

        tooltipsystem.tooltip.gameObject.SetActive(false);

    }
}
