using UnityEngine;

public class EffectsManager : MonoBehaviour
{

    public static EffectsManager instance;

    public ParticleSystem playerExplosion;
    public ParticleSystem enemyExplosion;


    private void Awake()
    {
        instance = this;
    }


    public void ActivatePlayerExplosion(Vector3 position)
    {
        ParticleSystem ps = Instantiate(playerExplosion, position, Quaternion.identity);
        ps.Play();
        Destroy(ps.gameObject, 2);
    }

    public void ActivateEnemyExplosion(Vector3 position)
    {
        ParticleSystem ps = Instantiate(enemyExplosion, position, Quaternion.identity);
        ps.Play();
        Destroy(ps.gameObject, 2);
    }

}
