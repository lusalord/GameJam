using System.Collections;
using UnityEngine;

public class CorutineManager : MonoBehaviour
{
    public static CorutineManager Instance
    {
        get
        {
            if (GameManager.Instance.CorutineManager != null)
            {
                return GameManager.Instance.CorutineManager;
            }
            else return null;
        }
    }

    public static CorutineManager Init()
    {
        CorutineManager c = GameManager.Instance.gameObject.AddComponent<CorutineManager>();
        return c;
    }

    public void DestroySound(AudioSource audio)
    {
        StartCoroutine(DestroySoundCorutine(audio));
    }
    public IEnumerator DestroySoundCorutine(AudioSource audio)
    {
        yield return new WaitForSeconds(audio.clip.length);
        Destroy(audio.gameObject);
    }
}
