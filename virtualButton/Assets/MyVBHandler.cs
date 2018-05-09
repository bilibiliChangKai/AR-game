using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class MyVBHandler : MonoBehaviour, IVirtualButtonEventHandler
{
    Material m1;
    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        m1.color = Color.red;
        print("VBPressed    " + vb.VirtualButton.Area.leftTopX);
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        m1.color = Color.white;
    }

    // Use this for initialization  
    void Start()
    {
        m1 = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);//把ImageTarget下所有含有VirtualButtonBehaviour组件的物体注册过来（使用前面写的Pressed和Released方法处理）。  
        }

    }

}