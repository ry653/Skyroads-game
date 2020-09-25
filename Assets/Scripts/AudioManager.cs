using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public GameManager gameManager;

    public AudioSource BGAS, EffectAS;
    public AudioClip CoinSnd;

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
            BGAS.UnPause();
            Debug.Log("on");
        }

        else
            BGAS.Pause();

    }

    public void PlayCoinEffect()
    {
        if (gameManager.isSound)
            EffectAS.PlayOneShot(CoinSnd);
    }
}