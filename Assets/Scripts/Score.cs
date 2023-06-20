using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    public int Value;

    private void Start()
    {
        Value = 0;
        _scoreText.text = Value.ToString();
    }

    private void Update()
    {
        _scoreText.text = Value.ToString();
    }

    public void AddScore(int value)
    {
        Value += value;
    }
}
