using UnityEngine;

[CreateAssetMenu(fileName = "SoundAssetSO", menuName = "Scriptable Objects/Sound/SoundAssetSO")]
public class SoundAssetSO : ScriptableObject
{
    [field:SerializeField] public AudioClip Clip { get; private set; }
    [field:SerializeField] public string ClipName { get; private set; }
    private void OnValidate()
    {
        if (Clip != null && ClipName != Clip.name)
        {
            ClipName = Clip.name;
        }
    }
}
