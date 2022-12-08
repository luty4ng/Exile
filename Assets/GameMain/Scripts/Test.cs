using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameKit.Runtime;

public class Test : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Log.Info(1111);
    }
}
