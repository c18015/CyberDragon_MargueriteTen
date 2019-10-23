using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    float fadeSpeed = 0.015f;     //透明度が変わるスピードを管理
    float red, green, blue, alpha;   //パネルの色、不透明度を管理
    public bool isFadeOut = false;   //フェードイン処理の開始、完了を管理するフラグ
    Image fadeImage;                //透明度を変更するパネルのイメージ

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;
    }

    public void OnClick()
    {
        GameObject obj = GameObject.Find("Button");
        // 指定したオブジェクトを削除
        Destroy(obj);
        isFadeOut = true;
    }
    void Update()
    {
        if(isFadeOut == true)
        {
            StartFadeOut();
        }
    }
    void StartFadeOut()
    {
        fadeImage.enabled = true;  // a)パネルの表示をオンにする
        alpha += fadeSpeed;         // b)不透明度を徐々にあげる
        SetAlpha();               // c)変更した透明度をパネルに反映する
        if (alpha > 1.0f)
        {             // d)完全に不透明になったら処理を抜ける
            SceneManager.LoadScene("tutorial");
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }
}