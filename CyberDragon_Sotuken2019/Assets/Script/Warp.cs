using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    private bool warp = false;//ワープできるかどうか
    private bool WarpTrigger = false;//ワープを制御

    public GameObject Effect;//ワープポイントのエフェクト
    public GameObject Player;//プレイヤーオブジェクト
    public GameObject Taget_Dragon;//ターゲットのドラゴンオブジェクト
    public GameObject CheckPanel;//ワープポイントを分かりやすくするパネル

    float Distance;//距離

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";//メインカメラ


    void Start()
    {
        Effect.SetActive(false);
        CheckPanel.SetActive(false);
        warp = false;
        WarpTrigger = false;
    }

    private void Update()
    {
        Vector3 P_Pos = Player.transform.position;//プレイヤーとワープポイントの位置を取ってDistanceに数字入れる
        Vector3 My_Pos = this.transform.position;
        Distance = Vector3.Distance(P_Pos, My_Pos);
        //Debug.Log("Distance : " + Distance);


        if (WarpTrigger && Distance <= 20f)//カメラに写っている時
        {
            
            Effect.SetActive(true);

            if (warp)
            {
                //AもしくはBを押したらワープ
                if (OVRInput.GetDown(OVRInput.RawButton.B)|| OVRInput.GetDown(OVRInput.RawButton.A))
                {
                    Player.transform.position = this.transform.position;
                    this.transform.LookAt(Taget_Dragon.transform);
                }
            }
        }
        else//カメラに写ってない時
        {
            Effect.SetActive(false);
            CheckPanel.SetActive(false);
        }

        WarpTrigger = false;
        warp = false;
    }

    private void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedを有効に
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            WarpTrigger = true;
        }
    }

    //コリジョンが当たっている間ワープポイントのエフェクトを消す
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            WarpTrigger = false;
            //Debug.Log("OKOKOK");
        }

        if (collider.gameObject.tag == "RHand")//
        {
            //Debug.Log("OKOKOK");
            warp = true;
            if (WarpTrigger)
            {
                CheckPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "RHand")//
        {
            CheckPanel.SetActive(false);
        }
    }
}
