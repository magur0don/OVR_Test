using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{
    // �@private bool型の変数でgameClearを作成し、falseで代入する。
    private bool gameClear = false;
    // �Apublic bool型の変数GetGameClear(アクセサ)を作成し、returnでgameClearを返す
    public bool GetGameClear
    {
        get { return gameClear; }
    }

    // �Bprivate int型の変数で、元に戻す回数としてreturnCountを作成し、初期化を3で行う
    private int returnCount = 3;

    // �Cpublic int型の変数でGetReturnCount(アクセサ)を作成し、returnでreturnCountを返す
    public int GetReturnCount
    {
        get { return returnCount; }
    }
    // �Dpublic void型でReturn()というメソッドを作成する。
    public void Return()
    {
        // �E上記メソッドの中で呼ばれたらreturnCountをデクリメント(-1)する
        returnCount--;
        // �FreturnCountが0になったら、gameClearをtrueにする
        if (returnCount <= 0)
        {
            gameClear = true;
        }
    }

}
