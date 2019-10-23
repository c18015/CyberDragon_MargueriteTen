using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        // 移動させたいオブジェクトを取得
        GameObject obj = GameObject.Find("Title_Castle");
        // オブジェクトを移動
        obj.transform.Translate(0.0f, 1.2f, -15.0f);
    }

}
