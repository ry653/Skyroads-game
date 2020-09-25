using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject resultObj;
    public GameObject congratulations;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private RoadSpawner roadSpawner;
    [SerializeField] public float moveSpead;
    [SerializeField] private Text pointText;
    [SerializeField] private Text countCometText;
    [SerializeField] private Text bestPointText;
    [SerializeField] private Text coinsText;  
    [SerializeField] private Text timeText;
    [SerializeField] private CountComet countComet;
    [SerializeField] private SmoothFollow camera;
    [SerializeField] private PauseController pauseController;
    [SerializeField] private MainMenu mainMenu;

    public int point;
    public int bestPoint;
    public int coins;
    private bool boostEnable;
    public bool isSound ;
    public float timeInPlay;

    public bool canPlay;
    public void ShowResult()
    {
        if (bestPoint < point)
        {
            bestPoint = point;
            bestPointText.text = ("Best score:" + bestPoint.ToString());
            congratulations.SetActive(true);
        }
        resultObj.SetActive(true);
        moveSpead = 14;
        StopAllCoroutines();
        timeText.text = ("Time in Play: " + TimeFormat.Format(timeInPlay));
        SaveManager.Instance.SaveGame();
    }
    public void MainBtn()
    {
        mainMenu.OpenMenu();
    }
    private void Start()
    {
        AllStartCoroutine();
        StartCoroutine(TimePlay());
    }
    public void StartGame()
    {
        Debug.Log("clik");
        congratulations.SetActive(false);
        resultObj.SetActive(false);
        roadSpawner.StartGame();
        canPlay = true;
        StartCoroutine(TimePlay());
        AllStartCoroutine();
        point = 0;
    }
    public void AdCoins(int c)
    {
        coins += c;
        coinsText.text = ("Coins:" + coins.ToString());
    }
    IEnumerator Point()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (boostEnable)
            {
                point += 2;

            }
            else
            {
                point++;
            }
            
            pointText.text = ("Score:" + point.ToString());
        }
    } 
    public string AddPointToComet(int point)
    {
        this.point += point;
        return "Score:" + point.ToString();
    } 
    IEnumerator TimePlay()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeInPlay++;
        }
    }
    IEnumerator Spead()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            moveSpead += 0.1f + Time.deltaTime;
            moveSpead = Mathf.Clamp(moveSpead, 14, 140);
        }
    }

    internal void RefreshText()
    {
        coinsText.text = ("Score: " + coins.ToString());
        bestPointText.text = ("Best score: " + bestPoint.ToString());
        countCometText.text = ("Count Comet: " + countComet.countComet.ToString());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            {
                pauseController.Pause();
            }
        if (canPlay)
        {
            CheckInput();
            
        }
    }
    public void AllStartCoroutine()
    {
        StartCoroutine(Point());
        StartCoroutine(Spead());
        camera.height = 5f;
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!boostEnable)
            {
                moveSpead *= 2;
            }

            boostEnable = true;
            camera.height = 2f;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            boostEnable = false;
            moveSpead /= 2;
            camera.height = 5f;
        }
    }
}
