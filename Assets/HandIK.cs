using UnityEngine;
using DG.Tweening;

/// <summary>
/// 手の IK を制御する。
/// </summary>
[RequireComponent(typeof(Animator))]
public class HandIK : MonoBehaviour
{
    /// <summary>右手のターゲット</summary>
    [SerializeField] Transform _rightHandTarget = default;
    /// <summary>右手の Position に対するウェイト</summary>
    [SerializeField, Range(0f, 1f)] float _rightPositionWeight = 0;
    /// <summary>右手の Rotation に対するウェイト</summary>
    [SerializeField, Range(0f, 1f)] float _rightRotationWeight = 0;
    Animator _anim = default;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void TouchTarget()
    {
        // _rightHandTarget に触れて、手を下ろす
        Sequence seq = DOTween.Sequence()
            .Append(DOTween.To(() => _rightPositionWeight,
                x => _rightPositionWeight = x, 1f, 0.5f))
            .SetDelay(0.2f)
            .Append(DOTween.To(() => _rightPositionWeight,
                x => _rightPositionWeight = x, 0f, 0.5f));
    }

    void OnAnimatorIK(int layerIndex)
    {
        // 右手に対して IK を設定する
        _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, _rightPositionWeight);
        _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, _rightRotationWeight);
        _anim.SetIKPosition(AvatarIKGoal.RightHand, _rightHandTarget.position);
        _anim.SetIKRotation(AvatarIKGoal.RightHand, _rightHandTarget.rotation);
    }
}