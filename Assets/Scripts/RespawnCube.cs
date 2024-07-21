using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCube : MonoBehaviour
{
    // �@Vector3型でCurrentPosという変数を宣言してください。
   private Vector3 CurrentPos;

    // Start is called before the first frame update
    void Start()
    {
        // �AgameObjectのTransformのPositionをCurrentPosに代入します。
        CurrentPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // �Bもし、gameObjectのTransformのPositionのy軸成分が-2fより下回ったら
        if (gameObject.transform.position.y < -2f)
        {
            // �CgameObjectのTransformのPositionをCurrentPosで代入する
            gameObject.transform.position = CurrentPos;
        }
    }
}
