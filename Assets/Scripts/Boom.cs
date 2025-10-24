using UnityEngine;
using System;
using System.Collections;
public class Boom : MonoBehaviour
{
    public Action onFinishBoom;
    

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.25f);
        onFinishBoom?.Invoke();
    }
}
