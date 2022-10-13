using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSettings : MonoBehaviour
{

    [Header("StartMenu")]
    [SerializeField] private TMP_InputField _numberOfObjectsTextBox;
    [SerializeField] private TMP_InputField _speedOfAnObjectTextBox;
    [SerializeField] private TMP_InputField _distanceFromStartTextBox;
    [SerializeField] private TMP_InputField _spawnDelayTextBox;

    [Header("Reset")]
    [SerializeField] private GameObject _resetButton;

    public static long NumberObjects;
    public static long SpeedObject;
    public static long Distance;
    public static long SpawnDelay;

    private Animator _animator;

    public static Action StartAndStopSimulete;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnEndEdit()
    {
        if (_speedOfAnObjectTextBox.text != "") SpeedObject = Math.Abs(Convert.ToInt64(_speedOfAnObjectTextBox.text)) / 100;
        if (_distanceFromStartTextBox.text != "") Distance = Math.Abs(Convert.ToInt64(_distanceFromStartTextBox.text));
        if (_spawnDelayTextBox.text != "") SpawnDelay = Math.Abs(Convert.ToInt64(_spawnDelayTextBox.text)) / 1000;
    }

    public void OnClickStartButton()
    {
        if (_numberOfObjectsTextBox.text != "" && _speedOfAnObjectTextBox.text != ""
            && _distanceFromStartTextBox.text != "" && _spawnDelayTextBox.text != "")
        {
            NumberObjects = Math.Abs(Convert.ToInt64(_numberOfObjectsTextBox.text));
            StartAndStopSimulete.Invoke();
            _animator.SetTrigger("Start");
            _resetButton.SetActive(true);
        }
    }

    public void ResetGame()
    {
        _resetButton.SetActive(false);
        StartAndStopSimulete.Invoke();
        _animator.SetTrigger("Reset");
    }
}
