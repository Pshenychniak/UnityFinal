using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    public int Value=0; 

   

    private void Update()
    {
        _scoreText.text = Value.ToString();
    }
}
