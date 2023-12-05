using UnityEngine;
using NaughtyAttributes;
using Obvious.Soap;

public class BulbSwitch : MonoBehaviour
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
    
    private bool _isOn;
    
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
        _isOn = _isOnAtStart;
        ChangeBulbState(_isOn);
    }

    private void ChangeBulbState(bool state)
    {
        _isOn = !_isOn;
        _pointLight.SetActive(_isOn);
        ChangeMaterial(_isOn);
    }

    private void ChangeMaterial(bool isOn)
    {
        Material materialToChange = isOn? _onMaterial : _offMaterial;

        Material[] newMaterials = _renderer.materials.Clone() as Material[];
        newMaterials[_materialIndex] = materialToChange;
        _renderer.materials = newMaterials;
    }
}