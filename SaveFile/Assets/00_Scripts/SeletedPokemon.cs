using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class SeletedPokemon : MonoBehaviour
{
    public InputField HP;
    public InputField Power;
    public Toggle PIKACHU;
    public Toggle RAICHU;
    public Toggle PICHU;
    public Toggle ALRORARAICHU;
    public Text BoardText;
    public Button StartButton;
    public Text HPText; 
    public Text PowerText;
    public GameObject anemy;
    public GameObject YouPokemon;
    public Button BlttleButton;
    public Text EnemyHPText;
    public Text YouHPText;
    public Slider EnemyHPSlider;
    public Slider YouHPSlider;
    public int enemyHP = 0;
    public int enemyPower = 0;
    private Random random = new Random();
    public Button AttButton;
    
    
    
    private void Start()
    {
        BoardText.fontSize = 40;
        BoardText.text = $"포켓몬을 선택하고 채력과 공격력을 입력하시오";
        
        BlttleButton.gameObject.SetActive(false);
        EnemyHPText.gameObject.SetActive(false);
        YouHPText.gameObject.SetActive(false);
        EnemyHPSlider.gameObject.SetActive(false);
        YouHPSlider.gameObject.SetActive(false);
        YouPokemon.gameObject.SetActive(false);
        
        
        
    }

    private void Update()
    {
        
        bool anyToggleSelected = PIKACHU.isOn || RAICHU.isOn || PICHU.isOn || ALRORARAICHU.isOn;

        if (anyToggleSelected == true)
        {
            StartButton.gameObject.SetActive(true);
        }
        else
        {
            StartButton.gameObject.SetActive(false);
        }

        
    }

    public void PlayButtonClickEnevt()
    {
        ConvertTextToInt();
        StartButton.gameObject.SetActive(false);
        HP.gameObject.SetActive(false);
        Power.gameObject.SetActive(false);
        PIKACHU.gameObject.SetActive(false);
        RAICHU.gameObject.SetActive(false);
        PICHU.gameObject.SetActive(false);
        ALRORARAICHU.gameObject.SetActive(false);
        BoardText.text = "시합 시작";
        
        
        anemy.gameObject.SetActive(true);
        EnemyHPText.gameObject.SetActive(true);
        YouHPText.gameObject.SetActive(true);
        EnemyHPSlider.gameObject.SetActive(true);
        YouHPSlider.gameObject.SetActive(true);
        YouPokemon.gameObject.SetActive(true);
        BlttleButton.gameObject.SetActive(true);
        
        
        
    }

    
    
    public void ConvertTextToInt()
    {
        string hpText = HPText.text;
        Debug.Log("94_hpText"+hpText);
        int HPValue;
        
        string powerputText = PowerText.text;
        Debug.Log("98_powerputText"+powerputText);
        int powerValue;
        if (int.TryParse(hpText, out HPValue))
        {
            
            Debug.Log("변환된 정수 값: " + HPValue);
        }
        else
        {
            
            Debug.LogError("유효한 정수로 변환할 수 없습니다.");
        }
        Debug.Log("110_HPValue"+HPValue);

        if (int.TryParse(powerputText, out powerValue))
        {
            Debug.Log("변환된 정수 값: " + powerValue);
        }
        else
        {
            Debug.LogError("유효한 정수로 변환할 수 없습니다.");
        }
        
        Debug.Log("121_powerValue"+powerValue);

        enemyHP = random.Next(1, HPValue - 1);
        int enemyHPbar = enemyHP;
        enemyPower = random.Next(1, powerValue - 1);
        int enemyPowerBar = enemyPower;
        Debug.Log("122_enemyHP"+enemyHPbar);
        Debug.Log("123_enemyPower"+enemyPowerBar);
        
    }

    public void Att()
    {
        EnemyHPSlider.value += 0.05f;
        if (EnemyHPSlider.value == 1)
        {
            BoardText.fontSize = 60;
            BoardText.text = "승리 하였습니다";
        }
        
    }

    
    
    
    
    
    
    
    
    
}
