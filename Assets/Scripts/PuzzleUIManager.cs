using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleUIManager : MonoBehaviour
{
    // ‡@public TextmeshProŒ^‚Ì•Ï”‚ÅReturnCountTextMesh‚ğì¬‚·‚éB

    public TextMeshPro ReturnCountTextMesh;
    // ‡Apublic PuzzleGameManagerŒ^‚ÅPuzzleGameManager‚Æ‚¢‚¤•Ï”‚ğì¬‚·‚éB
    public PuzzleGameManager PuzzleGameManager;
    // Update“à‚ÅPuzzleGameManager‚ÌGetReturnCount‚ğGetReturnCount/3‚Æ‚¢‚¤Œ`‚Å•\¦‚·‚é

    private void Update()
    {
        ReturnCountTextMesh.text = $"{PuzzleGameManager.GetReturnCount}/3";
    }
}
