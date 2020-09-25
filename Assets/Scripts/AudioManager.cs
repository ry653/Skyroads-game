using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public GameManager gameManager;

    public AudioSource BGAS, EffectAS;
    public AudioClip CoinSnd;
    [SerializeField] private AudioMixer Mixer;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RefreshSoundState()
    {

        if (gameManager.isSound)
        {
            Mixer.SetFloat("MyExposedParam", 0);
        }
        else
        {
            Mixer.SetFloat("MyExposedParam", -80);
        }

    }


    public void PlayCoinEffect()
    {
        if (gameManager.isSound)
            EffectAS.PlayOneShot(CoinSnd);
    }
}