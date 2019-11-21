using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaRiDragonMOve : MonoBehaviour
{
    private float speed = 20f;
    private GameObject _cube;
    private Vector3 targetPosition;
    private float moveTime;


    private void Start()
    {
        //_cube = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        targetPosition = GetRandomPosition();
        moveTime = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        moveTime -= Time.deltaTime;
        //moveTimeが0以上なら行動する
        if (moveTime > 0)
        {
            //正面に進む
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime / 2);
        }
        //moveTimeが0以下なら次のポイントを設定する
        if (moveTime < 0)
        {
            moveTime = MoveTime();
            targetPosition = GetRandomPosition();
            //Debug.Log(targetPosition);
        }
    }

    public Vector3 GetRandomPosition()
    {
        int TaKaSa = Random.Range(0, 9);
        float levelSize = 20f;
        return new Vector3(Random.Range(-levelSize, levelSize), TaKaSa, Random.Range(-levelSize, levelSize));
    }

    public float MoveTime()
    {
        return Random.Range(5, 10);
    }
}
