using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private PlayerMovement playerMovement;
    public void Pause()
    {
        gameObject.SetActive(true);
        gameManager.canPlay = false;
        gameManager.StopAllCoroutines();
        playerMovement.Pause();
    }
    public void Resume()
    {
        gameObject.SetActive(false);
        gameManager.canPlay = true;
        gameManager.AllStartCoroutine();
        playerMovement.UnPause();
    }
    public void MenuBtn()
    {
        gameObject.SetActive(false);
        mainMenu.OpenMenu();
    }
}
