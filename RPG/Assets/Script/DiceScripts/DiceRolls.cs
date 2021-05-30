using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRolls : MonoBehaviour
{
    [SerializeField] protected Text text;
    private string textMessage;
   

    public void TryDice(int diceValue)
    {
        int result = 0;
        string nomeDado = null;

        switch (diceValue)
        {
            case 1 :result = Random.Range(1, 5); nomeDado = "D4"; break;
            case 2 : result = Random.Range(1, 7); nomeDado = "D6"; break;
            case 3 : result = Random.Range(1, 11); nomeDado = "D10"; break;
            case 4 : result = Random.Range(1, 21); nomeDado = "D20"; break;
            case 5 : result = Random.Range(1, 101); nomeDado = "D100"; break;
            default : result = 0;  break;
        }

        textMessage += $"{PlayerPrefs.GetString("userName")} rolou o dado {nomeDado} e obteve {result}\n\n";
        
        text.text = textMessage;

    }
}
