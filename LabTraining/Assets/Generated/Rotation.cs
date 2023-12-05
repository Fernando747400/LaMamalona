using UnityEngine;
using NaughtyAttributes;
using Obvious.Soap;

public class Rotation : MonoBehaviour {

    [Header("Dependencies")]

    [Header("Event Channels SO")]
    [Required]
    [SerializeField] private ScriptableEventBool _rotateFanChannel;

    [Header("Settings")]
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private bool _canRotate = true;

    private void OnEnable()
    {
        _rotateFanChannel.OnRaised += CanRotate;
        CanRotate(_canRotate);
    }

    private void OnDisable()
    {
        _rotateFanChannel.OnRaised -= CanRotate;
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (!_canRotate) return;
        transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);
    }

    private void CanRotate(bool canRotate)
    {
        _canRotate = canRotate;
    }
}