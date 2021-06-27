using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    float elapsedTime = 0;

    public float animationTime = 10;

    private Quaternion StartRotation;
    private Vector3 Starposition;
    public Transform StartLook;
    public Transform ChoseCharacterLook;

    public void moveToStartLook(){
        Starposition = transform.position;
        StartRotation = transform.rotation;
        elapsedTime = 0;
        StartCoroutine("toStartLook");
    }
    IEnumerator toStartLook(){
        while (elapsedTime <= animationTime)
        {
            transform.position = Vector3.Lerp(Starposition, StartLook.position , (elapsedTime / animationTime));
            transform.rotation = Quaternion.Slerp(StartRotation, StartLook.rotation, (elapsedTime / animationTime));

            elapsedTime += Time.deltaTime;
        
            // Yield here
            yield return null;
        } 
    }

    public void moveToChoseCharacterLook(){
        Starposition = transform.position;
        StartRotation = transform.rotation;
        elapsedTime = 0;
        StartCoroutine("toChoseCharacterLook");
    }

    IEnumerator toChoseCharacterLook(){
        while (elapsedTime <= animationTime)
        {
            transform.position = Vector3.Lerp(Starposition, ChoseCharacterLook.position , (elapsedTime / animationTime));
            transform.rotation = Quaternion.Slerp(StartRotation, ChoseCharacterLook.rotation, (elapsedTime / animationTime));

            elapsedTime += Time.deltaTime;
        
            // Yield here
            yield return null;
        } 
        
    }
}
