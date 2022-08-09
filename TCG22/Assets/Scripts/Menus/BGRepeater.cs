using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRepeater : MonoBehaviour
{
    private float speed;
    public Vector3 startPos;
    public float repeatWidth;
    public float x;

    void Start()
    {
        speed = 5f;
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        x = startPos.x - repeatWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }
}
