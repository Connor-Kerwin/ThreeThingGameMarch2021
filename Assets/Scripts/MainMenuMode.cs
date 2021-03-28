using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum MainMenuState
{
    Menu,
    Highscore,
    Credits
}

public class MainMenuMode : MonoBehaviour
{
    public MainMenuState State;

    public GameObject HighscoreContent;
    public GameObject MenuContent;
    public GameObject CreditsContent;

    private void Start()
    {
        GoMenu();
    }

    public void GoHighscore()
    {
        State = MainMenuState.Highscore;
        HighscoreContent.SetActive(true);
        MenuContent.SetActive(false);
        CreditsContent.SetActive(false);

        HighscoreSystem.Instance.RefreshScores();
    }

    public void GoMenu()
    {
        State = MainMenuState.Menu;
        HighscoreContent.SetActive(false);
        MenuContent.SetActive(true);
        CreditsContent.SetActive(false);
    }

    public void GoCredits()
    {
        State = MainMenuState.Credits;
        HighscoreContent.SetActive(false);
        MenuContent.SetActive(false);
        CreditsContent.SetActive(true);
    }
}
