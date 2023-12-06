using UnityEngine;

public class EnableVignette : MonoBehaviour
{
    [SerializeField] private GameObject _vignette;

    private void Start()
    {
        _vignette.SetActive(true);
    }

    public void ActivateVignette()
    {
        _vignette.SetActive(true);
    }
    
    public void DeactivateVignette()
    {
        _vignette.SetActive(false);
    }
}
