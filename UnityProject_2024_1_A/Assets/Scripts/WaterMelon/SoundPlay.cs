using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SoundManager.instance.PlaySound("bgm");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SoundManager.instance.PlaySound("cannon");
        }
    }
}
