using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VRTimer : MonoBehaviour
{
    /// <summary>
    /// 秒数を表示するTextmesh
    /// </summary>
    public TextMeshPro TimerTextMesh;
    /// <summary>
    /// 制限時間
    /// </summary>
    private float limitTime = 30f;

    // limitTimeのアクセサ
    public float GetLimitTime
    {
        get { return limitTime; }
    }

    /// <summary>
    /// タイマーストップ用のフラグ
    /// </summary>
    public bool TimerStop = false;

    // Update is called once per frame
    void Update()
    {
        if (TimerStop)
        {
            return;
        }

        if (limitTime < 0f)
        {
            limitTime = 0f;
        }
        else
        {
            limitTime -= Time.deltaTime;
        }
        TimerTextMesh.text = limitTime.ToString("F2");
    }

    public void HideText()
    {
        TimerTextMesh.gameObject.SetActive(false);
    }
}
