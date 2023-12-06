using UnityEngine;

public class VignetteController : MonoBehaviour
{
    [SerializeField]
    private float maxVignetteAperture = 1.0f;

    [SerializeField]
    private float minVignetteAperture = 0.0f;

    [SerializeField]
    private float transitionSpeed = 0.5f;

    [SerializeField]
    private string shaderParameterName = "_ApertureSize";

    [SerializeField]private Material material;
    [SerializeField]private Rigidbody playerRigidbody;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (material != null && playerRigidbody != null)
        {
            float targetAperture = CalculateTargetAperture();

            float currentAperture = material.GetFloat(shaderParameterName);
            float newAperture = Mathf.Lerp(currentAperture, targetAperture, transitionSpeed * Time.deltaTime);

            material.SetFloat(shaderParameterName, newAperture);
        }
    }

    private float CalculateTargetAperture()
    {
        // Invierte la lógica: apertura máxima cuando está en movimiento, apertura mínima cuando está quieto.
        float targetAperture = playerRigidbody.velocity.magnitude > 0.1f ? minVignetteAperture : maxVignetteAperture;

        return targetAperture;
    }
}
