using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPaperScissorsStateManager : MonoBehaviour
{

    public RockPaperScissorsManager mainGameManager;

    /// <summary>
    /// 音を鳴らすコンポーネント
    /// </summary>
    public AudioSource AudioSource;

    /// <summary>
    /// 結果のSE
    /// </summary>
    public AudioClip[] resultSE = new AudioClip[2];

    /// <summary>
    /// ゲームの進行度
    /// </summary>
    enum GameState
    {
        Invalide,
        GameStart,
        GameMain,
        GameEnd,
        GameResult
    }

    GameState gameState = GameState.Invalide;


    void Update()
    {
        switch (gameState)
        {
            case GameState.Invalide:
                gameState = GameState.GameStart;
                break;
            case GameState.GameStart:
                mainGameManager.PlayerHand
                    = RockPaperScissorsManager.RockPaperScissors.Invalide;
                mainGameManager.SetText("Rock-Paper-Scissors!!");
                // 待ち時間を減らしていく
                mainGameManager.WaitTime -= Time.deltaTime;
                // 2秒たったらMainに行く
                if (mainGameManager.WaitTime < 0)
                {
                    // CPU側の判定を行って
                    mainGameManager.DecideCPUHand();
                    // 待ち時間を初期化して
                    mainGameManager.WaitTime = 2f;
                    // GameMainに行く
                    gameState = GameState.GameMain;
                }
                break;

            case GameState.GameMain:
                switch (mainGameManager.CPUHand)
                {
                    case RockPaperScissorsManager.RockPaperScissors.Rock:
                        mainGameManager.SetText("Rock!");
                        break;

                    case RockPaperScissorsManager.RockPaperScissors.Paper:
                        mainGameManager.SetText("Paper!");
                        break;

                    case RockPaperScissorsManager.RockPaperScissors.Scissors:
                        mainGameManager.SetText("Scissors!");
                        break;
                }


                mainGameManager.JudgeTime -= Time.deltaTime;





                // mainGameManager.PlayerHand が未定義じゃなくなるまで待つ
                if (mainGameManager.JudgeTime < 0 && mainGameManager.PlayerHand
                    != RockPaperScissorsManager.RockPaperScissors.Invalide)
                {
                    mainGameManager.JudgeTime = 2f;
                    // RockPaperScissorの数値を見て勝っているかを判定する。
                    // 3つの手に対して比較して値が出るようにすれば良いですね。
                    // Rock(0),Paper(1),Scissor(2)なので
                    // 例えばプレイヤーがScissor(2)でCPUがRock(0)だった場合、
                    // (a-b+3)%3で2で負け
                    // 例えばプレイヤーがScissor(2)でCPUがPaper(1)だった場合、
                    // (a-b+3)%3で1で勝ち
                    // 例えばプレイヤーがScissor(2)でCPUがScissor(2)だった場合、
                    // (a-b+3)%3で0だったらあいこ
                    var result =
                    ((int)mainGameManager.PlayerHand - (int)mainGameManager.CPUHand + 3) % 3;
                    mainGameManager.HandResult = (RockPaperScissorsManager.HandResults)result;

                    // 結果が出たのでプレイカウントを増やす
                    mainGameManager.PlayCount++;

                    gameState = GameState.GameEnd;
                }

                break;
            case GameState.GameEnd:
                switch (mainGameManager.HandResult)
                {
                    case RockPaperScissorsManager.HandResults.Win:
                        mainGameManager.SetText("You Win!!");
                        // 勝利カウントを増やす
                        mainGameManager.WinCount++;
                        // 勝利音を鳴らす
                        AudioSource.clip = resultSE[0];
                        AudioSource.Play();
                        break;

                    case RockPaperScissorsManager.HandResults.Draw:
                        mainGameManager.SetText("Draw");
                        break;

                    case RockPaperScissorsManager.HandResults.Lose:
                        mainGameManager.SetText("You Lose...");
                        // 負けの音を鳴らす
                        AudioSource.clip = resultSE[1];
                        AudioSource.Play();
                        break;
                }
                gameState = GameState.GameResult;

                break;
            case GameState.GameResult:
                mainGameManager.WaitTime -= Time.deltaTime;
                if (mainGameManager.WaitTime < 0)
                {
                    mainGameManager.WaitTime = 2f;

                    if (!mainGameManager.GameEnd())
                    {
                        gameState = GameState.GameStart;
                    }
                    else
                    {
                        if (mainGameManager.GameWin())
                        {
                            mainGameManager.SetText("You Win!!");
                        }
                        else
                        {
                            mainGameManager.SetText("You Lose...");
                        }
                    }
                }

                break;
        }
    }
}
