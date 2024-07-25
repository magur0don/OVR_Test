using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnObject : MonoBehaviour
{

    public PuzzleGameManager PuzzleGameManager;

    // ①OnTrigerEnterを使って侵入判定を取得する。
    private void OnTriggerEnter(Collider other)
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
    }


}
