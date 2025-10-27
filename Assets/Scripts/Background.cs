using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Vector3 = UnityEngine.Vector3;

public class Background : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;

    private float viewHeight;

    void Start()
    {
       this.viewHeight= Camera.main.orthographicSize *2; 
    }
       
    void Update()
    {
        Move();
        Scrolling();
    }

    void Move()
    {
        Vector3 currentPos = this.transform.position;
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        this.transform.position = currentPos + nextPos;
    }
    void Scrolling()
    {
        /*Vector3 currentPos = this.transform.position;
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        this.transform.position = currentPos + nextPos;*/

        if (sprites[endIndex].position.y < -viewHeight)
        {
            //Debug.LogError($"{startIndex},{endIndex}");
            Vector3 backSpritePos = sprites[startIndex].transform.localPosition;
            sprites[endIndex].localPosition = backSpritePos+ Vector3.up * viewHeight;
            
            startIndex = endIndex;
            endIndex = (startIndex +1 ) % sprites.Length;
        }

        /*int startIndexSave = startIndex;
        startIndex = endIndex;

        if (startIndexSave - 1 == -1)
        {
            endIndex = sprites.Length - 1;
            
        }
        else
        {
            endIndex = startIndexSave - 1;
        }*/
       

    }
 
}
