using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Draggable : MonoBehaviour
{
    private const int DefaultLayerValue = 0;
    private const int DraggableLayerValue = 6;
    private const string TagOfDraggableItem = "Draggable";
    private Rigidbody _rigidbody;

    void Start()
    {
        this.gameObject.tag = TagOfDraggableItem;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void PrepareForDrag()
    {
        this.gameObject.layer = DraggableLayerValue;
        _rigidbody.useGravity = false;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }
    public void PrepareForDrop()
    {
        this.gameObject.layer = DefaultLayerValue;
        _rigidbody.useGravity = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
    }
}
