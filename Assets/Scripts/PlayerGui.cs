using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGui : MonoBehaviour
{
    [SerializeField]
    private StatisticsController Statistics;
    
    [SerializeField]
    private Image HealthBar;

    [SerializeField]
    private Image ManaBar;

    // Update is called once per frame
     void Update()
    {
        HealthBar.fillAmount = (float)Statistics.health_points/(float)Statistics.max_health;
        ManaBar.fillAmount = (float)Statistics.mana_points/(float)Statistics.max_mana;
    }
}
