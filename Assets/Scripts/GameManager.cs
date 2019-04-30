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
        StartMainMenu();
    }

    public void StartMainMenu()
    {
        menuOverlay.gameObject.SetActive(true);
        menuCamera.enabled = true;
        playerCamera.enabled = false;
    }

    public void StartGame()
    {
        menuOverlay.gameObject.SetActive(false);
        ClearArena();
        Instantiate(playerPrefab);
        menuCamera.enabled = false;
        playerCamera.enabled = true;
    }

    public void RestartGame()
    {
        gameOverOverlay.gameObject.SetActive(false);
        ClearArena();
        Instantiate(playerPrefab);
    }

    public void LoseGame(float value)
    {
        gameOverOverlay.gameObject.SetActive(true);
    }

    public void ClearArena()
    {
        PigSpawner.activePigs.ForEach(p => Destroy(p.gameObject));
        HammerSpawner.activeHammers.ForEach(h => Destroy(h.gameObject));
        CurrencySpawner.activeCurrency.ForEach(c => Destroy(c.gameObject));
        PigSpawner.activePigs.Clear();
        HammerSpawner.activeHammers.Clear();
        CurrencySpawner.activeCurrency.Clear();
    }

}
