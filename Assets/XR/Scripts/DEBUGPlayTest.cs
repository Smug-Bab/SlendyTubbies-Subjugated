using UnityEngine;

public class DEBUGPlayTest : MonoBehaviour
{
public AudioClip clip;

    void Start()
    {
        transform.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
