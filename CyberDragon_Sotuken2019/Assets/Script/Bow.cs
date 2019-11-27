using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject Arrow = null;
    public GameObject KaRiArrow;
    public GameObject Test;
    public Transform L_HandPos = null;
    Vector3 MyVelocity;
    float CoolTime;
    public float TimeS;
    float ArrowPower = 0f;

    bool ArrowInst;
    bool HandCheck;

    void Start()
    {
        KaRiArrow.SetActive(false);
        ArrowInst = true;
        HandCheck = false;
    }
    
    void Update()
    {
        TimeS += Time.deltaTime;
        if (TimeS <= 1.0f)
        {
            ArrowInst = true;
        }
        

        if (ArrowInst && HandCheck && OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            ArrowInstantiate();
            KaRiArrow.SetActive(false);
            ArrowInst = false;
            /*
            GameObject LhandPas = GameObject.Find("LHandPos");
            GameObject RhandPas = GameObject.Find("RHandPos");
            Vector3 LHP = LhandPas.transform.position;
            Vector3 RHP = RhandPas.transform.position;
            ArrowPower = Vector3.Distance(LHP, RHP);

            ArrowPower /= 3000f;*/
        }

        if (OVRInput.Get(OVRInput.RawButton.LHandTrigger))
        {
            transform.position = L_HandPos.position;
            transform.rotation = L_HandPos.rotation;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "RHand" && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && ArrowInst)
        {
            KaRiArrow.SetActive(true);
            HandCheck = true;


        }
    }

    void ArrowInstantiate()
    {
        Instantiate(
            Arrow,
            KaRiArrow.transform.position,
            KaRiArrow.transform.rotation);

        
        /*
        var bulletInstance = Instantiate<GameObject>(Arrow, KaRiArrow.transform.position, KaRiArrow.transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * ArrowPower);
        Destroy(bulletInstance, 10f);*/

        TimeS = 0;
        HandCheck = false;
    }  
}

