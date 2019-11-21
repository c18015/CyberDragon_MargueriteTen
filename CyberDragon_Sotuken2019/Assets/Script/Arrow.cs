using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
    
    Rigidbody Arrow_Rig;　　　　　　　//オブジェクトのリジットボディを取る
    public float speed;　　　　　 //矢の弾速、
    public GameObject effect = null;  //エフェクトを入れる箱、プレファブ化すると消えるので多分意味ない
    private AudioSource[] sources;    //SE


   
    private void Start()
    {
        Arrow_Rig = this.GetComponent<Rigidbody>();
        sources = gameObject.GetComponents<AudioSource>();
        sources[0].Play();

        SearchPOS();
    }
    
    void Update()
    {
       
    }

    void SearchPOS()
    {
        GameObject LhandPas = GameObject.Find("LHandPos");
        GameObject RhandPas = GameObject.Find("RHandPos");
        Vector3 LHP = LhandPas.transform.position;
        Vector3 RHP = RhandPas.transform.position;
        speed = Vector3.Distance(LHP, RHP);

        speed /=  3000;
        SSS();
    }

    void SSS()
    {
        Arrow_Rig.AddForce(transform.forward * speed);
        Destroy(this.gameObject, 10f);
    }


    void OnCollisionEnter(Collision collision)//オブジェクトに当たるとエフェクト出して弾丸消滅
    {
        if(collision.gameObject.name == "ChaDragon")
        {
            Destroy(gameObject);
        }
    }
}
