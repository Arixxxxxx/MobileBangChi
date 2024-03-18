using UnityEngine;

namespace NotSlot.HandPainted2D.Desert
{
  public sealed class DustStormFX : MonoBehaviour
  {
    #region Constants

    private const float RATIO = 0.03f;

    #endregion


    #region Inspector

    [Min(1)]
    [SerializeField]
    private float width = 5;

    #endregion


    #region MonoBehaviour

    private void OnValidate ()
    {
      ParticleSystem particles = GetComponent<ParticleSystem>();

      ParticleSystem.ShapeModule shape = particles.shape;
      Vector3 shapeScale = shape.scale;
      shapeScale.x = width;
      shape.scale = shapeScale;

      ParticleSystem.EmissionModule emission = particles.emission;
      emission.rateOverTime = width * RATIO;

      ParticleSystem.MainModule main = particles.main;
      main.maxParticles = Mathf.CeilToInt(
        main.startLifetime.constant *
        emission.rateOverTime.constant);
    }

    #endregion
  }
}