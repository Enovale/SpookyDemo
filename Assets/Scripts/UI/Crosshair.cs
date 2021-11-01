using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Crosshair : MonoBehaviour
{
    [SerializeField] private PlayerCaster _caster;

    private RectTransform _transform;
    private Vector2 _origScale;
    private Vector2 _bigScale;

    private void Awake()
    {
        _transform = (RectTransform)transform;
        _origScale = _transform.localScale;
        _bigScale = _origScale * 2;
    }

    private void Update()
    {
        var scale = _transform.localScale;
        _transform.localScale = _caster.SelectedObject != null
            ? Vector2.Lerp(scale, _bigScale, Time.deltaTime * 5)
            : Vector2.Lerp(scale, _origScale, Time.deltaTime * 5);
    }
}