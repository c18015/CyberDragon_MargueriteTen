using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKETU : MonoBehaviour
{
    float LRhandPos;
    Transform myTransform;


    void Start()
    {
        myTransform = this.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject LhandPas = GameObject.Find("LHandPos");
        GameObject RhandPas = GameObject.Find("RHandPos");
        Vector3 LHP = LhandPas.transform.position;
        Vector3 RHP = RhandPas.transform.position;
        LRhandPos = Vector3.Distance(LHP, RHP);


        Vector3 worldPos = myTransform.position;
        worldPos.x = LRhandPos / -1;

        myTransform.position = worldPos;
    }
}
