using UnityEngine;
using System;
using System.Collections;
public class Boom : MonoBehaviour
{
    public Action onFinishBoom;
   

   
    IEnumerator Start()
    {
        Enemy[] enemies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = enemies[i];
            enemy.TakeDamage(1000);
        }
        EnemyBullet[] enemyBullets = GameObject.FindObjectsByType<EnemyBullet>(FindObjectsSortMode.None);
        for (int i = 0; i < enemyBullets.Length ; i++)
        {
            EnemyBullet enemyBullet = enemyBullets[i];
            Destroy(enemyBullet.gameObject);
        }
        
        
        yield return new WaitForSeconds(1f);
        onFinishBoom?.Invoke();
    }
}
