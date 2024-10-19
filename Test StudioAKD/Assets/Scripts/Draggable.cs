using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Draggable : MonoBehaviour
{
    private const string _tagOfDraggableItem = "Object";
    private Rigidbody _rB;

    void Start()
    {
        this.gameObject.tag = _tagOfDraggableItem;
        _rB = GetComponent<Rigidbody>();
    }    
    public void PrepareForDrag()
    {
        _rB.useGravity = false;
        _rB.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }
    public void PrepareForDrop()
    {
        _rB.useGravity = true;
        _rB.collisionDetectionMode = CollisionDetectionMode.Discrete;
    }

}
