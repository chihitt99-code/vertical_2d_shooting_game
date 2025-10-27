using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//싱글톤 클래스 
//1. 클래스의 인스턴스는 하나다
//2. 전역으로 접근가능하다 
public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;

    public GameObject playerBullet0Prefabs;
    public GameObject playerBullet1Prefabs;
    public GameObject playerBullet2Prefabs;
    
    private List<GameObject> playerBullet0List = new List<GameObject>();
    private List<GameObject> playerBullet1List = new List<GameObject>();
    private List<GameObject> playerBullet2List = new List<GameObject>();

    private void Awake()
    {
        Instance = this;

        Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject playerBullet0Go = Instantiate(playerBullet0Prefabs, transform);
            playerBullet0Go.SetActive(false);
            playerBullet0List.Add(playerBullet0Go);
            
            GameObject playerBullet1Go = Instantiate(playerBullet1Prefabs, transform);
            playerBullet1Go.SetActive(false);
            playerBullet1List.Add(playerBullet1Go);
            
            // GameObject playerBullet2Go = Instantiate(playerBullet2Prefabs, transform);
            // playerBullet2Go.SetActive(false);
            // playerBullet2List.Add(playerBullet2Go);
        }
    }
    



      public GameObject GetPlayerBullet1()
    {
        GameObject foundPlayerBulletGo1 = null;
        bool isAvailableBullet1 = false;
        
        //playerBullet1List 를 순회 하면서 사용 가능한 총알이 있는지 검사한다
        for (int i = 0; i < playerBullet1List.Count; i++)
        {
            GameObject playerBullet1Go = playerBullet1List[i];
            if (!playerBullet1Go.activeSelf)
            {
                isAvailableBullet1 = true; //총알 1번이 사용가능한지 확인하는 변수 
                break;
            }
        }

        if (isAvailableBullet1 == false)
        {
            GameObject go = Instantiate(playerBullet1Prefabs, transform);
            go.SetActive(false);
            playerBullet1List.Add(go);
        }

        for (int i = 0; i < playerBullet1List.Count; i++)
        {
            GameObject playerBullet1Go = playerBullet1List[i];
            if (!playerBullet1Go.activeSelf)
            {
                playerBullet1Go.SetActive(true);
                return playerBullet1Go;
            }
            

        }

        return null;

    }

    public void ReleasePlayerBullet1Go(GameObject playerBullet1Go)
    {
        
        playerBullet1Go.SetActive(false);
        playerBullet1Go.transform.localPosition = Vector3.zero;
    }
      
    public GameObject GetPlayerBullet0()
    {
        GameObject foundPlayerBullet0Go = null;
        bool isAvailableBullet0 = false;
        
        //playerBullet0List 를 순회 하면서 사용가능한 총알이 있는지 검사 한다 
        for (int i = 0; i < playerBullet0List.Count; i++)
        {
            GameObject playerBullet0Go = playerBullet0List[i];
            if (!playerBullet0Go.activeSelf)
            {
                isAvailableBullet0 = true;
                break;
            }
        }
        
        //만약에 사용할수있는 총알이 없다면 만들어서 playerBullet0List에 추가 한다 
        if (isAvailableBullet0 == false)
        {
            GameObject go = Instantiate(playerBullet0Prefabs, transform);
            go.SetActive(false);
            playerBullet0List.Add(go);
        }

        //playerBullet0List 를 순회 하면서 사용가능한 총알이 있는지 검사한다 
        
        for (int i = 0; i < playerBullet0List.Count; i++)
        {
            GameObject playerBullet0Go = playerBullet0List[i];
            if (!playerBullet0Go.activeSelf)
            {
                playerBullet0Go.SetActive(true);
                return playerBullet0Go;
            }
        }

        return null;
    }
    
    public void ReleasePlayerBullet0Go(GameObject playerBullet0Go)
    {
        playerBullet0Go.SetActive(false);
        playerBullet0Go.transform.localPosition = Vector3.zero;
    }

   
}