using UnityEngine;
using NaughtyAttributes;
using System.Collections.Generic;

public class SizePicker : MonoBehaviour
{
    [Header("Dependencies")]
    [Required][SerializeField] private Material _activeButton;
    [Required][SerializeField] private Material _inactiveButton;

    [SerializeField] private List<GameObject> _sizes = new List<GameObject>();
    [SerializeField] private List<Renderer> _sizeButtons = new List<Renderer>();
    [SerializeField] private List<ResetContraption> _resetContraptions = new List<ResetContraption>();

    private int _activeSizeIndex = 0;

    private void Start()
    {
        ToggleSize(0);
    }

    public void ToggleSize(int sizeIndex)
    {
        // Deactivate the currently active size
        _sizes[_activeSizeIndex].SetActive(false);
        ChangeMaterial(_sizeButtons[_activeSizeIndex], false);

        // Activate the new size
        _sizes[sizeIndex].SetActive(true);
        ChangeMaterial(_sizeButtons[sizeIndex], true);
        _resetContraptions[sizeIndex].ResetObjects();

        _activeSizeIndex = sizeIndex;
    }

    private void ChangeMaterial(Renderer buttonRenderer, bool isOn)
    {
        Material materialToChange = isOn ? _inactiveButton : _activeButton;

        Material[] newMaterials = buttonRenderer.materials.Clone() as Material[];
        newMaterials[0] = materialToChange;
        buttonRenderer.materials = newMaterials;
    }
}
