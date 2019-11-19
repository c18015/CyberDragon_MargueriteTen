using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {/*
        if (OVRInput.GetUp(OVRInput.RawButton.Y))
        {
            SceneManager.LoadScene("battle");
        }*/
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("battle");
        }
    }

        public void OnClick()
    {
        SceneManager.LoadScene("battle");
    }
}
