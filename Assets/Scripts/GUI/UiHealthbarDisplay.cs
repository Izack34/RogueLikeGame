using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthbarDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private StatisticsController Statistics;
    [SerializeField]
    private GameObject HealthBar;

    [SerializeField]
    private GameObject BgBar;
    private Image HPBar;
    private bool turnOn = false;
    void Start()
    {
        
        HPBar = HealthBar.GetComponent<Image>();
        //HealthBar = GetComponent<Image>();
        BgBar.SetActive(false);
        HealthBar.SetActive(false);
    }

    
    void Update()
    {
        if(turnOn){
            HPBar.fillAmount = (float)Statistics.health_points/(float)Statistics.max_health;
        }
       
    }
    void LateUpdate()
    {
        if(Statistics.health_points != Statistics.max_health & !turnOn){
            turnOn = true;
            BgBar.SetActive(true);
            HealthBar.SetActive(true);
        }
        //Camera.main.transform
        transform.LookAt(transform.position - new Vector3(-13,-13,0f));
    }
}
