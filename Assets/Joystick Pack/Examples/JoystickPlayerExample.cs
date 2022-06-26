using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickPlayerExample : MonoBehaviour ,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    //public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
   // bool walking;
  //  Vector3 move;
    
    public GameObject player;
    Vector3 move;
    public float speed;
    bool walking;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        move = new Vector3(transform.localPosition.x, 0f, transform.localPosition.y).normalized;
       // transform.localPosition =
       // Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);
        if (!walking)
        {
            walking = true;
            rb.GetComponent<Animator>().SetBool("walk", true);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        move = Vector3.zero;
        walking = false;
        //  StopCoroutine("PlayerMove");
        StopCoroutine(PlayerMovement());
        rb.GetComponent<Animator>().SetBool("walk", false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(PlayerMovement());



    }

    IEnumerator PlayerMovement()
    {
        while (true)
        {
            rb.transform.Translate(move * speed * Time.deltaTime, Space.World);
            if (move != Vector3.zero)
            {
                rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * 5.0f);
            }
            yield return null;
        }
    }
}

       /* Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        if (!walking)
        {
            walking = true;
            rb.GetComponent<Animator>().SetBool("walk", true);
            StartCoroutine(PlayerMovement());
        }
        IEnumerator PlayerMovement()
        {
            while (true)
            {
                rb.transform.Translate(move * speed * Time.deltaTime, Space.World);
                if (move != Vector3.zero)
                {
                    rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * 5.0f);
                }
                yield return null;
            }
        }
    }
}*/