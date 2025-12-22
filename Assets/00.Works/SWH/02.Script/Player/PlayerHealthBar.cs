using TMPro;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] PlayerHealth PlayerHealth;
    [SerializeField] TextMeshProUGUI hpText;
    private void Start()
    {
        PlayerHealth.OnDamage += HealthBarUpdate;
        HealthBarUpdate(PlayerHealth.HP);
    }
    void HealthBarUpdate(int hp)
    {
        hpText.text = hp.ToString();
    }
}
