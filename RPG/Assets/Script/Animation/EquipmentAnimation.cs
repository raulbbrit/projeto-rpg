using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentAnimation : MonoBehaviour
{
    [Header("Abrir o Painel")]
    public GameObject panel;

    [Space]
    [Header("Ativar e Desativar os Grupos")]
    public GameObject skillGroup;
    public GameObject statsGroup;
    public GameObject inventoryGroup;
    public GameObject equipmentGroup;

    [Space]
    [Header("Fechar Outros Paines")]
    public GameObject panelStatus;
    public GameObject panelInventory;
    public GameObject panelSkill;

    [Space]
    [Header("Animar a Posição das Caixas")]
    public GameObject downInventory;
    public GameObject downSkills;


    private void Start()
    {
        equipmentGroup.SetActive(false);
    }


    public void PanelOpen()
    {
        Animator animation = panel.GetComponent<Animator>();
        Animator animatorSelf = GetComponentInParent<Animator>();
        Animator animation1 = panelStatus.GetComponent<Animator>();
        Animator animation2 = panelInventory.GetComponent<Animator>();
        Animator animation3 = panelSkill.GetComponent<Animator>();
        Animator animation4 = downInventory.GetComponent<Animator>();
        Animator animation5 = downSkills.GetComponent<Animator>();
        


        bool isOpen = animation.GetBool("open");

        if (isOpen)
        {
            equipmentGroup.SetActive(false);
        }
        else
        {
            statsGroup.SetActive(false);
            inventoryGroup.SetActive(false);
            skillGroup.SetActive(false);
            equipmentGroup.SetActive(true); 
        }

        animation.SetBool("open", !isOpen);
        animatorSelf.SetBool("isSlided", false);
        animation1.SetBool("open", false);
        animation2.SetBool("open", false);
        animation3.SetBool("open", false);
        animation4.SetBool("isSlided", false);
        animation5.SetBool("isSlided", false);
    }
}
