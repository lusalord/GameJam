using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public DataManager DataManager => new DataManager();
    //public MapManager MapManager => new MapManager();
    public PoolManager PoolManager { get; private set; }
    //public InputManager InputManager { get; private set; }
    public QueueManager QueueManager { get; private set; }
    public CorutineManager CorutineManager { get; private set; }
    public AudioMixerGroup _bgm;
    public AudioMixerGroup _sfx;
    private void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        #endregion
        Init();
    }
    public void Init()//모든 매니저 이니셜라이즈
    {
        //와 씨 통일감 진짜 ㅈ도 없네
        DataManager.Init();
        PoolManager = PoolManager.Init();
        InputManager.Init();
        QueueManager = QueueManager.Init();
        CorutineManager = CorutineManager.Init();
    }
    private void Start()
    {
        SoundManager.Play("bgm", _bgm);
    }
}
