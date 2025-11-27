using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wmelee : MonoBehaviour
{
    public Rigidbody rigid;
    public AudioSource emitter;
    public AudioClip audio;
    public BoxCollider blade;
    public int threshold;
    public int multiplier;
    public LayerMask layer;

    private void FixedUpdate()
    {
        if (rigid.velocity.magnitude > threshold)
        {
            blade.isTrigger = true;
        }
        else
        {
            blade.isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.root.gameObject.layer == layer)
        {
            emitter.PlayOneShot(audio);
            collision.transform.root.gameObject.GetComponent<health>().hp -= (int)(rigid.velocity.magnitude / multiplier);
        }
    }
}
