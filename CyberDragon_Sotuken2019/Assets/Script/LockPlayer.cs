using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayer : MonoBehaviour
{
     GameObject target1;

    // Start is called before the first frame update
    void Start()
    {
        target1 = GameObject.Find("P_Haed");
    }

    // Update is called once per frame
    void Update()
    {
        
     
        // 方向を、回転情報に変換
        Quaternion rotation = Quaternion.LookRotation(target1.transform.position - this.transform.position,Vector3.up);

        rotation.z = 0;
        rotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.1f);
    }
}
