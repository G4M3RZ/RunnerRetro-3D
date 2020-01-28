using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteractivoInGame : MonoBehaviour {

    public DeadCondition _dead;
    public GameObject _switcher;
    public GameObject PauseMenuUI;
    public GameObject DeadMenuUI;

    public AudioSource _sound;

    public bool IsPause = false;

    public GameObject fadeInicial;
    public GameObject fadeFinal;

    private bool _restart, _goToMenu;

    private bool _instantFade;
    private float timeToSetScene = 1.5f;

    private bool _look = false;

    void Start()
    {
        Instantiate(fadeInicial, transform.position, transform.rotation);
        _look = _instantFade = true;
        _restart = _goToMenu = false;
        _sound.volume = 0;
    }

    void Update()
    {
        PauseController();
        AudioManager();
        Restart();
        Dead();
        Menu();
    }

    #region Buttons
    public void PauseButton()
    {
        IsPause = !IsPause;
        _look = false;
    }
    public void RestartButton()
    {
        if(!_goToMenu)
            _restart = true;
    }
    public void MenuButton()
    {
        if(!_restart)
            _goToMenu = true;
    }
    #endregion

    void PauseController()
    {
        if (!_look && !_dead._dead)
        {
            if (IsPause)
            {
                Time.timeScale = 0f;
                PauseMenuUI.SetActive(true);
                _switcher.SetActive(false);
                _sound.Pause();
                _look = true;
            }
            else 
            {
                Time.timeScale = 1f;
                PauseMenuUI.SetActive(false);
                _switcher.SetActive(true);
                _sound.Play();
                _look = true;
            }
        }
    }

    void Restart()
    {
        if (_restart)
        {
            if (_instantFade)
            {
                Instantiate(fadeFinal, transform.position, transform.rotation);
                Time.timeScale = 1f;
                _instantFade = false;
            }
            if (timeToSetScene <= 0)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            else
            {
                timeToSetScene -= Time.deltaTime;
                _sound.volume -= Time.deltaTime;
            }
        }
    }

    void Dead()
    {
        if (_dead._dead)
        {
            DeadMenuUI.SetActive(true);
            _switcher.SetActive(false);
        }
    }

    void Menu()
    {

    }

    #region Auduio Manager
    void AudioManager()
    {
        if (!_dead._dead)
        {
            if (_sound.volume < 1 && !IsPause)
            {
                _sound.volume += Time.deltaTime * 10;
            }
            else if (_sound.volume > 0 && IsPause)
            {
                _sound.volume = 0;
            }
        }
    }
    #endregion
}
