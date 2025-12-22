using UnityEngine;
using UnityEngine.Audio;

public class BGMController : MonoBehaviour
{
    public AudioMixerGroup group;
    private void Start()
    {
        SoundManager.Play("MoonNight2", group);
    }
}
