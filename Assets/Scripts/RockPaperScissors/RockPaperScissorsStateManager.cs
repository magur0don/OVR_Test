using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPaperScissorsStateManager : MonoBehaviour
{

    public RockPaperScissorsManager mainGameManager;

    /// <summary>
    /// ����炷�R���|�[�l���g
    /// </summary>
    public AudioSource AudioSource;

    /// <summary>
    /// ���ʂ�SE
    /// </summary>
    public AudioClip[] resultSE = new AudioClip[2];

    /// <summary>
    /// �Q�[���̐i�s�x
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
                // �҂����Ԃ����炵�Ă���
                mainGameManager.WaitTime -= Time.deltaTime;
                // 2�b��������Main�ɍs��
                if (mainGameManager.WaitTime < 0)
                {
                    // CPU���̔�����s����
                    mainGameManager.DecideCPUHand();
                    // �҂����Ԃ�����������
                    mainGameManager.WaitTime = 2f;
                    // GameMain�ɍs��
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





                // mainGameManager.PlayerHand ������`����Ȃ��Ȃ�܂ő҂�
                if (mainGameManager.JudgeTime < 0 && mainGameManager.PlayerHand
                    != RockPaperScissorsManager.RockPaperScissors.Invalide)
                {
                    mainGameManager.JudgeTime = 2f;
                    // RockPaperScissor�̐��l�����ď����Ă��邩�𔻒肷��B
                    // 3�̎�ɑ΂��Ĕ�r���Ēl���o��悤�ɂ���Ηǂ��ł��ˁB
                    // Rock(0),Paper(1),Scissor(2)�Ȃ̂�
                    // �Ⴆ�΃v���C���[��Scissor(2)��CPU��Rock(0)�������ꍇ�A
                    // (a-b+3)%3��2�ŕ���
                    // �Ⴆ�΃v���C���[��Scissor(2)��CPU��Paper(1)�������ꍇ�A
                    // (a-b+3)%3��1�ŏ���
                    // �Ⴆ�΃v���C���[��Scissor(2)��CPU��Scissor(2)�������ꍇ�A
                    // (a-b+3)%3��0�������炠����
                    var result =
                    ((int)mainGameManager.PlayerHand - (int)mainGameManager.CPUHand + 3) % 3;
                    mainGameManager.HandResult = (RockPaperScissorsManager.HandResults)result;

                    // ���ʂ��o���̂Ńv���C�J�E���g�𑝂₷
                    mainGameManager.PlayCount++;

                    gameState = GameState.GameEnd;
                }

                break;
            case GameState.GameEnd:
                switch (mainGameManager.HandResult)
                {
                    case RockPaperScissorsManager.HandResults.Win:
                        mainGameManager.SetText("You Win!!");
                        // �����J�E���g�𑝂₷
                        mainGameManager.WinCount++;
                        // ��������炷
                        AudioSource.clip = resultSE[0];
                        AudioSource.Play();
                        break;

                    case RockPaperScissorsManager.HandResults.Draw:
                        mainGameManager.SetText("Draw");
                        break;

                    case RockPaperScissorsManager.HandResults.Lose:
                        mainGameManager.SetText("You Lose...");
                        // �����̉���炷
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
