using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    //① public修飾子でGameObect型の変数MagicObjectを作成します。
    public GameObject MagicObject;

    // ※右手のTransform
    public Transform RightHand = null;

    // ※オフセット(距離の差分)
    public Vector3 OffsetPosition = Vector3.zero;
    public Vector3 OffsetEulerAngles= Vector3.zero;

    //② public void型でGameObjectのSetActiveをtrueにする任意の名前のメソッドを作成する
    public void MagicActive()
    {
        if (RightHand != null)
        {
            // MagicObjectをRightHandの位置に合わせて配置し、オフセットも反映させる
            MagicObject.transform.position = RightHand.position + OffsetPosition;
            // 回転をRightHandに追従させる
            MagicObject.transform.rotation = RightHand.rotation;
            // 回転値のオフセットを反映させる
            MagicObject.transform.eulerAngles += OffsetEulerAngles;
        }
        MagicObject.SetActive(true);
    }

    //③ public void型でGameObjectのSetActiveをfalseにする任意の名前のメソッドを作成する
    public void MagicDeactivate()
    {
        MagicObject.SetActive(false);
    }

}
