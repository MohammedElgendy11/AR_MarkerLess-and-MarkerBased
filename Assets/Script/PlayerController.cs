using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    public FixedJoystick moveJoy;
    //public VariableJoystick LookJoy;
    public float speed = 5f;
    Rigidbody rb;
    bool walking;
    Vector3 move;

    private float dirx, diry,dirz, movespeed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        movespeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        dirx = moveJoy.Horizontal;
        dirz = moveJoy.Vertical;
        //diry = LookJoy.Vertical;
        Vector3 moveDirection = transform.right * dirx + transform.forward * dirz; //Direction of movement
        Vector3 lookDirection = new Vector3(0, diry, 0); //Direction of look rotation
        rigidbody.AddForce(moveDirection * Time.deltaTime, ForceMode.VelocityChange); 
        transform.Rotate(lookDirection * speed * Time.deltaTime);
        if (!walking)
        {
            walking = true;
            gameObject.GetComponent<Animator>().SetBool("walk", true);
        }
    }

    IEnumerator PlayerMove()
    {
        while (true)
        {
            
            gameObject.transform.Translate(move * speed * Time.deltaTime, Space.World);
            if (move != Vector3.zero)
            {
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);
            }
        }
    }
}
