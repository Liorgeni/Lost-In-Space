using UnityEngine;

public class SoundManager : MonoBehaviour
{

    static public SoundManager instance;

    public AudioClip playerShotSound;
    public AudioClip playerExplodeSound;
    private AudioSource audioSource;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayerShotSound()
    {
        audioSource.PlayOneShot(playerShotSound);
    }

    public void playExplodeSound()
    {
        audioSource.PlayOneShot(playerExplodeSound);
    }


}
