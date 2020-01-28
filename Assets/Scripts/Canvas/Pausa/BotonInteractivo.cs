using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonInteractivo : MonoBehaviour {
    public bool Touch = false;
    public bool ActivarBoton = false;
    public float CooldownBoton = 1f;

	void Update ()
    {
        if (Touch)
        {
            CoolDown();
        }
        else
        {
            CooldownBoton = 1f;
        }
        if (CooldownBoton <= 0)
        {
            ActivarBoton = true;
        }
	}
    void CoolDown()
    {
        CooldownBoton -= 1 * Time.deltaTime; 
    }
}
