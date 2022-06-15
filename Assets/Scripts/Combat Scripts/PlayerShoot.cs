using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadKey = KeyCode.R;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Shot");
            shootInput?.Invoke();
        }

        if (Input.GetKeyDown(reloadKey))
        {
            Debug.Log("Reloading");
            reloadInput?.Invoke();
        } 
    }
}