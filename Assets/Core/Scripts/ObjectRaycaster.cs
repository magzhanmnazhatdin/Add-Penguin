using UnityEngine;

public class ObjectRaycaster : MonoBehaviour
{
    private IHoverable _currentHover;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            if (hitInfo.rigidbody == null)
            {
                HoverExit();
                return;
            }
            if (hitInfo.rigidbody.TryGetComponent(out IHoverable hoverable))
            {
                if (_currentHover == hoverable) return;
                HoverExit();
                hoverable.OnHoverEnter();
                _currentHover = hoverable;
            }
            else HoverExit();
        }
        else HoverExit();
    }

    private void HoverExit()
    {
        if (_currentHover != null)
        {
            _currentHover.OnHoverExit();
            _currentHover = null;
        }
    }
}
