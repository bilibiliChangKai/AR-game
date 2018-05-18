using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class MyVBHandler : MonoBehaviour, IVirtualButtonEventHandler
{
    private GameObject player;
    private Animator _animator;
    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        
        switch (vb.VirtualButtonName)
        {
            case "VirtualButton_left":
                if (!player.GetComponent<move_left>())
                {
                    player.AddComponent<move_left>();
                }
                //print("ok");
                _animator.SetBool("walk", true);
                break;

            case "VirtualButton_down":
                if (!player.GetComponent<move_down>())
                {
                    player.AddComponent<move_down>();
                }
                _animator.SetBool("walk", true);
                break;
            case "VirtualButton_right":
                if (!player.GetComponent<move_right>())
                {
                    player.AddComponent<move_right>();
                }
                _animator.SetBool("walk", true);
                //print("ok");
                break;
                
            case "VirtualButton_up":
                if (!player.GetComponent<move_up>())
                {
                    player.AddComponent<move_up>();
                }
                _animator.SetBool("walk", true);
                break;
        }
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "VirtualButton_left":
                if (player.GetComponent<move_left>())
                {
                    Destroy(player.GetComponent<move_left>()); 
                }
                //print("ok");
                player.transform.Rotate(0, -270, 0);
                _animator.SetBool("walk", false);
                break;

            case "VirtualButton_down":
                if (player.GetComponent<move_down>())
                {
                    Destroy(player.GetComponent<move_down>());
                }
                player.transform.Rotate(0, 180, 0);
                _animator.SetBool("walk", false);
                break;
            case "VirtualButton_right":
                if (player.GetComponent<move_right>())
                {
                    Destroy(player.GetComponent<move_right>());
                }
                player.transform.Rotate(0, -90, 0);
                _animator.SetBool("walk", false);
                //print("ok");
                break;

            case "VirtualButton_up":
                if (player.GetComponent<move_up>())
                {
                    Destroy(player.GetComponent<move_up>());
                }
                _animator.SetBool("walk", false);
                break;
        }
    }

    // Use this for initialization  
    void Start()
    {
       
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
        }
        player = transform.FindChild("WK_heavy_infantry").gameObject;
        _animator = player.GetComponent<Animator>();

    }

}