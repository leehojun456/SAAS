#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(calb.StereoAudioAreaSystem))]
public class SaasAudioAreaSystemEditor : Editor
{
    void OnSceneGUI()
    {
        // 타겟 오브젝트가 AudioAreaSystem 스크립트를 가지고 있는지 확인
        calb.StereoAudioAreaSystem audioAreaSystem = target as calb.StereoAudioAreaSystem;
        if (audioAreaSystem == null || audioAreaSystem.audioSource == null) return;

        if (audioAreaSystem.playerAudioDistanceMode)
        {
            // 오디오 소스의 위치와 최대 거리를 시각적으로 표시
            Handles.color = Color.yellow;
            Handles.DrawWireDisc(audioAreaSystem.transform.position, audioAreaSystem.transform.up, audioAreaSystem.fadeInOutSecond);
        }
    }
}
#endif