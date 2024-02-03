using KD.Cinemachine;
using KD.Tweening;
using UnityEngine;

public class CounterCameraAnimation
{
    private const float c_TweenHorizontalAxisValue = 360;
    private const float c_TweenDistanceValue = 3f;
    private const float c_TweenDuration = 1.1f;
    private const Ease c_TweenEasing = Ease.OutQuart;

    private float m_DefaultDistanceValue; //�v���C���[�Ƃ̋����̏����l
    private float m_DefaultHorizontalAxis; //�������̏����l

    private VirtualCamera m_CounterCamera; //�J�E���^�[�̏���


    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="camera"></param>
    public CounterCameraAnimation(VirtualCamera camera)
    {
        m_CounterCamera = camera;
        m_DefaultDistanceValue = camera.Body.MaxDistance;
        m_DefaultHorizontalAxis = camera.Aim.m_HorizontalAxis.Value;
    }

    /// <summary>
    /// �l�̏���������
    /// </summary>
    private void Initialize()
    {

        //��΂ɑI�΂��l�ɂ���
        m_CounterCamera.Priority = 100;

        m_CounterCamera.Body.MaxDistance = m_DefaultDistanceValue;
        m_CounterCamera.Aim.m_HorizontalAxis.Value = m_DefaultHorizontalAxis;
    }

    /// <summary>
    /// �J�E���^�[���ɃJ�����𓮂���
    /// </summary>
    public void ApplyCameraMove()
    {
        Initialize();

        //�J�������v���C���[�ɋ߂Â���
        m_CounterCamera.TweenDistance(c_TweenDistanceValue, c_TweenDuration).SetEase(c_TweenEasing);

        //�J��������]������
        m_CounterCamera.TweenHorizontalAxis(c_TweenHorizontalAxisValue, c_TweenDuration)
            .SetRelative()
            .SetEase(c_TweenEasing)
            .OnComplete(() =>
            {
                //��΂Ɉ�ԗD��ɂȂ�Ȃ��l�ɂ���
                m_CounterCamera.Priority = -100;
            });
    }
}
