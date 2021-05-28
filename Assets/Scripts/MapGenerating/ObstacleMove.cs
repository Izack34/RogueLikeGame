using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("move1");

    }
    IEnumerator move1() 
    {
        float elapsedTime = 0;
        while (elapsedTime < 3)
        {
            transform.Translate(Vector3.forward *-3 * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine("move2");
    }

    IEnumerator move2() 
    {
        float elapsedTime = 0;
        while (elapsedTime < 3)
        {
            transform.Translate(Vector3.forward *3 * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine("move1");
    }
}
