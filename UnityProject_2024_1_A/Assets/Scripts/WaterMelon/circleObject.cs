using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleObject : MonoBehaviour
{
    public bool isDrag;
    public bool isUsed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isUsed = false;
        isDrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed)
            return;

    }

    void Drag()
    {
        isDrag = true;
        rb.simulated = false;
    }

    void Drop()
    {
        isDrag = false;
        isUsed = true;
        rb.simulated = true;
    }
}
