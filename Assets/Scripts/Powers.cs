using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class Powers : MonoBehaviour
{
    //[SerializeField]
    public PowersContainer data;
    public Image ImageOfPower1, ImageOfPower2, ImageOfPower3;

    public TextMeshProUGUI Aboutpower1, Aboutpower2, Aboutpower3;
 
    delegate void PowerUps(int _amount);
    

    int[] PowerAmount1 = new int[12],
         PowerAmount2 = new int[12], 
         PowerAmount3 = new int[12];
    public CanvasMenu menu;

    private StatisticsController PlayerMoifications;
    private void Awake() {
        GameObject Player = GameObject.FindWithTag("Player");
        PlayerMoifications = Player.GetComponent<StatisticsController>();

    }


    public void SelectrandomPowers(){
    
        int n0 = Random.Range(0, data.PowersData.Count);
        int n1;
        int n2;

        n1 = Random.Range(0, data.PowersData.Count);
        while(n1 == n0){
            n1 = Random.Range(0, data.PowersData.Count);
        }

        n2 = Random.Range(0, data.PowersData.Count);
        while(n0 == n2 ^ n1 == n2){
            n2 = Random.Range(0, data.PowersData.Count);
        }
        //Debug.Log(n0);
        //Debug.Log(n1);
        //Debug.Log(n2);

        //odwaołanie do buttonów i tekstów
        Aboutpower1.SetText(data.PowersData[n0].content);
        Aboutpower2.SetText(data.PowersData[n1].content);
        Aboutpower3.SetText(data.PowersData[n2].content);

        ImageOfPower1.sprite = data.PowersData[n0].PictureOfPower;
        ImageOfPower2.sprite = data.PowersData[n1].PictureOfPower;
        ImageOfPower3.sprite = data.PowersData[n2].PictureOfPower;

        //zapisanie wartosci do tablicy używanej w funkcji ModificationToStats
        PowerAmount1[0] = data.PowersData[n0].MODMax_health;
        PowerAmount1[1] = data.PowersData[n0].MODMax_mana;
        PowerAmount1[2] = data.PowersData[n0].MODCrit_chance;
        PowerAmount1[3] = data.PowersData[n0].MODFire_resistance;
        PowerAmount1[4] = data.PowersData[n0].MODFrost_resistance;
        PowerAmount1[5] = data.PowersData[n0].MODLightning_resistance;
        PowerAmount1[6] = data.PowersData[n0].MODDark_resistance;
        PowerAmount1[7] = data.PowersData[n0].MODHealthRateRegen;
        PowerAmount1[8] = data.PowersData[n0].MODManaRateRegen;
        PowerAmount1[9] = data.PowersData[n0].MODStrength;
        PowerAmount1[10] = data.PowersData[n0].MODAgility;
        PowerAmount1[11] = data.PowersData[n0].MODInteligence;

        PowerAmount2[0] = data.PowersData[n1].MODMax_health;
        PowerAmount2[1] = data.PowersData[n1].MODMax_mana;
        PowerAmount2[2] = data.PowersData[n1].MODCrit_chance;
        PowerAmount2[3] = data.PowersData[n1].MODFire_resistance;
        PowerAmount2[4] = data.PowersData[n1].MODFrost_resistance;
        PowerAmount2[5] = data.PowersData[n1].MODLightning_resistance;
        PowerAmount2[6] = data.PowersData[n1].MODDark_resistance;
        PowerAmount2[7] = data.PowersData[n1].MODHealthRateRegen;
        PowerAmount2[8] = data.PowersData[n1].MODManaRateRegen;
        PowerAmount2[9] = data.PowersData[n1].MODStrength;
        PowerAmount2[10] = data.PowersData[n1].MODAgility;
        PowerAmount2[11] = data.PowersData[n1].MODInteligence;

        PowerAmount3[0] = data.PowersData[n2].MODMax_health;
        PowerAmount3[1] = data.PowersData[n2].MODMax_mana;
        PowerAmount3[2] = data.PowersData[n2].MODCrit_chance;
        PowerAmount3[3] = data.PowersData[n2].MODFire_resistance;
        PowerAmount3[4] = data.PowersData[n2].MODFrost_resistance;
        PowerAmount3[5] = data.PowersData[n2].MODLightning_resistance;
        PowerAmount3[6] = data.PowersData[n2].MODDark_resistance;
        PowerAmount3[7] = data.PowersData[n2].MODHealthRateRegen;
        PowerAmount3[8] = data.PowersData[n2].MODManaRateRegen;
        PowerAmount3[9] = data.PowersData[n2].MODStrength;
        PowerAmount3[10] = data.PowersData[n2].MODAgility;
        PowerAmount3[11] = data.PowersData[n2].MODInteligence;

    }

    public void Power1button(){

        PlayerMoifications.ModificationToStats(PowerAmount1);
        menu.hidePowers();
    }

    public void Power2button(){

        PlayerMoifications.ModificationToStats(PowerAmount2);
        menu.hidePowers();
    }

    public void Power3button(){

        PlayerMoifications.ModificationToStats(PowerAmount3);
        menu.hidePowers();
    }

}
