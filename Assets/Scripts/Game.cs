using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Random = System.Random;

public class Game : MonoBehaviour
{
    public Text hintText;
    public Text oppinionText;
    public Text moneyText;
    public Text addIndificator;
    public Transform canvas;
    
    private int playerOppinion = 0;
    private int playerMoney = 0;
    private int currentLevel = 1;
    
    private Collider2D collider;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        oppinionText.text = $"Oppinion: {playerOppinion}/{currentLevel*100}";
        moneyText.text = $"Money: {playerMoney}";
    }

    private void Update()
    {
        ReiseLevel();
        OnTriggerStay2D(collider);
    }

    private void ReiseLevel()
    {
        if (playerOppinion == currentLevel * 100)
        {
            currentLevel++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        hintText.text = "";
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Random random = new Random();
            addIndificator.text = $"+10 oppinion; +{currentLevel * 10} money";
            Instantiate(addIndificator, canvas);
            //destroy doesn`t work and I don`t know why((((
            Destroy(addIndificator, 0.000001f);
            addIndificator.transform.position =
                new Vector3((float) random.Next(200, 400), (float) random.Next(200, 400), 0f);
            playerOppinion += 10;
            oppinionText.text = $"Oppinion: {playerOppinion}/{currentLevel * 100}";
            playerMoney += currentLevel * 10;
            moneyText.text = $"Money: {playerMoney}";
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        hintText.text = "Press SPACE to work";
    }
}
