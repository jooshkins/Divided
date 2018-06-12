using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MySquashStretch : MonoBehaviour
{
    public Transform Sprite;
    public float Stretch = 0.1f;

    private Rigidbody2D _rigidbody;
    private Transform _squashParent;
    private Vector3 _originalScale;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _squashParent = new GameObject(string.Format("_squash_{0}", name)).transform;
        _originalScale = Sprite.transform.localScale;
    }

    private void FixedUpdate()
    {
        Sprite.parent = transform;
        Sprite.localPosition = Vector3.zero;
        Sprite.localScale = _originalScale;
        Sprite.localRotation = Quaternion.identity;

        _squashParent.localScale = Vector3.one;
        _squashParent.position = transform.position;

        var velocity = _rigidbody.velocity.ToVector3();
        if(velocity.sqrMagnitude > 0.01f)
        {
            _squashParent.rotation = Quaternion.FromToRotation(Vector3.right, velocity);
        }

        var scaleX = 1.0f + (velocity.magnitude * Stretch);
        var scaleY = 1.0f / scaleX;
        Sprite.parent = _squashParent;
        _squashParent.localScale = new Vector3(scaleX, scaleY, 1.0f);
    }
}