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


    bool ArrowInst = false;

    void Start()
    {
        KaRiArrow.SetActive(false);
    }

    // Update is called once per frame     collider.gameObject.tag == "Hand" && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || 
    void Update()
    {
        
        TimeS += Time.deltaTime;

        Debug.Log("TimesS"+TimeS);
       
        if (TimeS <= 1.0f)
        {
            ArrowInst = true;
            Debug.Log("OOKK");
        }
        

        if (ArrowInst && OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger)|| ArrowInst && Input.GetKeyDown(KeyCode.A))
        {
            
            ArrowInstantiate();
            
        }

        if (OVRInput.Get(OVRInput.RawButton.LHandTrigger))
        {
            transform.position = L_HandPos.position;
            transform.rotation = L_HandPos.rotation;
        }
        
        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            KaRiArrow.SetActive(false);
        }
    }

    void OnTriggerStay(Collider collider)
    {

        if (collider.gameObject.tag == "RHand" && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            KaRiArrow.SetActive(true);
            
        }
    }

    void ArrowInstantiate()
    {
        //Debug.Log("インスタント");

        Instantiate(
            Arrow,
            KaRiArrow.transform.position,
            KaRiArrow.transform.rotation);

        TimeS = 0;
        ArrowInst = false;
    }
        
}

