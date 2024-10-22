using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Drag : MonoBehaviour
{
    private const string Tag = "Draggable";

    [SerializeField] private int _speedOfDrag = 5;
    [SerializeField] private int MaxRayDistance = 3;

    [SerializeField] private Transform _playerCamera;
    [SerializeField] private Transform _picUpSocet;

    [SerializeField] private LayerMask _defaultLayerMask;

    private GameObject _draggableObject;
    private Rigidbody _rbOfDraggableObject;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(_playerCamera.position, _playerCamera.forward, out hit, MaxRayDistance, _defaultLayerMask))
        {
            if (hit.transform.CompareTag(Tag))
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    PrepareForDrag(hit);
                }
            }
        }
        if (_draggableObject != null)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
                Drop_();
        }

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _draggableObject != null)
            Drag_();

    }
    private void Drag_()
    {
        Vector3 dragDirection = _picUpSocet.position - _draggableObject.transform.position;
        _rbOfDraggableObject.velocity = dragDirection * _speedOfDrag;
    }
    private void Drop_()
    {
        _draggableObject.GetComponent<Draggable>().PrepareForDrop();
        _draggableObject = null;
        _rbOfDraggableObject = null;
    }
    private void PrepareForDrag(RaycastHit hit)
    {
        _draggableObject = hit.transform.gameObject;
        _rbOfDraggableObject = _draggableObject.GetComponent<Rigidbody>();
        _draggableObject.GetComponent<Draggable>().PrepareForDrag();
    }
}
