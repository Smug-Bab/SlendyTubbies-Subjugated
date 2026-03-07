using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class health : MonoBehaviour
{
    public int hp = 100;
    public TMP_Text text;

    private void Update()
    {
        text.SetText(hp.ToString());
    }
}
