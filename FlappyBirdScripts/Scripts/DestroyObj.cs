using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public float timeCount = 5;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyMethod", timeCount);
    }

    // Update is called once per frame
    void DestroyMethod()
    {
        Destroy(this.gameObject);
    }
}
