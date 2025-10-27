using System;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 1f;
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > 5.4f)
        {
            ObjectPoolManager.Instance.ReleasePlayerBullet0Go(this.gameObject);
            /*Destroy(gameObject);*/
            // 플레이어 불렛이 제거되지않고 오브젝트 풀 매니저 안에서 비활성화 되게하는 코드
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(1);
            
            ObjectPoolManager.Instance.ReleasePlayerBullet0Go(this.gameObject);
            /*Destroy(gameObject);*/
        }
    }
}