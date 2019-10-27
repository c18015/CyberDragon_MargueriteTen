using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    private bool warp = false;
    private bool WarpCheck = false;
    public GameObject Effect;
    public GameObject object1;
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";

    // Start is called before the first frame update
    void Start()
    {
        Effect.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (WarpCheck)
        {
            if (warp)//カメラに写っている時
            {
                //Debug.Log("miteru");
                Effect.SetActive(true);
                if (OVRInput.GetDown(OVRInput.RawButton.B))
                {
                    object1.transform.position = this.transform.position;
                }
            }
            else//カメラに写ってない時
            {
                Effect.SetActive(false);
            }
        }



        warp = false;

    }

    private void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedを有効に
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            warp = true;
        }

    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "WarpArea")
        {
            WarpCheck = true;
        }

        

       
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            WarpCheck = false;
        }
    }
}
