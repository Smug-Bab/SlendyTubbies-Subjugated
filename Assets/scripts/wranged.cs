using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class wranged : MonoBehaviour
{
    public InputActionReference controller;
    public AudioSource emitter;
    public AudioClip audio;
    public int maxdistance;
    public LayerMask layer;
    public Vector3 barrel;
    public Vector3 forward;
    public int damage;
    private RaycastHit hit;

    private void FixedUpdate()
    {
        Debug.DrawRay(barrel, forward, Color.white);
    }

    private void OnEnable()
    {
        controller.action.started += shoot;
    }

    private void OnDisable()
    {
        controller.action.started -= shoot;
    }

    void shoot(InputAction.CallbackContext context)
    {
        emitter.PlayOneShot(audio);
        if (Physics.Raycast(barrel, forward, out hit, maxdistance, layer))
        {
            hit.transform.root.gameObject.GetComponent<health>().hp -= damage;
        }
        else
        {
        }
    }
}
