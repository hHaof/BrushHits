using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public GameObject menuPanel;
    public GameObject inGamePanel;
    public GameObject failPanel;
    public GameObject winPanel;
    [SerializeField] private GameObject audioController;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [SerializeField] private GameObject confetti;
    PlayerMovement playerMovement;
    public Animation playerAnimation;

    bool PlayOnce = false;
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        // If the instance is already set and it's not this instance, destroy this duplicate instance
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Set the instance to this instance
        instance = this;
    }

    void Start()
    {
        playerAnimation = GetComponent<Animation>();

    }

    void Update()
    {
        if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            if (player1.GetComponent<PlayerMovement>().enabled && !player2.GetComponent<PlayerMovement>().enabled)
            {
                player1.GetComponent<PlayerMovement>().enabled = false;
                player2.GetComponent<PlayerMovement>().enabled = true;
            }
            else if (!player1.GetComponent<PlayerMovement>().enabled && player2.GetComponent<PlayerMovement>().enabled)
            {
                player2.GetComponent<PlayerMovement>().enabled = false;
                player1.GetComponent<PlayerMovement>().enabled = true;
            }
        }

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {

            if (player1.GetComponent<PlayerMovement>().enabled && !player2.GetComponent<PlayerMovement>().enabled)
            {
                player1.GetComponent<PlayerMovement>().enabled = false;
                player2.GetComponent<PlayerMovement>().enabled = true;
            }
            else if (!player1.GetComponent<PlayerMovement>().enabled && player2.GetComponent<PlayerMovement>().enabled)
            {
                player2.GetComponent<PlayerMovement>().enabled = false;
                player1.GetComponent<PlayerMovement>().enabled = true;
            }

        }

        GameOver();

    }

    void GameOver()
    {
        if (!player1.GetComponent<PlayerMovement>().enabled)
        {
            if (!player1.GetComponent<GroundCheck1>().IsPlayerOnGround())
            {
                StartCoroutine(ShowFailPanel());
            }
        }
        else if (!player2.GetComponent<PlayerMovement>().enabled)
        {
            if (!player2.GetComponent<GroundCheck2>().IsPlayerOnGround())
            {
                StartCoroutine(ShowFailPanel());
            }
        }
    }

    public void StartGame()
    {
        menuPanel.SetActive(false);
        inGamePanel.SetActive(true);
        player1.GetComponent<PlayerMovement>().enabled = true;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel(){
        if(SceneManager.GetActiveScene().buildIndex < 2){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else{
            SceneManager.LoadScene("Level 1");
        }
        
    }

    public IEnumerator ShowFailPanel()
    {
        StopPlayer();
        if (!PlayOnce)
        {
            audioController.GetComponent<AudioController>().PlayFailSound();
            PlayOnce = true;
        }

        playerAnimation.Play("fallDown");
        yield return new WaitForSeconds(.9999999f);
        inGamePanel.SetActive(false);
        failPanel.SetActive(true);

    }


    public void wrapWinPanel()
    {
        StartCoroutine(ShowWinPanel());
    }
    public IEnumerator ShowWinPanel()
    {
        StopPlayer();
        if (!PlayOnce)
        {
            audioController.GetComponent<AudioController>().PlayCongratesSound();
            PlayOnce = true;
        }

        confetti.SetActive(true);
        yield return new WaitForSeconds(1f);
        inGamePanel.SetActive(false);
        failPanel.SetActive(false);
        winPanel.SetActive(true);
    }

    public void StopPlayer()
    {
        player1.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerMovement>().enabled = false;
    }

}
