using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DeadCondition : MonoBehaviour
{
    public bool _dead;
    public GameObject _particulas;
    [Range(0,5)]
    public float _separacion;
    [Range(0,5)]
    public float _distance;

    private Vector3 Izq;
    private Vector3 Der;

    private GameObject[] _ObsList;

    private void Update()
    {
        Izq = new Vector3(transform.position.x + _separacion, transform.position.y, transform.position.z);
        Der = new Vector3(transform.position.x - _separacion, transform.position.y, transform.position.z);

        RaycastHit hit;
        if(Physics.Raycast(Izq, transform.forward, out hit, _distance))
        {
            if(hit.collider.tag == "Enemy")
            {
                _dead = true;
            }
        }
        RaycastHit hit2;
        if(Physics.Raycast(Der, transform.forward, out hit2, _distance))
        {
            if (hit2.collider.tag == "Enemy")
            {
                _dead = true;
            }
        }

        if (_dead)
        {
            Instantiate(_particulas, transform.position, transform.rotation);
            _ObsList = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < _ObsList.Length; i++)
            {
                Destroy(_ObsList[i].gameObject);
            }
            this.enabled = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Izq, transform.forward * _distance);
        Gizmos.DrawRay(Der, transform.forward * _distance);
    }
}
