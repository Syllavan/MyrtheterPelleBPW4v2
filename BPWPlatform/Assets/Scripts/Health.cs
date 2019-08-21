using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;



    /* private void Start()
     {
         //int health = gameObject.GetComponent<PlayerPlatformerController>().health;

     }*/

    private void Update()
    {
        PlayerPlatformerController playerPlatformerController = gameObject.GetComponent<PlayerPlatformerController>();
        if (playerPlatformerController != null)
        {
            if (PlayerPlatformerController.health > numberOfHearts)
            {
                PlayerPlatformerController.health = numberOfHearts;
            }

            for (int i = 0; i < hearts.Length; i++)
            {

                if (i < PlayerPlatformerController.health)
                {
                    hearts[i].sprite = fullHearts;
                }
                else
                {
                    hearts[i].sprite = emptyHearts;
                }

                if (i < numberOfHearts)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
        }
    }
}


   





