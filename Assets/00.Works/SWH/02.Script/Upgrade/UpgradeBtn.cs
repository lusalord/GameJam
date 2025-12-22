using UnityEngine;
using UnityEngine.UI;

public class UpgradeBtn : MonoBehaviour
{
    [SerializeField] private Button CoolTimeUpgradeBtn;
    [SerializeField] private Button DurationUpgradeBtn;
    [SerializeField] private Button SkillInstanciateBtn;

    private void Awake()
    {
        CoolTimeUpgradeBtn.onClick.AddListener(CoolTimeUpgrade);
        DurationUpgradeBtn.onClick.AddListener(DurationUpgrade);
        SkillInstanciateBtn.onClick.AddListener(SkillInstanciate);
    }
    void CoolTimeUpgrade()
    {
        
    }
    void DurationUpgrade()
    {

    }
    void SkillInstanciate()
    {

    }
}
