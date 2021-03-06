using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGui : MonoBehaviour
{
    private StatisticsController Statistics;
    
    [SerializeField]
    private Image HealthBar;

    [SerializeField]
    private Image ManaBar;

    [SerializeField]
    private GameObject EnemyBar;

    [SerializeField]
    private Image EnemyHpBar;

    [SerializeField]
    private Image SkillQimage;

    [SerializeField]
    private GameObject SkillWimage;

    [SerializeField]
    private Image SkillEimage;
    private StatisticsController EnemyStats;
    private TooltipUpdate TTupdate;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    

    private void Start() {
        TTupdate = GetComponent<TooltipUpdate>();
        GameObject Player = GameObject.FindWithTag("Player");
        Statistics = Player.GetComponent<StatisticsController>();
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    
    void Update()
    {
        HealthBar.fillAmount = (float)Statistics.health_points/(float)Statistics.max_health;
        ManaBar.fillAmount = (float)Statistics.mana_points/(float)Statistics.max_mana;
        if(EnemyStats != null){
            EnemyHpBar.fillAmount = (float)EnemyStats.health_points/(float)EnemyStats.max_health;
        }
        TTupdate.updateManaHealthBar(Statistics.health_points, Statistics.max_health, 
                                    Statistics.mana_points, Statistics.max_mana);
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
