using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject Arrow = null;
    public Transform L_HandPos = null;
    public Vector3 MyVelocity;
    public float CoolTime;


    bool ArrowInst = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame     collider.gameObject.tag == "Hand" && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || 
    void Update()
    {

        
        if (ArrowInst)
        {
            CoolTime = 0;
            ArrowInstantiate();
            
        }

        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            ArrowInst = false;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        /*if(collider.gameObject.tag == "Hand")
        {
            Debug.Log("OnCollideeeeeeeeeer!!!!");
        }*/

        if (collider.gameObject.tag == "LHand" && OVRInput.Get(OVRInput.RawButton.LIndexTrigger))//右、もしくは左人差し指トリガーを押した時
        {
            transform.position = L_HandPos.position;
            transform.rotation = L_HandPos.rotation;//Quaternion.Euler(HandPos.rotation.x, -90 ,HandPos.rotation.z);
        }

        if (collider.gameObject.tag == "RHand" && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            ArrowInst = true;
        }
    }

    void ArrowInstantiate()
    {
        Instantiate(
            Arrow,
            this.transform.position,
            this.transform.rotation);

        CoolTime += Time.deltaTime;
        if (CoolTime <= 2f)
        {
            ArrowInst = false;
        }
            //Debug.Log("矢を生み出した");
    }
        
}

