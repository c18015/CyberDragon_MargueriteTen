using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float PHP = 10f;
    
    void Start()
    {

    }

    
    void Update()
    {
        if(PHP <= 0)
        {
            Debug.Log("お前はもう、死んでいる");
        }
    }

    void OnTriggerStay(Collider collider)
    {

        if (collider.gameObject.tag == "Damage" && OVRInput.Get(OVRInput.RawButton.LIndexTrigger))//右、もしくは左人差し指トリガーを押した時
        {
            PHP -= 1f;
        }
    }
}
