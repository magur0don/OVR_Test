using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCube : MonoBehaviour
{
    // ‡@Vector3Œ^‚ÅCurrentPos‚Æ‚¢‚¤•Ï”‚ğéŒ¾‚µ‚Ä‚­‚¾‚³‚¢B
    Vector3 CurrentPos;

    // Start is called before the first frame update
    void Start()
    {
        // ‡AgameObject‚ÌTransform‚ÌPosition‚ğCurrentPos‚É‘ã“ü‚µ‚Ü‚·B
        CurrentPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ‡B‚à‚µAgameObject‚ÌTransform‚ÌPosition‚Ìy²¬•ª‚ª-2f‚æ‚è‰º‰ñ‚Á‚½‚ç
        if (gameObject.transform.position.y < -2f)
        {
            // ‡CgameObject‚ÌTransform‚ÌPosition‚ğCurrentPos‚Å‘ã“ü‚·‚é
            gameObject.transform.position = CurrentPos;
        }
    }
}
