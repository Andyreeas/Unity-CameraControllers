using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action OnKeyboardSpaceDown = delegate { };
    void Update()
    {
        if (Input.GetKeyDown("space")) 
        {
            OnKeyboardSpaceDown();
            Debug.Log("OnKeyboardSpaceDown() fire in the hole");
        }
    }
}
