using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Vuforia;

public class collider_army : MonoBehaviour {





    private GameObject player;

    private Animator _animator;
    double blood;
    double time;
    // Use this for initialization
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        blood = 30;
         time = 1;
        _animator.SetBool("walk", false);
        _animator.SetBool("attack", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator.GetBool("attack"))
        {
            blood -= 0.05;
        }
        if (_animator.GetBool("dead"))
        {
            time -= 0.01;
        }
        if (blood <= 0)
        {
            _animator.SetBool("attack", false);
            _animator.SetBool("walk", false);
            _animator.SetBool("dead", true);
           
            //this.gameObject.SetActive(false);
        }
        if (time <= 0)
        {
            this.gameObject.SetActive(false);
        }


    }




    // 碰撞开始
    void OnCollisionEnter(Collision collision)
    {
        // 销毁当前游戏物体
        print("OnCollisionEnter");
        GameObject rootObj = GameObject.Find("pic");
        //player = transform.FindChild("WK_heavy_infantry").gameObject;
        VirtualButtonBehaviour[] vbs = rootObj.GetComponentsInChildren<VirtualButtonBehaviour>();
        
        _animator.SetBool("walk", false);
        _animator.SetBool("attack", true);
        //Destroy(this.gameObject);
    }

    // 碰撞结束
    void OnCollisionExit(Collision collision)
    {
        _animator.SetBool("attack", false);
        _animator.SetBool("walk", true);
    }

    // 碰撞持续中
    void OnCollisionStay(Collision collision)
    {

    }

}

