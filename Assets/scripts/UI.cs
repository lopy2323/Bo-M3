using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    bool buildmenuopen = false;
    public static int life = 3;
    private bool lifechecked = true;
    public static UI instance;
    private int manaamount = 400;
    [SerializeField] private GameObject life3;
    [SerializeField] private GameObject life2;

    [SerializeField] Button buildbutton;
    [SerializeField] TMPro.TextMeshProUGUI mana;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        mana.text = manaamount.ToString();
        life = 3;
        enemy.loselife += _life;
    }

    private void _life()
    {
        life--;
        lifechecked = false;
        if (life == 2 && lifechecked == false)
        {
            life3.SetActive(false);
            lifechecked = true;
        }
        if (life == 1 && lifechecked == false)
        {
            life2.SetActive(false);
            lifechecked = true;
        }
        if (life <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("Main");
            // Implement game over logic here
        }
    }
    public void Buildbutton()
    {
        RectTransform rectTransform = buildbutton.GetComponent<RectTransform>();

        if (buildmenuopen == true)
        {
            rectTransform.anchoredPosition = new Vector3(-35, -35, 0);
            buildmenuopen = false;
        }
        else if (buildmenuopen == false)
        {
            rectTransform.anchoredPosition = new Vector3(-105, -35, 0);
            buildmenuopen = true;
        }
    }
    public void arrowtower()
    {
        if (buildman._instance.towernum != 1 && manaamount >= 100)
        {
            buildman._instance.towernum = 1;
            manaamount -= 100;
            mana.text = manaamount.ToString();
            buildman._instance.checkednum = false;
        }
    }
    public void litning()
    {
        if (buildman._instance.towernum != 2)
        {
            buildman._instance.towernum = 2;
            buildman._instance.checkednum = false;
        }
    }
    public void Fireball()
    {
        if (buildman._instance.towernum != 3)
        {
            buildman._instance.towernum = 3;
            buildman._instance.checkednum = false;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void UIStart()
    {
        SceneManager.LoadScene("Game");

    }
    public void addmana(int ma)
    {
        manaamount += ma;
        mana.text = manaamount.ToString();
    }
}

