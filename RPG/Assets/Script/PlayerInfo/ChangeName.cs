using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeName : MonoBehaviour
{
    public Text name;

    public void ChangeUsername(Text newUsername)
    {
        name.text = newUsername.text;
        UserInfos.userName = newUsername.text.ToString();
    }

    void Start()
    {
        name.text = UserInfos.userName;
    }
}
