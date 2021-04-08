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

        switch (diceValue)
        {
            case 1 :result = Random.Range(1, 5); break;
            case 2 : result = Random.Range(1, 7); break;
            case 3 : result = Random.Range(1, 11); break;
            case 4 : result = Random.Range(1, 21); break;
            case 5 : result = Random.Range(1, 101); break;
            default : result = 0;  break;
        }

        textMessage += result + "\n";
        text.text = textMessage;

    }
}
