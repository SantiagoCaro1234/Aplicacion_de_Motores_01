using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer _playerSprite;

    private void Awake()
    {
        _playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Player.onPlayerDeath += DeathStateAnimation;
    }

    public void DeathStateAnimation()
    {
        _playerSprite.color = Color.red;
    }
}
