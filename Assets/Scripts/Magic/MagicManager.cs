using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    //�@ public修飾子でGameObect型の変数MagicObjectを作成します。
    public GameObject MagicObject;

    public Transform RightHand = null;

    public Vector3 forwradOffset = new Vector3(-0.4f,0,0);

    //�A public void型でGameObjectのSetActiveをtrueにする任意の名前のメソッドを作成する
    public void MagicActive()
    {
        if (RightHand != null)
        {
            MagicObject.transform.parent = RightHand;
            MagicObject.transform.localPosition = forwradOffset;
        }

        MagicObject.SetActive(true);
    }

    //�B public void型でGameObjectのSetActiveをfalseにする任意の名前のメソッドを作成する
    public void MagicDeactivate()
    {
        MagicObject.SetActive(false);
    }

}
