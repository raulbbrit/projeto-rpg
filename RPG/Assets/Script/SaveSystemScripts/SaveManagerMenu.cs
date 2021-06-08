using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManagerMenu : MonoBehaviour
{
    [SerializeField] GameObject text;
    public void DeleteCharMenu()
    {
        text.SetActive(false);
        SaveSystem.DeleteCharacter();
        SerializationManager.DeleteOldSave(1);
        StartCoroutine(DeletedTextAppear());
    }

    public void DeleteMasterMenu()
    {
        text.SetActive(false);
        SerializationManager.DeleteOldSave(2);
        StartCoroutine(DeletedTextAppear());
    }

    IEnumerator DeletedTextAppear()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(5);
        text.SetActive(false);
    }
}
