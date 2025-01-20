using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private int _screenEdgeWidth = 5;
    [SerializeField] private Vector2 _moveSpeed = new (5, 5);
    [SerializeField] private Collider _bounds;
    
    private void Update()
    {
        if (Application.isFocused)
            Move(CalculateMoveVector());
    }

    private bool IsInBounds(Vector3 position)
    {
        return (_bounds.ClosestPoint(position) - position).magnitude < 0.01f;
    }

    private void Move(Vector3 moveVector)
    {
        var delta = new Vector3(_moveSpeed.x * Time.deltaTime * moveVector.x, 0, _moveSpeed.y * Time.deltaTime * moveVector.z) ;
        if (!IsInBounds(transform.position + transform.rotation * new Vector3(delta.x, 0, 0)))
            delta.x = 0;
        if (!IsInBounds(transform.position + transform.rotation * new Vector3(0, 0, delta.z)))
            delta.z = 0;
        transform.Translate(delta, Space.Self);
    }

    private Vector3 CalculateMoveVector()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 moveVector = Vector3.zero;
        
        if (mousePosition.x < _screenEdgeWidth) moveVector += Vector3.left;
        else if (mousePosition.x > Screen.width - _screenEdgeWidth) moveVector += Vector3.right;
        
        if (mousePosition.y < _screenEdgeWidth) moveVector += Vector3.back;
        else if (mousePosition.y > Screen.height - _screenEdgeWidth) moveVector += Vector3.forward;

        return moveVector;
    }
}
