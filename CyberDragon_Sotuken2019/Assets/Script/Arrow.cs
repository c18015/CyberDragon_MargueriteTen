using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody Arrow_Rig;　　　　　　　//オブジェクトのリジットボディを取る
    public float speed = 0;　　　　　//矢の弾速、
    public GameObject effect = null;  //エフェクトを入れる箱、プレファブ化すると消えるので多分意味ない
    private AudioSource[] sources;    //SE
    public bool TransPos = true;　　　//矢を定位置に置く
    bool Lock = false;
   
    private void Start()
    {
        TransPos = true;
        Arrow_Rig = this.GetComponent<Rigidbody>();
        sources = gameObject.GetComponents<AudioSource>();
        Lock = true;
    }
    
    void Update()
    {
        if (TransPos)//TransPosがTrueの場合、シーン上にあるArrowSetPosオブジェクト(弓オブジェクト)の位置を追従する
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
            speed = Vector3.Distance(LHP, RHP);　　　　　　　//左手と右手の距離を測って数値を出しSpeedにぶち込む


            TransPos = false;　//矢オブジェクト追従をOFF
            Shot_qqq(); 　   　//void Shot_qqq()を呼び出す

            Destroy(this.gameObject, 30f);//30秒後にこのオブジェクトを消す
        }

    }

    void Shot_qqq()//
    {
        if (Lock)
        {
            float Power = speed * 2000f;
            Arrow_Rig.AddForce(transform.forward * Power, ForceMode.Force);
            sources[0].Play();

            Lock = false;
        }
        
        //Debug.Log(Power);
    }


    void OnCollisionEnter()//オブジェクトに当たるとエフェクト出して弾丸消滅
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
