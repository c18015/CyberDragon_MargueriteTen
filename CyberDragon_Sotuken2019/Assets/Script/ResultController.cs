using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    private int counter = 0;
    const int counterMax = 5;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Arrow(Clone)")
        counter++;

        if (counter >= counterMax)
        {
            SceneManager.LoadScene("result");
        }
    }
}
