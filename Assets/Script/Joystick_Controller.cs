using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Joystick_Controller : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform pad;
    public GameObject player;
    Vector3 move;
    public float speed;
    bool walking;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        move = new Vector3(transform.localPosition.x, 0f, transform.localPosition.y).normalized;
        transform.localPosition =
        Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position , pad.rect.width * 0.5f);
        if (!walking)
        {
            walking = true;
            player.GetComponent<Animator>().SetBool("walk", true);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        move = Vector3.zero;
        walking = false;
      //  StopCoroutine("PlayerMove");
        StopCoroutine(PlayerMovement());
        player.GetComponent<Animator>().SetBool("walk", false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(PlayerMovement());
    }

    IEnumerator PlayerMovement()
    {
        while (true)
        {
            player.transform.Translate(move * speed * Time.deltaTime, Space.World);
            if (move != Vector3.zero)
            {
                player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(move),Time.deltaTime * 5.0f);
            }
            yield return null;
        }
    }




}
