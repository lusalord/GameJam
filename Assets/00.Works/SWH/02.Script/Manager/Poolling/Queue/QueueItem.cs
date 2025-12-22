using UnityEngine;

[CreateAssetMenu(fileName = "QueueObject", menuName = "Scriptable Objects/Queue/Object", order = 0)]
public class QueueItem : ScriptableObject
{
    public string queueName;
    public GameObject prefab;
    public int count;

    private void OnValidate()
    {
        if (prefab == null) return;
        IPoolable item = prefab.GetComponent<IPoolable>();
        if (item == null)
        {
            Debug.LogWarning($"Can not find IPoolable in {prefab.name}");
            prefab = null;
            return;
        }

        queueName = item.ItemName;
    }
}
