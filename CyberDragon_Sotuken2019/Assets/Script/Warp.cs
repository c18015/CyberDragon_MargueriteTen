using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    private bool warp = false;
    public GameObject Effect;
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";

    // Start is called before the first frame update
    void Start()
    {
        Effect.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (warp)
        {
            //Debug.Log("miteru");
            Effect.SetActive(true);
        }
        else
        {
            Effect.SetActive(false);
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
}
