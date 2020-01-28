using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour {

    public GameObject[] _limites;

	void Update ()
    {
        Limites();
    }
    public void Limites()
    {
        if(transform.position.x > _limites[1].transform.position.x)
        {
            transform.position = new Vector3(_limites[1].transform.position.x, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < _limites[0].transform.position.x)
        {
            transform.position = new Vector3(_limites[0].transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
