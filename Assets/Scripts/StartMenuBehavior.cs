using TMPro;
using UnityEngine;

public class StartMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _homeScreen;
    [SerializeField] private GameObject _settingsScreen;
    [SerializeField] private TMP_Text _toggleSnapTurnButtonText;

    private PlayerBehavior _playerBehavior;

    public void OnStartClick()
    {
        GameManager.Instance.UpdateGameState(GameStateEnum.Playing);
        _homeScreen.SetActive(false);
        _settingsScreen.SetActive(false);
    }

    public void OnSettingsClick()
    {
        _homeScreen.SetActive(false);
        _settingsScreen.SetActive(true);
    }

    public void OnQuitClick()
    {
        GameManager.Instance.UpdateGameState(GameStateEnum.Quit);
    }

    public void OnToggleSnapTurnClick()
    {
        var isSnapTurnOn = _playerBehavior.ToggleSnapTurn();
        _toggleSnapTurnButtonText.text = $"Snap Turn: {(isSnapTurnOn ? "On" : "Off")}";
    }

    public void OnSettingsBackClick()
    {
        _settingsScreen.SetActive(false);
        _homeScreen.SetActive(true);
    }

    private void Awake()
    {
        _playerBehavior = FindFirstObjectByType<PlayerBehavior>();
    }
}
