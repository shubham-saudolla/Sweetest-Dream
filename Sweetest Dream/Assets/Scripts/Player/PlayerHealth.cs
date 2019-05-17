using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public float restartDelay = 5f;

    private Animator _anim;
    private AudioSource _playerAudio;
    private PlayerMovement _playerMovement;
    private PlayerShooting _playerShooting;
    private bool _isDead;
    private bool _damaged;
    private float _restartTimer;

    public GameOverManager _gameOverManager;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerShooting = GetComponentInChildren<PlayerShooting>();
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (_damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        _damaged = false;
    }

    public void TakeDamage(int amount)
    {
        _damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        _playerAudio.Play();

        if (currentHealth <= 0 && !_isDead)
        {
            Death();
        }
    }

    private void Death()
    {
        _isDead = true;
        _playerShooting.DisableEffects();

        _anim.SetTrigger("Die");

        _playerAudio.clip = deathClip;
        _playerAudio.Play();

        _playerMovement.enabled = false;
        _playerShooting.enabled = false;
    }

    public void RestartLevel()
    {
        if (currentHealth <= 0)
        {
            _gameOverManager.GetComponent<Animator>().SetTrigger("GameOver");

            _restartTimer += Time.deltaTime;

            if (_restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
