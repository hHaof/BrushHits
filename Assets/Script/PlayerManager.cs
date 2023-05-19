using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Scripts
    PlayerMovement playerMovement;

    AudioController audioController;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        audioController = GameObject.Find("AudioSource").GetComponent<AudioController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            
            GameManager.Instance.ShowWinPanel();
            audioController.PlayCongratesSound();
        }
    }

}