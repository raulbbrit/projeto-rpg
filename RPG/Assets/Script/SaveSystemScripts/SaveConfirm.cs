using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveConfirm : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(wait());
    }
    
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);

        gameObject.SetActive(false);
    }
}
