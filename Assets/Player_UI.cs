using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_UI : MonoBehaviour
{
    [SerializeField] private Player _playerscr;
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private GameObject _gameOverPanel;
    

    private void Awake()
    {
        _hpText = GetComponentInChildren<TextMeshProUGUI>();
        _playerscr = GetComponentInParent<Player>();
    }

    private void Start()
    {
        Player.onPlayerDeath += ShowGameOverPanel;
    }

    private void OnEnable()
    {
        Player.onPlayerDeath += ShowGameOverPanel;
    }

    private void OnDisable()
    {
        Player.onPlayerDeath -= ShowGameOverPanel;
    }

    private void Update()
    {
        _hpText.text = $"Player HP: {_playerscr._currentHealth}";

        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowGameOverPanel();
        }
    }

    public void ShowGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    public void RestartActualScene()
    {
        // Obtains active scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Resets to active scene
        SceneManager.LoadScene(currentSceneIndex);

        
    }
}
