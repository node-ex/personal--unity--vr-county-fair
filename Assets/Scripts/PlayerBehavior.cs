using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Climbing;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlayerBehavior : MonoBehaviour
{
    private ControllerInputActionManager[] _controllerInputActionManagers;

    // [SerializeField] private TeleportationProvider _teleportationProvider;
    [SerializeField] private XRRayInteractor[] _TeleportationInteractors;
    [SerializeField] private DynamicMoveProvider _dynamicMoveProvider;
    [SerializeField] private ClimbProvider _climbProvider;

    public bool ToggleSnapTurn()
    {
        foreach (var controllerInputActionManager in _controllerInputActionManagers)
        {
            controllerInputActionManager.smoothTurnEnabled = !controllerInputActionManager.smoothTurnEnabled;
        }

        return !_controllerInputActionManagers[0].smoothTurnEnabled;
    }

    private void Awake()
    {
        _controllerInputActionManagers = GetComponentsInChildren<ControllerInputActionManager>();
    }

    private void Start()
    {
        GameManager.GameStateChanged += OnGameStateChange;
        OnGameStateChange(GameManager.Instance.GameState);
    }

    private void OnDestroy()
    {
        GameManager.GameStateChanged -= OnGameStateChange;
    }

    private void OnGameStateChange(GameStateEnum gameState)
    {
        switch (gameState)
        {
            case GameStateEnum.Started:
                AllowPlayerMovement(false);
                break;
            case GameStateEnum.Playing:
                AllowPlayerMovement(true);
                break;
            case GameStateEnum.Paused:
                AllowPlayerMovement(false);
                break;
            default:
                break;
        }
    }

    private void AllowPlayerMovement(bool allowMovement)
    {
        // _teleportationProvider.enabled = allowMovement;
        foreach (var interactor in _TeleportationInteractors)
        {
            interactor.enabled = allowMovement;
        }
        _dynamicMoveProvider.enabled = allowMovement;
        _climbProvider.enabled = allowMovement;
    }
}
