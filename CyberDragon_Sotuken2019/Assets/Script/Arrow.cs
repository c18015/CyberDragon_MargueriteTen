using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
    
    Rigidbody Arrow_Rig;　　　　　　　//オブジェクトのリジットボディを取る
    float ArrowPower;　　　　　            //矢の弾速、
    private AudioSource[] sources;    //SE




    private void Awake()
    {
        Arrow_Rig = this.GetComponent<Rigidbody>();
        sources = gameObject.GetComponents<AudioSource>();
    }

    private void Start()
    {
        SearchPOS();
    }

    void SearchPOS()
    {
        GameObject LhandPas = GameObject.Find("LHandPos");
        GameObject RhandPas = GameObject.Find("RHandPos");
        Vector3 LHP = LhandPas.transform.position;
        Vector3 RHP = RhandPas.transform.position;
        ArrowPower = Vector3.Distance(LHP, RHP);

        //ArrowPower /= 3000f;
        Debug.Log(ArrowPower);
        SSS();
    }

    void SSS()
    {
        Arrow_Rig.AddForce(transform.forward * (ArrowPower / 5000f));
        sources[0].Play();
        Destroy(this.gameObject, 10f);
    }


    void OnCollisionEnter(Collision collision)//オブジェクトに当たるとエフェクト出して弾丸消滅
    {
        if(collision.gameObject.name == "ChaDragon")
        {
            Destroy(gameObject);
        }
        /*
        if (collision.gameObject.tag == "OBJ")
        {
            Arrow_Rig.isKinematic = true;
        }*/
    }
}
