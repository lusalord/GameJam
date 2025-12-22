using System.Collections.Generic;
using UnityEngine;

public class Queue
{
    private Queue<IPoolable> _pool;
    private Transform _parent;
    private IPoolable _poolable;
    private GameObject _prefab;

    public Queue(IPoolable poolable, Transform parent, int initCount)
    {
        _pool = new Queue<IPoolable>(); // Queue 형태로 마개조
        _parent = parent;
        _poolable = poolable;
        _prefab = poolable.GameObject;

        for (int i = 0; i < initCount; i++)
        {
            GameObject item = Object.Instantiate(_prefab, _parent);
            item.name = _poolable.ItemName; // 아이템 이름을 초기화 시켜준다.
            item.SetActive(false);
            IPoolable poolableItem = item.GetComponent<IPoolable>();
            _pool.Enqueue(poolableItem);
            item.SetActive(false);
        }
    }

    public IPoolable Dequeue()
    {
        IPoolable item = null;
        if (_pool.Count == 0)
        {
            GameObject gameObj = Object.Instantiate(_prefab, _parent);
            gameObj.name = _poolable.ItemName;
            item = gameObj.GetComponent<IPoolable>();
        }
        else
        {
            item = _pool.Dequeue();
            item.GameObject.SetActive(true); // 꺼져있던 아이템을 활성화 시켜준다
        }

        return item;
    }

    public void Enqueue(IPoolable item)
    {
        item.GameObject.SetActive(false);
        _pool.Enqueue(item);
    }
}
