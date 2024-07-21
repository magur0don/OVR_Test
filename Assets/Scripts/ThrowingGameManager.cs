using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowingGameManager : MonoBehaviour
{
    // 的当てが成功しているかを取得したいので、的当てのコンポーネントを参照させる
    public ThrowingTarget[] throwingTargets = new ThrowingTarget[2];
    // 60秒経ったかを判定したいのでVRtimerのコンポーネントを参照させます。
    public VRTimer VRTimer;

    public TextMeshPro ResultText;

    private int clearCount = 0;

    private bool gameClear = false;

    private void Start()
    {
        ResultText.text = string.Empty;
        clearCount = throwingTargets.Length;
    }
    private void Update()
    {
        if (gameClear)
        {
            return;
        }

        // 時間切れ
        if (VRTimer.GetLimitTime == 0f)
        {
            ResultText.text = "Game Over!";
            VRTimer.TimerStop = true;
            gameClear = true;
        }

        for (int i = 0; i < throwingTargets.Length; i++)
        {
            if (throwingTargets[i].IsClear)
            {
                clearCount++;
            }
            else
            {
                clearCount--;
            }

            // クリアのカウントと、的当てがクリアされたカウントが等しい場合
            if (clearCount == throwingTargets.Length)
            {
                ResultText.text = "Game Clear!";
                VRTimer.TimerStop = true;
                gameClear = true;
            }

        }
    }
}
