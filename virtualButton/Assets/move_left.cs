using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_left : MonoBehaviour {

    private void Start()
    {
        transform.Rotate(new Vector3(0, 270, 0));
    }

    //控制物体向Target移动  
    void Update()
    {
        float MoveSpeed = -0.1f;
        Vector3 transformValue = new Vector3(MoveSpeed, 0,0);
        transformValue = transformValue * Time.deltaTime;
        transform.Translate(transformValue, Space.World);
    }
}
