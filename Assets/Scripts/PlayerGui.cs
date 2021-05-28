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

    [SerializeField]
    private GameObject EnemyBar;

    [SerializeField]
    private Image EnemyHpBar;

    private StatisticsController EnemyStats;

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = (float)Statistics.health_points/(float)Statistics.max_health;
        ManaBar.fillAmount = (float)Statistics.mana_points/(float)Statistics.max_mana;
        if(EnemyStats != null){
            EnemyHpBar.fillAmount = (float)EnemyStats.health_points/(float)EnemyStats.max_health;
        }
    }

    public void ShowEnemyHP(StatisticsController Stats){
        EnemyBar.SetActive(true);
        EnemyStats = Stats;
    }

    public void EndShowEnemyHP(){
        EnemyBar.SetActive(false);
        EnemyStats = null;
    }

}
