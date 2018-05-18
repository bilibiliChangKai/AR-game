


using UnityEngine;
using System.Collections;

public class monsterCollision : MonoBehaviour
{

    private Animator _animator;
    double blood;
    double time;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        blood = 100;
        time = 3;
        player = GameObject.Find("WK_heavy_infantry");
        _animator = this.GetComponent<Animator>();
        _animator.SetBool("combat", false);
        _animator.SetBool("dead", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator.GetBool("combat"))
        {
            blood -= 0.1;
        }
        if (_animator.GetBool("dead"))
        {
            time -= 0.01;
        }
        if (blood <= 0)
        {
            _animator.SetBool("combat", false);
            _animator.SetBool("dead", true);
        }
        if (time <= 0)
        {
            this.gameObject.SetActive(false);
        }
        if (player.GetComponent<Animator>().GetBool("dead"))
        {
            _animator.SetBool("combat", false);
        }
    }




    // 碰撞开始
    void OnCollisionEnter(Collision collision)
    {
        
        print("OnCollisionEnter");
       
       // _animator.SetBool("walk", false);
        _animator.SetBool("combat", true);
        //Destroy(this.gameObject);
    }

    // 碰撞结束
    void OnCollisionExit(Collision collision)
    {
        _animator.SetBool("combat", false);
    }

    // 碰撞持续中
    void OnCollisionStay(Collision collision)
    {

    }

}