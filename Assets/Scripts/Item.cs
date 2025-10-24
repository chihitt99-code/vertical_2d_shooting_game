using UnityEngine;

public class Item : MonoBehaviour
{
    
    public enum ItemType
    {
        Boom,
        Coin,
        Power
    }
    public ItemType itemType;
    public float speed = 1f;
    
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
