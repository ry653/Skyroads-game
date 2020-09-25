using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Sprite musicOn, musicOf;
    [SerializeField] private Image soundBtnImg;
    [SerializeField] private GameManager gameManager;

    public void PlayBtn()
    {
        gameObject.SetActive(false);
        gameManager.StartGame();

    }
    public void QuitBtn()
    {
        SaveManager.Instance.SaveGame();
        Application.Quit();
    }
    public void OpenMenu()
    {
         gameObject.SetActive(true);

    }
    public void SoundBtn()
    {
        gameManager.isSound = !gameManager.isSound;
        soundBtnImg.sprite = gameManager.isSound ? musicOn : musicOf;
        AudioManager.Instance.RefreshSoundState();
    }
    private void Awake()
    {
        AudioManager.Instance.RefreshSoundState();
    }
    private void Start()
    {
        SaveManager.Instance.LoadGame();
        soundBtnImg.sprite = gameManager.isSound ? musicOn : musicOf;
        
    }
}
