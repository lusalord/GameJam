using _00.Works.KDS._02.Script;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private UpgradePanel upgradePanel;

    private void Update()
    {
        // T 키 누르면 테스트
        if (Input.GetKeyDown(KeyCode.T))
        {
            upgradePanel.Show();
        }
    }
}
