using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Text hpText;
    public Text hungerText;
    public Text aliveText;
    public Text atkText;
    public Text speedText;

    public float maxHp = 100f;
    public float hp = 100f;
    public float maxHunger = 100f;
    public float hunger = 100f;
    public float atk = 5f;
    public float speed = 10f;

    //每秒饥饿值减少
    public float vHunger = 1f;
    //挨饿时每秒生命值减少
    public float vHpWhenHungry = 1f;

    public bool isSelected = true;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        hunger = maxHunger;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            return;
        }

        if (hp <= 0f)
        {
            Die();
            return;
        }

        if (hunger > 0f)
        {
            hunger -= Time.deltaTime * vHunger;
            SetHungerText();
        }
        else
        {
            hunger = 0f;
            SetHungerText();
            BeHungry();
        }
        if (hunger > maxHunger)
        {
            hunger = maxHunger;
            SetHungerText();
        }

    }

    private void Die()
    {
        isAlive = false;
        hpText.gameObject.SetActive(false);
        hungerText.gameObject.SetActive(false);
        aliveText.gameObject.SetActive(true);
    }

    //饥饿惩罚
    private void BeHungry()
    {
        if (!isAlive)
        {
            return;
        }
        hp -= Time.deltaTime * vHpWhenHungry;
        SetHpText();
    }

    //鼠标与人物的交互
    public void OnMouseOver()
    {
        //左键
        if (Input.GetMouseButtonDown(0))
        {
            SwitchSelected();
        }
    }


    //UI显示
    public void SetHpText()
    {
        hpText.text = "Hp:" + (int)hp + "/" + (int)maxHp;
    }

    public void SetHungerText()
    {
        hungerText.text = "Hunger:" + (int)hunger + "/" + (int)maxHunger;
    }

    public void SwitchSelected()
    {
        isSelected = !isSelected;


    }

}
