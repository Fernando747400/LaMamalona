using UnityEngine;
using NaughtyAttributes;
using Obvious.Soap;

public class Bulb : MonoBehaviour
{
    [Header ("Dependencies")]

    [Header("Event Channels SO")]
    [Required]
    [SerializeField] private ScriptableEventBool _changeBulbState;

    [Header("Materials")]
    [Required]
    [SerializeField] private Material _onMaterial;
    [Required]
    [SerializeField] private Material _offMaterial;
    [Min(0f)]
    [SerializeField] private int _materialIndex = 0;
    [Required]
    [SerializeField] private Renderer _renderer;

    [Header("GameObjects")]
    [Required]
    [SerializeField] private GameObject _pointLight;

    [Header("Initial value")]
    [SerializeField] private bool _isOnAtStart = true;

    private void OnEnable()
    {
        _changeBulbState.OnRaised += ChangeBulbState;
    }

    private void OnDisable()
    {
        _changeBulbState.OnRaised -= ChangeBulbState;
    }

    private void Start()
    {
        ChangeBulbState(_isOnAtStart);
    }

    private void ChangeBulbState(bool state)
    {
        _pointLight.SetActive(state);
        ChangeMaterial(state);
    }

    private void ChangeMaterial(bool isOn)
    {
        Material materialToChange = isOn? _onMaterial : _offMaterial;

        Material[] newMaterials = _renderer.materials.Clone() as Material[];
        newMaterials[_materialIndex] = materialToChange;
        _renderer.materials = newMaterials;
    }
}
