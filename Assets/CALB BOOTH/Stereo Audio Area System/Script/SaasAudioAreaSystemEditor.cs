#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(calb.StereoAudioAreaSystem))]
public class SaasAudioAreaSystemEditor : Editor
{
    void OnSceneGUI()
    {
        // Ÿ�� ������Ʈ�� AudioAreaSystem ��ũ��Ʈ�� ������ �ִ��� Ȯ��
        calb.StereoAudioAreaSystem audioAreaSystem = target as calb.StereoAudioAreaSystem;
        if (audioAreaSystem == null || audioAreaSystem.audioSource == null) return;

        if (audioAreaSystem.playerAudioDistanceMode)
        {
            // ����� �ҽ��� ��ġ�� �ִ� �Ÿ��� �ð������� ǥ��
            Handles.color = Color.yellow;
            Handles.DrawWireDisc(audioAreaSystem.transform.position, audioAreaSystem.transform.up, audioAreaSystem.fadeInOutSecond);
        }
    }
}
#endif