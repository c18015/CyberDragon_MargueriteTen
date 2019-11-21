using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KariHyouziArrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            GameObject target1 = GameObject.Find("RHandPos");
            Transform Rhandpos = target1.GetComponent<Transform>();

            this.transform.LookAt(Rhandpos.transform);
        }
        
    }
}
