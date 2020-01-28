using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public RotateCamera compRotateCamera;
    public MenuInteractivoInGame _pausa;
    private float initialPosX;

	void Start ()
    {
        initialPosX = transform.position.x;
	}
	
	void Update ()
    {
        float rotZ = compRotateCamera.GetCurrentRotationZ();

        if (_pausa.IsPause == false)
        {
            transform.position = new Vector3(initialPosX + rotZ, transform.position.y, transform.position.z);
        }
    }
}
