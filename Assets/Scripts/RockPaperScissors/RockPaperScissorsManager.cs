using System;
using TMPro;
using UnityEngine;

public class RockPaperScissorsManager : MonoBehaviour
{
    /// <summary>
    /// State�̏󋵂�`���镶���̈�
    /// </summary>
    public TextMeshProUGUI GameText;

    /// <summary>
    /// ����񂯂�̔���
    /// </summary>
    public enum RockPaperScissors
    {
        Invalide = -1,
        Rock,
        Paper,
        Scissors
    }


    /// <summary>
    /// CPU�̎�
    /// </summary>
    public RockPaperScissors CPUHand = RockPaperScissors.Invalide;

    /// <summary>
    /// Player�̎�
    /// </summary>
    public RockPaperScissors PlayerHand = RockPaperScissors.Invalide;

    /// <summary>
    /// SetPlayerHand��string��RockPaperScissor�ɃL���X�g����
    /// </summary>
    public string SetPlayerHand
    {
        set { PlayerHand = (RockPaperScissors)Enum.Parse(typeof(RockPaperScissors), value); }
    }

    /// <summary>
    /// �҂�����
    /// </summary>
    public float WaitTime = 2f;

    /// <summary>
    /// �����̑҂�����
    /// </summary>
    public float JudgeTime = 2f;
    /// <summary>
    /// ������
    /// </summary>
    private int judgeCount = 1;

    /// <summary>
    /// �v���C���[���V�񂾃J�E���g
    /// </summary>
    public int PlayCount = 0;

    /// <summary>
    /// ����
    /// </summary>
    public enum HandResults
    {
        Invalide = -1,
        Draw,
        Win,
        Lose
    };

    /// <summary>
    /// �v���C���[��CPU�̏�������
    /// </summary>
    public HandResults HandResult = HandResults.Invalide;

    /// <summary>
    /// ����������
    /// </summary>
    public int WinCount = 0;

    void Start()
    {
        PlayCount = 0;
    }

    /// <summary>
    /// CPU�̃n���h�����߂�
    /// </summary>
    public void DecideCPUHand()
    {
        int judgeNo = UnityEngine.Random.Range(0, 3);
        CPUHand = (RockPaperScissors)judgeNo;
    }

    /// <summary>
    /// �v���C�J�E���g�ƃQ�[���̔���J�E���g���ꏏ��������true��Ԃ�
    /// </summary>
    /// <returns></returns>
    public bool GameEnd()
    {
        return PlayCount == judgeCount;
    }

    /// <summary>
    /// ���s����
    /// </summary>
    /// <returns></returns>
    public bool GameWin()
    {
        // ����5���𒴂��Ă�����true��Ԃ�
        if (WinCount / judgeCount > 0.5f)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// �Q�[���̐i�s�󋵂�`���镶����\������
    /// </summary>
    /// <param name="text"></param>
    public void SetText(string text)
    {
        GameText.text = text;
    }
}
