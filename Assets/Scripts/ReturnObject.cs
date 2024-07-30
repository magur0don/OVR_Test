using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ReturnObject : MonoBehaviour
{

    public PuzzleGameManager PuzzleGameManager;

    /// <summary>
    /// 自分自身のCollider
    /// </summary>
    private Collider myCollider = null;

    /// <summary>
    /// スナップしたか
    /// </summary>
    private bool isSnapped = false;

    /// <summary>
    /// スナップしたときのエフェクト
    /// </summary>
    public ParticleSystem SnappedEffect;

    private void Start()
    {
        myCollider = GetComponent<Collider>();
    }

    /// <summary>
    /// 侵入中の判定
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        // すでにスナップされていたら以下の処理はしない
        if (isSnapped) 
        {
            return;
        }

        // もし、otherオブジェクトの一番外側の点（最大の点）がmyColliderの中にあり、
        // かつ、otherオブジェクトの一番内側の点（最小の点）もmyColliderの中にあるなら、
        // つまり、otherオブジェクト全体がmyColliderの中に入っていることを意味します。 
        if (myCollider.bounds.Contains(other.bounds.max)&&
            myCollider.bounds.Contains(other.bounds.min))
        {
            // ②侵入してきたGameObjectのPosition,Rotationを、自分のPosition,Rotationで代入する
            other.gameObject.transform.position = this.gameObject.transform.position;
            other.gameObject.transform.rotation = this.gameObject.transform.rotation;
            // ③侵入してきたGameObjectのRigidBodyを取得し、
            // useGravityをオフにして、IsKinematicをオンにする。
            var otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
            otherRigidbody.useGravity = false;
            otherRigidbody.isKinematic = true;

            // ④自分のMeshRendererのenabledをオフにする
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            PuzzleGameManager.Return();
            isSnapped = true;

            // エフェクトをプレイする
            SnappedEffect.Play();
        }
    }
}