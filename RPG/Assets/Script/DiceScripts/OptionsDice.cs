using UnityEngine;

public class OptionDice : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    
    public void ActiveDice()
    {
        gameObject.SetActive(true);
    }

    public void DesactiveDice()
    {
        gameObject.SetActive(false);
    }
}
