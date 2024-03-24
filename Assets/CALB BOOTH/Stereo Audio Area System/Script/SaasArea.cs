
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace calb
{

public class SaasArea : UdonSharpBehaviour
{

    public UdonBehaviour StereoAudioAreaSystem;

    void Start()
    {
        
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {

            Debug.Log("TriggerEnter");

            StereoAudioAreaSystem.SetProgramVariable("isTriggered", true);

    }

    public override void OnPlayerTriggerStay(VRCPlayerApi player)
    {
            StereoAudioAreaSystem.SetProgramVariable("isTriggered", true);
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {

            Debug.Log("TriggerExit");
            StereoAudioAreaSystem.SetProgramVariable("isTriggered", false);

    }
}
}