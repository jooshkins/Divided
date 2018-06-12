using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    public float Strength = 2.0f;
    public float Dampening = 4.0f;
    private Rigidbody2D _rigidbody;

    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            var mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition).ToVector2();
            if(_rigidbody == null)
            {
                var hit = Physics2D.Raycast(mouseWorldPoint, Vector2.zero, 0.0f);
                if(hit.collider != null)
                {
                    _rigidbody = hit.collider.attachedRigidbody;
                }
            }

            if(_rigidbody != null)
            {
                var deltaVelocity = (((mouseWorldPoint - _rigidbody.position) * Strength) - (_rigidbody.velocity * Dampening)) * Time.fixedDeltaTime;
                _rigidbody.velocity += deltaVelocity;
            }
        }
        else
        {
            _rigidbody = null;
        }
    }
}