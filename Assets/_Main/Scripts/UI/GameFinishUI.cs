using _Main.Scripts.SRGameSettings;
using _Main.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishUI : MonoBehaviour
{
    [SerializeField] private List<SelectCarModel> carsList;
    [SerializeField] private List<TextMeshProUGUI> leaderboardTexts;

    private void Start()
    {
        UpdateLeaderboard();
    }
    void UpdateLeaderboard()
    {
        var sortedCars = carsList.OrderByDescending(car => car.CarProps.MotorPower).ToList();

        for (int i = 0; i < leaderboardTexts.Count; i++)
        {
            if (i < sortedCars.Count)
            {
                leaderboardTexts[i].text = $"{i + 1}. {sortedCars[i].CarProps.CarName}";
            }
            else
            {
                leaderboardTexts[i].text = "";
            }
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game...");
        Application.Quit();
    }
}
