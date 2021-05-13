using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusAnimator : MonoBehaviour
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
    [Header("Fechar os Outros Paineis")]
    public GameObject panelInventory;
    public GameObject panelEquipment;
    public GameObject panelSkills;

    [Space]
    [Header("Animar a Posição das Caixas")]
    public GameObject downPanel1;
    public GameObject downPanel2;
    public GameObject downPanel3;

    private void Start()
    {
        statsGroup.SetActive(false);
    }

    public void PanelOpen()
    {
        
        Animator animator = panel.GetComponent<Animator>();
        Animator animatorInventory = panelInventory.GetComponent<Animator>();
        Animator animatorEquipment = panelEquipment.GetComponent<Animator>();
        Animator animatorSkills = panelSkills.GetComponent<Animator>();
        Animator animator1 = downPanel1.GetComponent<Animator>();
        Animator animator2 = downPanel2.GetComponent<Animator>();
        Animator animator3 = downPanel3.GetComponent<Animator>();
        //Animator aux = panel.GetComponent<Animator>();

        bool isOpen = animator.GetBool("open");

        if (!animator1.GetBool("isSlided") || !animator2.GetBool("isSlided")) {
            
            bool isDown1 = animator1.GetBool("isSlided");
            bool isDown2 = animator2.GetBool("isSlided");
            bool isDown3 = animator3.GetBool("isSlided");

            if (!isOpen)
            {
                statsGroup.SetActive(true);
                skillGroup.SetActive(false);
                inventoryGroup.SetActive(false);
                equipmentGroup.SetActive(false);
            }

            animator.SetBool("open", !isOpen);
            
            animatorInventory.SetBool("open", false);
            animatorEquipment.SetBool("open", false);
            animatorSkills.SetBool("open", false);

            animator1.SetBool("isSlided", true);
            animator2.SetBool("isSlided", true);
            animator3.SetBool("isSlided", true);
            
            //aux.SetBool("isSlided", !auxBool);
        }
        else
        { 
            animator.SetBool("open", !isOpen);
            statsGroup.SetActive(false);
            animator1.SetBool("isSlided", false);
            animator2.SetBool("isSlided", false);
            animator3.SetBool("isSlided", false);
        }
        
        /*if (i == 2)
        {
            if (panel != null)
            {
                Animator animator = panel.GetComponent<Animator>();
                Animator aux = GetComponentInParent<Animator>();
                Animator animator1 = downPanel1.GetComponent<Animator>();
                Animator animator2 = downPanel2.GetComponent<Animator>();
                if (!animator2.GetBool("statusPanelOpen")) {
                    bool isOpen = animator.GetBool("open");
                    bool isDown = animator1.GetBool("downEquipment");

                    animator.SetBool("open", !isOpen);
                    animator1.SetBool("downEquipment", !isDown);
                }
                else
                {
                    bool isOpen = animator.GetBool("open");
                    //bool isDown = animator1.GetBool("downEquipment");
                    //bool auxBool = aux.GetBool("statusPanelOpen");

                    //aux.SetBool("statusPanelOpen", !auxBool);
                    animator.SetBool("open", !isOpen);
                    //animator1.SetBool("downEquipment", !isDown);
                }
                
            }
        }
        if (i == 3)
        {
            if (panel != null)
            {
                Animator animator = panel.GetComponent<Animator>();
                //Animator animator1 = downPanel1.GetComponent<Animator>();
                //Animator animator2 = downPanel2.GetComponent<Animator>();
                if (animator != null)
                {
                    bool isOpen = animator.GetBool("open");
                    //bool isDown = animator1.GetBool("downPanel1");
                    //bool isDown1 = animator2.GetBool("downPanel2");

                    animator.SetBool("open", !isOpen);
                    //animator1.SetBool("downPanel1", !isDown);
                    //animator2.SetBool("downPanel2", !isDown1);
                }
            }
        }*/
    }
}
