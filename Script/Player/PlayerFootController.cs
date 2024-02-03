using KD;
using UnityEngine;

public class PlayerFootController : MonoBehaviour
{
    [SerializeField]
    private float m_FootSoundVolume = 0.5f;

    [SerializeField]
    private GameObject[] m_FootPlayPositions;

    private PlayerController m_Player;

    private void Awake()
    {
        m_Player = GetComponent<PlayerController>();
    }

    /// <summary>
    /// �A�j���[�V�����C�x���g�ŌĂ΂��
    /// </summary>
    /// <param name="index"></param>
    private void PlayFootSound(int index)
    {
        if (index >= m_FootPlayPositions.Length) index = m_FootPlayPositions.Length - 1;

        GameObject playObj = m_FootPlayPositions[index];

        //�����𔭐�������
        SmokeEffect(playObj.transform.position);

        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                AudioManager.instance.PlaySEFromObjectPosition(SoundName.Foot1, playObj, volume: m_FootSoundVolume);
                break;
            case 1:
                AudioManager.instance.PlaySEFromObjectPosition(SoundName.Foot2, playObj, volume: m_FootSoundVolume);
                break;
            case 2:
                AudioManager.instance.PlaySEFromObjectPosition(SoundName.Foot2, playObj, volume: m_FootSoundVolume);
                break;
        }
    }

    private void SmokeEffect(Vector3 position)
    {
        //�_�b�V�������ǂ����ō�����ύX����
        string effectName = (m_Player.IsDash) ? EffectName.DashSmoke : EffectName.Smoke;
        
        //�����𔭐�������
        EffectManager.instance.PlayPosition(effectName, position,rotation:m_Player.transform.eulerAngles);
    }
}
