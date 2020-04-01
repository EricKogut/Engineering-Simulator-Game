using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ExperienceTrack : MonoBehaviour
{

    public GameObject player;
    public Slider mySlider;
    public Text year;
    private int _currentXP;
    private int _currentLevel;
    private int _levelMin;
    private int _levelMax;

    // Update is called once per frame
    void Update()
    {
        _currentXP = player.GetComponent<PlayerMovement>().Experience;
        _currentLevel = player.GetComponent<PlayerMovement>().Level;
        if (_currentLevel != 5)
        {
            _levelMax = player.GetComponent<PlayerMovement>().dictionary[_currentLevel].exp;
            _levelMin = (_currentLevel != 0) ? player.GetComponent<PlayerMovement>().dictionary[_currentLevel - 1].exp : 0;
            //Debug.Log(_currentLevel);

            mySlider.maxValue = _levelMax;
            mySlider.minValue = _levelMin;
            mySlider.value = _currentXP;
        }
        else
        {
            mySlider.value = 2;
            mySlider.minValue = 0;
            mySlider.maxValue = 1;
        }
        if (_currentLevel < 5)
        {
            year.text = "Year: " + _currentLevel.ToString();
        }
        else
        {
            year.text = "Grad";
        }
    }
}
