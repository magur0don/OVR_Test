using System;
using TMPro;
using UnityEngine;

public class RockPaperScissorsManager : MonoBehaviour
{
    /// <summary>
    /// Stateの状況を伝える文字領域
    /// </summary>
    public TextMeshProUGUI GameText;

    /// <summary>
    /// じゃんけんの判定
    /// </summary>
    public enum RockPaperScissors
    {
        Invalide = -1,
        Rock,
        Paper,
        Scissors
    }


    /// <summary>
    /// CPUの手
    /// </summary>
    public RockPaperScissors CPUHand = RockPaperScissors.Invalide;

    /// <summary>
    /// Playerの手
    /// </summary>
    public RockPaperScissors PlayerHand = RockPaperScissors.Invalide;

    /// <summary>
    /// SetPlayerHandのstringをRockPaperScissorにキャストする
    /// </summary>
    public string SetPlayerHand
    {
        set { PlayerHand = (RockPaperScissors)Enum.Parse(typeof(RockPaperScissors), value); }
    }

    /// <summary>
    /// 待ち時間
    /// </summary>
    public float WaitTime = 2f;

    /// <summary>
    /// 勝負の待ち時間
    /// </summary>
    public float JudgeTime = 2f;
    /// <summary>
    /// 勝負回数
    /// </summary>
    private int judgeCount = 1;

    /// <summary>
    /// プレイヤーが遊んだカウント
    /// </summary>
    public int PlayCount = 0;

    /// <summary>
    /// 結果
    /// </summary>
    public enum HandResults
    {
        Invalide = -1,
        Draw,
        Win,
        Lose
    };

    /// <summary>
    /// プレイヤーとCPUの勝負結果
    /// </summary>
    public HandResults HandResult = HandResults.Invalide;

    /// <summary>
    /// 勝利した回数
    /// </summary>
    public int WinCount = 0;

    void Start()
    {
        PlayCount = 0;
    }

    /// <summary>
    /// CPUのハンドを決める
    /// </summary>
    public void DecideCPUHand()
    {
        int judgeNo = UnityEngine.Random.Range(0, 3);
        CPUHand = (RockPaperScissors)judgeNo;
    }

    /// <summary>
    /// プレイカウントとゲームの判定カウントが一緒だったらtrueを返す
    /// </summary>
    /// <returns></returns>
    public bool GameEnd()
    {
        return PlayCount == judgeCount;
    }

    /// <summary>
    /// 勝敗判定
    /// </summary>
    /// <returns></returns>
    public bool GameWin()
    {
        // 勝率5割を超えていたらtrueを返す
        if (WinCount / judgeCount > 0.5f)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// ゲームの進行状況を伝える文字を表示する
    /// </summary>
    /// <param name="text"></param>
    public void SetText(string text)
    {
        GameText.text = text;
    }
}
