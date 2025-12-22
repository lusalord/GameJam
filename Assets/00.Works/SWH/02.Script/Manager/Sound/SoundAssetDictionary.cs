using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundAssetDictionary", menuName = "Scriptable Objects/Sound/SoundAssetDictionary")]
public class SoundAssetDictionary : ScriptableObject
{
    public Dictionary<string, AudioClip> SoundAssets=>DirectoryUpdate();
    public SoundAssetSO[] _asset;
    [ContextMenu("SetSound")]
    public Dictionary<string, AudioClip> DirectoryUpdate()
    {
        Dictionary<string, AudioClip> soundAssets = new();
        foreach (SoundAssetSO i in _asset)
        {
            soundAssets.Add(i.ClipName, i.Clip);
        }
        Debug.Log(soundAssets[_asset[0].ClipName]);
        return soundAssets;
    }
}
