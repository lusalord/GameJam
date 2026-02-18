using UnityEngine;

public class Satelite : MonoBehaviour
{
    [SerializeField]public Transform _target;
    //Transform t;
    [SerializeField] float radius;
    float _theta;
    [SerializeField] float _revolution;//1바퀴(=360도)를 도는 데 걸리는 시간
    void Update()
    {
        transform.position = _target.position + new Vector3(radius * Mathf.Cos(_theta * Mathf.Deg2Rad), 
            radius * Mathf.Sin(_theta * Mathf.Deg2Rad), 0);
        _theta += 360 * Time.deltaTime / _revolution;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealthSystem eh))
        {
            SoundManager.Play("sfx", GameManager.Instance._sfx);
            GetComponentInParent<PlayerHealth>().HP++;
            Destroy(eh.gameObject);
            Destroy(gameObject);
        }
    }
}
