using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Test : MonoBehaviour, IVirtualButtonEventHandler
{
   public VirtualButtonBehaviour[] virtualButtonBehaviours;
    string vbName;
    public GameObject Human, fantasy, soilders;

    void Start()
    {
        //Register with the virtual buttons TrackableBehaviour
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < virtualButtonBehaviours.Length; i++)
            virtualButtonBehaviours[i].RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        vbName = vb.VirtualButtonName;

        if (vbName == "Scale")
        {
            Debug.Log("Pressed");
            Human.transform.localScale += new Vector3(1f * Time.deltaTime, 1f * Time.deltaTime, 1f * Time.deltaTime);

        }

        else if (vbName=="Reset")
        {
           
        }
       
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }


}

   

