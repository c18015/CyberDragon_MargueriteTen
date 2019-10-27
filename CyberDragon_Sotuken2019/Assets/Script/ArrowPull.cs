using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPull : MonoBehaviour
{
    public Transform R_HandPos = null;
    Transform MyPos = null;
    Transform LockPos = null;

    void Start()
    {
        MyPos = this.transform;
        LockPos = this.transform;
    }

    
    void Update()
    {
        Debug.Log(MyPos);

        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            

            GameObject LhandPas = GameObject.Find("LHandPos");
            GameObject RhandPas = GameObject.Find("RHandPos");
            Vector3 LHP = LhandPas.transform.position;
            Vector3 RHP = RhandPas.transform.position;
            float PullPos = Vector3.Distance(LHP, RHP);
            /*
            Vector3 Pos = MyPos.position;
            Pos.x -= PullPos * 10;

            MyPos.position = Pos;
            */
        }

        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            this.transform.position = LockPos.position;
            this.transform.rotation = LockPos.rotation;

            MyPos = LockPos;
        }
            
    }
            
}
