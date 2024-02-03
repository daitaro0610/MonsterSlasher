using KD.Cinemachine;
using KD.Tweening;
using UnityEngine;

public class CounterCameraAnimation
{
    private const float c_TweenHorizontalAxisValue = 360;
    private const float c_TweenDistanceValue = 3f;
    private const float c_TweenDuration = 1.1f;
    private const Ease c_TweenEasing = Ease.OutQuart;

    private float m_DefaultDistanceValue; //プレイヤーとの距離の初期値
    private float m_DefaultHorizontalAxis; //水平軸の初期値

    private VirtualCamera m_CounterCamera; //カウンターの処理


    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="camera"></param>
    public CounterCameraAnimation(VirtualCamera camera)
    {
        m_CounterCamera = camera;
        m_DefaultDistanceValue = camera.Body.MaxDistance;
        m_DefaultHorizontalAxis = camera.Aim.m_HorizontalAxis.Value;
    }

    /// <summary>
    /// 値の初期化処理
    /// </summary>
    private void Initialize()
    {

        //絶対に選ばれる値にする
        m_CounterCamera.Priority = 100;

        m_CounterCamera.Body.MaxDistance = m_DefaultDistanceValue;
        m_CounterCamera.Aim.m_HorizontalAxis.Value = m_DefaultHorizontalAxis;
    }

    /// <summary>
    /// カウンター時にカメラを動かす
    /// </summary>
    public void ApplyCameraMove()
    {
        Initialize();

        //カメラをプレイヤーに近づける
        m_CounterCamera.TweenDistance(c_TweenDistanceValue, c_TweenDuration).SetEase(c_TweenEasing);

        //カメラを回転させる
        m_CounterCamera.TweenHorizontalAxis(c_TweenHorizontalAxisValue, c_TweenDuration)
            .SetRelative()
            .SetEase(c_TweenEasing)
            .OnComplete(() =>
            {
                //絶対に一番優先にならない値にする
                m_CounterCamera.Priority = -100;
            });
    }
}
