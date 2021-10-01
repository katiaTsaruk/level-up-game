using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Camera MainCamera;
    void Start()
    {
        
    }
    
    void Update()
    {
        Move();
        MainCamera.transform.position =Vector3.Lerp(MainCamera.transform.position, new Vector3(this.transform.position.x, this.transform.position.y,-10) ,0.01f);
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.up * speed );
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.down * speed );
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * speed );
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * speed );
        }
    }
}
