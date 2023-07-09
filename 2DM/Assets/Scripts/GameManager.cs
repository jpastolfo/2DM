using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject cardsUI;
    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject hero;
    [SerializeField] GameObject winUI;
    bool changeCam;
    public int cardsOnRooms;
    [SerializeField] DropZone handScript;
    public bool isPlaying;
    public bool isOnMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cardsOnRooms = handScript.GetMaxCards() - handScript.currentCards; 
        if(cardsOnRooms == 3 && !playButton.activeSelf && !isPlaying && !isOnMenu)
        {
            Debug.Log("Show Play");
            playButton.SetActive(true);
        }
        if(cardsOnRooms < 3 && playButton.activeSelf)
        {
            playButton.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangePerspective();
        }
    }

    public void ChangePerspective()
    {
        // Oh no! Seems like you're actually the Player
        isPlaying = !changeCam;
        cardsUI.SetActive(changeCam);
        playButton.SetActive(changeCam);
        cam1.SetActive(changeCam);
        cam2.SetActive(!changeCam);
        hero.SetActive(!changeCam);
        changeCam = !changeCam;
    }

    public void PlayGame()
    {
        ChangePerspective();
        isOnMenu = false;
    }

    public void WinGame()
    {
        isPlaying = false;
        isOnMenu = true;
        winUI.SetActive(true);
    }
}
