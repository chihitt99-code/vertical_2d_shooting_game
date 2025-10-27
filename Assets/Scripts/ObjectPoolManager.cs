using System.CodeDom.Compiler;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;

    public GameObject playerBullet0Prefabs;
    public GameObject playerBullet1Prefabs;
    public GameObject playerBullet2Prefabs;

    private List<GameObject> playerBullet0List= new List<GameObject>();
    private List<GameObject> playerBullet1List= new List<GameObject>();
    private List<GameObject> playerBullet2List = new List<GameObject>();

    void Awake()
    {
        Instance = this; //클래스의 현재 인스턴스 . 컴포넌트일 경우에 플레이 버튼을 누르면 게임오브젝트가 생성되고 게임오브젝트의 컴포넌트가 이 클래스가 된다

        Generate();
    }

    void Generate()
    {
        for ( int i =0 ; i < 10 ; i++)
        {
            GameObject playerBullet0Go = Instantiate(playerBullet0Prefabs, transform);
            playerBullet0Go.SetActive(false);
            playerBullet0List.Add(playerBullet0Go);
            
            /*GameObject playerBullet1Go = Instantiate(playerBullet1Prefabs, transform);
            playerBullet1Go.SetActive(false);
            playerBullet1List.Add(playerBullet1Go);
            
            GameObject playerBullet2Go = Instantiate(playerBullet2Prefabs, transform);
            playerBullet2Go.SetActive(false);
            playerBullet2List.Add(playerBullet2Go);*/
        }
    }

    public GameObject GetPlayerBullet0()
    {
        GameObject foundPlayerBullet0Go = null;
        bool isAvailableBullet0 = false;
        //playerBullet0List 를 순회 하면서 사용가능한 총알이 있는지 검사한다
        for(int i = 0; i <playerBullet0List.Count; i++)
        {
            GameObject playerBullet0Go = playerBullet0List[i];
        
            if (!playerBullet0Go.activeSelf)
            {
                //playerBullet0Go.SetActive(true);
                isAvailableBullet0 = true;
                break;
                /*foundPlayerBullet0Go =  playerBullet0Go;
                foundPlayerBullet0Go.SetActive(true);*/
            }
          
        }
        //만약에 사용할수있는 총알이 없다면 만들어서 playerBullet0List 에 추가한다
        if (isAvailableBullet0 == false)
        {
            GameObject go =  Instantiate(playerBullet0Prefabs, transform);
            go.SetActive(false);
            playerBullet0List.Add(go);
        }
        //playerBullet0List 를 순회하면서 사용가능한 총알이 있는지 검사한다
        for (int i = 0; i < playerBullet0List.Count; i++)
        {
            GameObject go = Instantiate(playerBullet0Prefabs,transform);
            go.SetActive(false);
            playerBullet0List.Add(go);

        }

        if (foundPlayerBullet0Go == null)
        {
            foundPlayerBullet0Go = Instantiate(playerBullet0Prefabs);
            foundPlayerBullet0Go.transform.SetParent(this.transform); //인스탄티에이트에다가 페어런트 하는법과, 나중에 부모를 만드는건 다름
            foundPlayerBullet0Go.SetActive(false);
            playerBullet0List.Add(foundPlayerBullet0Go);
            
        }
        return  foundPlayerBullet0Go;
    }

    public void ReleasePlayerBullet0Go(GameObject playerBullet0Go)
    {
        playerBullet0Go.SetActive(false);
        playerBullet0Go.transform.localPosition = Vector3.zero; 
        // ObjectPoolManager이 부모인 플레이어 불렛이 생성되고 화면밖에 나갔을때 포지션을 0으로 초기화 시킬때
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
