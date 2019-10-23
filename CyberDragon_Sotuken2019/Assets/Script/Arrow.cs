using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody Arrow_Rig;
    
    public float speed =  0;
    public GameObject effect = null;
   

    public bool TransPos = true;
    public bool Shot = false;


    void Start()
    {
        TransPos = true;
        //Shot = true;
        Arrow_Rig = this.GetComponent<Rigidbody>();


        //
    }
    // Update is called once per frame
    void Update()
    {
        if (TransPos)
        {
            GameObject target1 = GameObject.Find("ArrowSetPos");
            Transform taget2 = target1.GetComponent<Transform>();

            //Debug.Log(taget2);
            transform.position = taget2.position;
            transform.rotation = taget2.rotation;
        }
       

   
        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            GameObject LhandPas = GameObject.Find("LHandPos");
            GameObject RhandPas = GameObject.Find("RHandPos");
            Vector3 LHP = LhandPas.transform.position;
            Vector3 RHP = RhandPas.transform.position;
            speed = Vector3.Distance(LHP, RHP);
            TransPos = false;

            Shot_qqq();
            





            Destroy(this.gameObject, 30f);
        }

    }

    void Shot_qqq()
    {
        float Power = speed * 2000f;
        Arrow_Rig.AddForce(transform.forward * Power, ForceMode.Force);

        Debug.Log(Power);
        

    }


    void OnCollisionEnter()//オブジェクトに当たるとエフェクト出して弾丸消滅
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
