using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform playerPrefab;

    public Camera playerCamera;
    public Camera menuCamera;

    public Transform gameOverOverlay;
    public Transform menuOverlay;

    private void Start()
    {
        Instance = this;
        gameOverOverlay.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
        gameOverOverlay.gameObject.SetActive(false);
        PigSpawner.activePigs.ForEach(p => Destroy(p.gameObject));
        HammerSpawner.activeHammers.ForEach(h => Destroy(h.gameObject));
        CurrencySpawner.activeCurrency.ForEach(c => Destroy(c.gameObject));
        PigSpawner.activePigs.Clear();
        HammerSpawner.activeHammers.Clear();
        CurrencySpawner.activeCurrency.Clear();
        Instantiate(playerPrefab);
    }

    public void LoseGame(float value)
    {
        Debug.Log("Lose Game");
        gameOverOverlay.gameObject.SetActive(true);
    }
}
