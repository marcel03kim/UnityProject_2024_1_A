using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleObject : MonoBehaviour
{
    public bool isDrag;
    public bool isUsed;
    Rigidbody2D rb;

    public int index;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isUsed = false;
        rb.simulated = false;
    }
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

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float leftBorder = -5.0f + transform.localScale.x / 2f;
            float rightBorder = 5.0f - transform.localScale.x / 2f;

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;
            mousePos.z = 0;
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);
        }

        if (Input.GetMouseButtonDown(0)) Drag();
        if (Input.GetMouseButtonUp(0)) Drop();
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

        GameObject temp = GameObject.FindWithTag("GameManager");
        if(temp != null)
        {
            temp.gameObject.GetComponent<GameManager>().GenObject();
        }
    }

    public void Used()
    {
        isDrag = false;
        isUsed = true;
        rb.simulated = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (index >= 7)
            return;

        if(collision.gameObject.tag == "fruit")
        {
            circleObject temp = collision.gameObject.GetComponent<circleObject>();

            if(temp.index == index)
            {
                if(gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
                {
                    GameObject tempGameManager = GameObject.FindWithTag("GameManager");
                    if (tempGameManager != null)
                    {
                        tempGameManager.gameObject.GetComponent<GameManager>().MergeObject(index, gameObject.transform.position);
                    }
                    Destroy(temp.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}
