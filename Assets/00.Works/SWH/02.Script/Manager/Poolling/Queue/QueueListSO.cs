using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QueueList", menuName = "Scriptable Objects/Queue/List", order = 0)]
public class QueueListSO : ScriptableObject
{
    public List<QueueItem> items;
}
