using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event System.Action OnPlayerDeath;
    public static event System.Action OnPlayerVictory;

    public static void TriggerDeath() => OnPlayerDeath?.Invoke();
    public static void TriggerVictory() => OnPlayerVictory?.Invoke();
}
