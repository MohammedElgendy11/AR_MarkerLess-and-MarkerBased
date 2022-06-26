using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{

}
   /* public Transform player;
    Vector3 move;
    public float speed;

    public void OnDrag(PointerEventData eventData)
    {
        move = new Vector3(transform.localPosition.x , 0 , transform.localPosition.y).normalized;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        move = Vector3.zero;
        StopCoroutine("PlayerMove");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine("PlayerMove");
    }
    IEnumerator PlayerMove()
    {
        while (true)
        {
            player.Translate(move * speed * Time.deltaTime, Space.World);
            if (move != Vector3.zero)
            {
                player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);
            }
        }
    }
}*/