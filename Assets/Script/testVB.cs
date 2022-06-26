using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class testVB : MonoBehaviour , IVirtualButtonEventHandler
{

    public float rotationSpeed; 
    Vector3 scale;
    public GameObject Models;
     VirtualButtonBehaviour [] VBS;
    bool IsPressed = false;

    void Start()
    {
        VBS = GetComponentsInChildren<VirtualButtonBehaviour>();
        foreach (var vb in VBS)
        {
            vb.RegisterEventHandler(this);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (IsPressed)
        {

            Debug.LogWarning("Still_Pressed");
            /* for (int i = 0; i < Models.Length; i++)
             {
                 Models[i].transform.localScale += new Vector3(1f * Time.deltaTime, 1f * Time.deltaTime, 1f * Time.deltaTime);

             }*/
            Models.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);


        }
    }
    public void OnButtonPressed(VirtualButtonBehaviour btn)
    {
        if (btn.VirtualButtonName == "Link")
        {
            Debug.Log("Linkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk");
            Application.OpenURL("https://www.dunkindonuts.com/en/menu/donuts/product-donuts-id1001201");
           
        }

       
        if (btn.VirtualButtonName == "rotate")
        {
            // IsPressed = true;
            IsPressed = true;
            Debug.Log("Pressed");

        }

    }

    public void OnButtonReleased(VirtualButtonBehaviour btn)
    {
        if (btn.VirtualButtonName == "rotate")
        {
            IsPressed = false;
            Debug.Log("released");
        }

    }
}


/* public void setScale(int index)
 {
     if (index >= 0 && index < Models.Length)
     {
         for (int i = 0; i < Models.Length; i++)
         {
             Models[i].transform.localScale = scale;
         }
         scale = transform.localScale;
         scale.x += Time.deltaTime;
     }
 }
/* public void setupScale()
 {

         for (int i = 0; i < Models.Length; i++)
         {
             Models[i].transform.localScale = scale;
         }
         scale = transform.localScale;
         scale.x += Time.deltaTime;

 }*/
