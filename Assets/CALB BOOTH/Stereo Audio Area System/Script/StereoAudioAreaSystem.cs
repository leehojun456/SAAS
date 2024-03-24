using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;


namespace calb
{
    public class StereoAudioAreaSystem : UdonSharpBehaviour
    {

        [Header("Audio Setting")]
        public AudioSource audioSource;
        public AudioClip clip;
        [Space(10)]
        [Range(0, 1)] public float maxVolume;
        [Space(10)]

        public float fadeInOutSecond;

        [Space(10)]
        public bool playOnWake;
        public bool playOnTrigger;
        public bool audioLoop;
        public bool playerAudioDistanceMode;
        private float currentVolume;
        private float timer;
        private bool isTriggered = false;


        public void OnEnable()
        {
            audioSource.volume = 0f;
            audioSource.clip = clip;
            audioSource.loop = audioLoop;
            audioSource.playOnAwake = playOnWake;
            audioSource.playOnAwake = playOnWake;

            audioSource.gameObject.transform.position = gameObject.transform.position;

            // 재생 여부에 따라 오디오 재생
            if (playOnWake)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }

        void Update()
        {
            if (!playerAudioDistanceMode)
            {
                if (isTriggered)
                {
                    if (!audioSource.isPlaying && playOnTrigger)
                    {
                        audioSource.Play();
                    }



                    if (timer < fadeInOutSecond && audioSource.isPlaying)
                    {
                        timer += Time.deltaTime;
                        currentVolume = Mathf.Lerp(0f, maxVolume, timer / fadeInOutSecond);
                        audioSource.volume = currentVolume;
                    }

                }
                else
                {
                    if (timer > 0)
                    {
                        timer -= Time.deltaTime;
                        currentVolume = Mathf.Lerp(0f, maxVolume, timer / fadeInOutSecond);
                        audioSource.volume = currentVolume;
                    }
                }
            }
            if (playerAudioDistanceMode)
            {
                float distance = Vector3.Distance(gameObject.transform.position, Networking.LocalPlayer.GetPosition());

                float volume = Mathf.Lerp(0f, maxVolume, 1 - Mathf.InverseLerp(0f, fadeInOutSecond, distance));
                audioSource.volume = volume;

            }
        }
    }
}