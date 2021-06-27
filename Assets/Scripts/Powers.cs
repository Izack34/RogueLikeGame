using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerClass{
    public string AboutPower;
    
    public Sprite PictureOfPower; 
    public delegate void PowerUpsClass(int _amount);

    public List<PowerUpsClass> PowerListofClass = new List<PowerUpsClass>();
    public List<int> PowerAmount = new List<int>();
}

public class Powers : MonoBehaviour
{
    public Image ImageOfPower1, ImageOfPower2, ImageOfPower3;

    public TextMeshProUGUI Aboutpower1, Aboutpower2, Aboutpower3;

    public Sprite[] PictureOfPower; 
    delegate void PowerUps(int _amount);
    private PowerClass[] ArrayOfPowers = new PowerClass[6];

    //List<PowerUps> PowerList = new List<PowerUps>();
    //delegate void PowerUps(int num);
    List <PowerClass.PowerUpsClass> Powerup1;
    List <PowerClass.PowerUpsClass> Powerup2;
    List <PowerClass.PowerUpsClass> Powerup3;

    List <int> PowerAmount1, PowerAmount2, PowerAmount3;
    public CanvasMenu menu;

    private Modifiers PlayerMoifications;
    private void Awake() {
        GameObject Player = GameObject.FindWithTag("Player");
        PlayerMoifications = Player.GetComponent<Modifiers>();

        Createlist();
    }

    void Createlist(){
        Debug.Log("start creating powers");
        PowerClass add10_str_lose_5Int = new PowerClass();
        add10_str_lose_5Int.AboutPower = "add 10 str but you lose 5 int";
        add10_str_lose_5Int.PictureOfPower = PictureOfPower[2];
        add10_str_lose_5Int.PowerListofClass.Add(PlayerMoifications.Addstrength);
        add10_str_lose_5Int.PowerAmount.Add(10);
        add10_str_lose_5Int.PowerListofClass.Add(PlayerMoifications.Addinteligence);
        add10_str_lose_5Int.PowerAmount.Add(-5);

        ArrayOfPowers[0] = add10_str_lose_5Int;

        PowerClass add5_Agi = new PowerClass();
        add5_Agi.AboutPower = "add 5 agilty";
        add5_Agi.PictureOfPower = PictureOfPower[4];
        add5_Agi.PowerListofClass.Add(PlayerMoifications.Addagility);
        add5_Agi.PowerAmount.Add(5);

        ArrayOfPowers[1] = add5_Agi;

        PowerClass add10_int = new PowerClass();
        add10_int.AboutPower = "add 10 inteligance";
        add10_int.PictureOfPower = PictureOfPower[4];
        add10_int.PowerListofClass.Add(PlayerMoifications.Addinteligence);
        add10_int.PowerAmount.Add(10);

        ArrayOfPowers[2] = add10_int;

        PowerClass add10_str_lose_5_agi = new PowerClass();
        add10_str_lose_5_agi.AboutPower = "add 10 str but you lose 5 agi";
        add10_str_lose_5_agi.PictureOfPower = PictureOfPower[5];
        add10_str_lose_5_agi.PowerListofClass.Add(PlayerMoifications.Addstrength);
        add10_str_lose_5_agi.PowerAmount.Add(10);
        add10_str_lose_5_agi.PowerListofClass.Add(PlayerMoifications.Addagility);
        add10_str_lose_5_agi.PowerAmount.Add(-5);

        ArrayOfPowers[3] = add10_str_lose_5_agi;

        PowerClass add5_agi_lose_5_str = new PowerClass();
        add5_agi_lose_5_str.AboutPower = "add 5 agility but you lose 5 int";
        add5_agi_lose_5_str.PictureOfPower = PictureOfPower[6];
        add5_agi_lose_5_str.PowerListofClass.Add(PlayerMoifications.Addagility);
        add5_agi_lose_5_str.PowerAmount.Add(10);
        add5_agi_lose_5_str.PowerListofClass.Add(PlayerMoifications.Addinteligence);
        add5_agi_lose_5_str.PowerAmount.Add(-5);

        ArrayOfPowers[4] = add5_agi_lose_5_str;

        PowerClass add15_str_lose_5_agi_int = new PowerClass();
        add15_str_lose_5_agi_int.AboutPower = "add 15 str but you lose 5 int and 5 agility";
        add15_str_lose_5_agi_int.PictureOfPower = PictureOfPower[7];
        add15_str_lose_5_agi_int.PowerListofClass.Add(PlayerMoifications.Addstrength);
        add15_str_lose_5_agi_int.PowerAmount.Add(15);
        add15_str_lose_5_agi_int.PowerListofClass.Add(PlayerMoifications.Addagility);
        add15_str_lose_5_agi_int.PowerAmount.Add(-5);
        add15_str_lose_5_agi_int.PowerListofClass.Add(PlayerMoifications.Addinteligence);
        add15_str_lose_5_agi_int.PowerAmount.Add(-5);

        ArrayOfPowers[5] = add5_agi_lose_5_str;

        /*PowerClass k = new PowerClass();
        k.AboutPower = "add 10 str but you lose 5 int";
        k.PowerListofClass.Add(PlayerMoifications.Addagility(3));

        ArrayOfPowers.Append(k);

        PowerClass k = new PowerClass();
        k.AboutPower = "add 10 str but you lose 5 int";
        k.PowerListofClass.Add(PlayerMoifications.Addagility(3));

        ArrayOfPowers.Append(k);

        PowerClass k = new PowerClass();
        k.AboutPower = "add 10 str but you lose 5 int";
        k.PowerListofClass.Add(PlayerMoifications.Addagility(3));

        ArrayOfPowers.Append(k);

        PowerClass k = new PowerClass();
        k.AboutPower = "add 10 str but you lose 5 int";
        k.PowerListofClass.Add(PlayerMoifications.Addagility(3));

        ArrayOfPowers.Append(k);*/

        //PowerList.Add(PowerUPStrength);
        //PowerList.Add(PowerUPAGility);
        //PowerList.Add(PowerUPIntelect);
        //PowerList.Add(PlayerMoifications.Addagility);
        //PowerList.Add(PlayerMoifications.Addstrength);
        //PowerList.Add(PlayerMoifications.Addinteligence);
        //Debug.Log(PowerList.Count);
    }

    //powers

    /*private void PowerUPStrength(){
        

        PlayerMoifications.Addagility(5);
        PlayerMoifications.Addstrength(5);
        //
    }

    private void PowerUPAGility(){
        PlayerMoifications.Addagility(5);
        //
    }

    private void PowerUPIntelect(){
        PlayerMoifications.Addinteligence(5);
        //
    }*/


    public void SelectrandomPowers(){
    
        int n0 = Random.Range(0, ArrayOfPowers.Length);
        int n1;
        int n2;

        n1 = Random.Range(0, ArrayOfPowers.Length);
        while(n1 == n0){
            n1 = Random.Range(0, ArrayOfPowers.Length);
        }

        n2 = Random.Range(0, ArrayOfPowers.Length);
        while(n0 == n2 ^ n1 == n2){
            n2 = Random.Range(0, ArrayOfPowers.Length);
        }
        //Debug.Log(n0);
        //Debug.Log(n1);
        //Debug.Log(n2);

        //odwaołanie do buttonów i tekstów
        Aboutpower1.SetText(ArrayOfPowers[n0].AboutPower);
        Aboutpower2.SetText(ArrayOfPowers[n1].AboutPower);
        Aboutpower3.SetText(ArrayOfPowers[n2].AboutPower);

        ImageOfPower1.sprite = ArrayOfPowers[n0].PictureOfPower;
        ImageOfPower2.sprite = ArrayOfPowers[n1].PictureOfPower;
        ImageOfPower3.sprite = ArrayOfPowers[n2].PictureOfPower;

        Powerup1 = ArrayOfPowers[n0].PowerListofClass;
        Powerup2 = ArrayOfPowers[n1].PowerListofClass;
        Powerup3 = ArrayOfPowers[n2].PowerListofClass;

        PowerAmount1 = ArrayOfPowers[n0].PowerAmount;
        PowerAmount2 = ArrayOfPowers[n1].PowerAmount;
        PowerAmount3 = ArrayOfPowers[n2].PowerAmount;

        //Debug.Log(PowerAmount1.Count);
        //Debug.Log(PowerAmount2.Count);
        //Debug.Log(ArrayOfPowers[n2].PowerAmount.Count);
    }

    public void Power1button(){

        int i = 0;
        foreach (var action in Powerup1)
        {
            //Debug.Log(PowerAmount1);
            action(PowerAmount1[i]);
            i+=1;
        }
        menu.hidePowers();
    }

    public void Power2button(){

        int i = 0;
        foreach (var action in Powerup2)
        {
            //Debug.Log(PowerAmount2[i]);
            action(PowerAmount2[i]);
            i+=1;
        }
        menu.hidePowers();
    }

    public void Power3button(){

        int i = 0;
        foreach (var action in Powerup3)
        {
            // Debug.Log(PowerAmount3[i]);
            action(PowerAmount3[i]);
            i+=1;
        }

        menu.hidePowers();
    }

}
