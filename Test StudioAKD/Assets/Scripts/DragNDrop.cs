using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    private const string _tag = "Object";
    [SerializeField] private int _maxRayDistance = 3;
    [SerializeField] private int _speedDrag = 5;
    [SerializeField] private Transform _playerCamera;
    [SerializeField] private Transform _hand;
    [SerializeField] private LayerMask _defaultLayerMask;
    private GameObject _dragObject;
    private Rigidbody _rbDragObject;
   
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(_playerCamera.position,_playerCamera.forward, out hit, _maxRayDistance,_defaultLayerMask))
        {
            if (hit.transform.CompareTag(_tag))
            {
                if(Input.GetKey(KeyCode.Mouse0))
                {
                    PrepareForDrag(hit);
                }
            }
        }
        if (_dragObject != null)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Drop();
            }
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _dragObject != null)
        {
            Drag();
        }
    }
    private void Drag()
    {
        Vector3 dragDirection = _hand.position - _dragObject.transform.position;
        _rbDragObject.velocity = dragDirection * _speedDrag;
    }
    private void Drop()
    {
        _dragObject.GetComponent<Draggable>().PrepareForDrop();
        _dragObject = null;
        _rbDragObject = null;
    }
    private void PrepareForDrag(RaycastHit hit)
    {
        _dragObject = hit.transform.gameObject;
        _rbDragObject = _dragObject.GetComponent<Rigidbody>();
        _dragObject.GetComponent<Draggable>().PrepareForDrag();
    }
}
