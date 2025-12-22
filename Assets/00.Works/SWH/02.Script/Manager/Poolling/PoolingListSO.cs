using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoolingList", menuName = "Scriptable Objects/Pool/List", order = 0)]
public class PoolingListSO : ScriptableObject
{
    public List<PoolItem> items; 
}
