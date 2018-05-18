using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_right : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.Rotate(new Vector3(0, 90, 0));
    }
	
	// Update is called once per frame
	void Update () {
        float MoveSpeed = 0.1f;
        Vector3 transformValue = new Vector3(MoveSpeed, 0, 0);
        transformValue = transformValue * Time.deltaTime;
        transform.Translate(transformValue, Space.World);
    }
}
