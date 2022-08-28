using System;
using UnityEngine;
using DG.Tweening;


[DisallowMultipleComponent]
public class RotationComponent : MonoBehaviour
{
    [SerializeField, Range( 0, 90 )] private float angle;
    [SerializeField, Range( 0.1f, 10 )] private float rotationPeriodDuration;

    private Tween tween;

    private void Start()
    {
        StartCyclicRotation( Quaternion.Euler( 0, angle, 0 ), rotationPeriodDuration );
    }

    public void StartCyclicRotation( Quaternion deltaRotation, float durationSeconds )
    {
        tween = transform.DOLocalRotate( deltaRotation.eulerAngles, durationSeconds, RotateMode.LocalAxisAdd )
            .SetLoops( -1, LoopType.Yoyo )
            .SetEase( Ease.InOutQuad );
    }

    public void StopRotation() => tween?.Kill();
}