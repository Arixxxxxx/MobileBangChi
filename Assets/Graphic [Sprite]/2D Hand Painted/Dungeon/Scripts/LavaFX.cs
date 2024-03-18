using UnityEngine;

namespace NotSlot.HandPainted2D.Dungeon
{
  public abstract class LavaFX : MonoBehaviour
  {
    #region Inspector

    [Min(1)]
    [SerializeField]
    private float width = 5;

    #endregion


    #region Properties

    protected abstract float Ratio { get; }

    protected virtual bool UseRadius => false;

    #endregion


    #region MonoBehaviour

    private void OnValidate ()
    {
      ParticleSystem particles = GetComponent<ParticleSystem>();

      ParticleSystem.ShapeModule shape = particles.shape;

      if ( UseRadius )
      {
        shape.radius = width / 2;
      }
      else
      {
        Vector3 shapeScale = shape.scale;
        shapeScale.x = width;
        shape.scale = shapeScale;
      }

      ParticleSystem.EmissionModule emission = particles.emission;
      emission.rateOverTime = width * Ratio;

      ParticleSystem.MainModule main = particles.main;
      main.maxParticles =
        Mathf.CeilToInt(main.duration * emission.rateOverTime.constant);
    }

    #endregion
  }
}