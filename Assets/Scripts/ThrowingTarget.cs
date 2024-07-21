using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingTarget : MonoBehaviour
{
    /// <summary>
    /// クリアしたかのフラグ
    /// </summary>
    public bool IsClear = false;

    // �@OnTrigerEnterを使って侵入判定を取得する。
    // �A上記メソッドの中で、自分のMeshRendererからマテリアルの色を取得し、赤色を代入する
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        IsClear = true;
    }
}
