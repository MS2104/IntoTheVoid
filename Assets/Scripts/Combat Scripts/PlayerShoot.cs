using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Creëer schiet & herlaad acties.
    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadKey;

    private void Update()
    {
        // Als je de linker muis knop indrukt dan schiet je.
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("LMB pressed");
            shootInput?.Invoke();
        }

        // Als je op R of de reload key drukt dan herlaad je je wapen.
        if (Input.GetKey(reloadKey))
        {
            Debug.Log("Key R pressed!");
            reloadInput?.Invoke();
        }
    }
}
