using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnObject : MonoBehaviour
{

    public PuzzleGameManager PuzzleGameManager;

    // �@OnTrigerEnter���g���ĐN��������擾����B
    private void OnTriggerEnter(Collider other)
    {
        // �A�N�����Ă���GameObject��Position,Rotation���A������Position,Rotation�ő������
        other.gameObject.transform.position = this.gameObject.transform.position;
        other.gameObject.transform.rotation = this.gameObject.transform.rotation;
        // �B�N�����Ă���GameObject��RigidBody���擾���A
        // useGravity���I�t�ɂ��āAIsKinematic���I���ɂ���B
        var otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
        otherRigidbody.useGravity = false;
        otherRigidbody.isKinematic = true;

        // �C������MeshRenderer��enabled���I�t�ɂ���
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        PuzzleGameManager.Return();
    }


}
