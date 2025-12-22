using UnityEngine;
using UnityEngine.Audio;

public class SoundManager
{
    static SoundAssetDictionary _dict => Resources.Load<SoundAssetDictionary>("SoundAssetDictionary");
    public static void Init()
    {

    }
    public static void Play(string key, AudioMixerGroup group)
    {
        GameObject audio = new GameObject();
        AudioSource source = audio.AddComponent<AudioSource>();
        source.clip = _dict.SoundAssets[key];
        source.outputAudioMixerGroup = group;
        source.Play();
        if (group.ToString() == "BGM")
        {
            source.loop = true;
        }
        else
        {
            CorutineManager.Instance.DestroySound(source);
        }
    }
}
