using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    [SerializeField] private GameObject _playerGObj;
    [SerializeField] private Material _materialShield;
    [SerializeField] private Material _materialPlayer;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = _playerGObj.GetComponent<Player>();
    }

    public void DownUseShield()
    {
        _playerGObj.GetComponent<MeshRenderer>().material = _materialShield;
        _player.Shield = true;
        StartCoroutine(StopUseShield());
    }
    public void UpUseShield()
    {
        _playerGObj.GetComponent<MeshRenderer>().material = _materialPlayer;
        _player.Shield = false;
    }
    public void Continue()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    IEnumerator StopUseShield()
    {
        yield return new WaitForSeconds(2f);
        UpUseShield();
    }
}
