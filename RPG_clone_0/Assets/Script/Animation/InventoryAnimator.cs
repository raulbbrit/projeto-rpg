using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAnimator: MonoBehaviour
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
    [Header("Fechar Outros Paineis")]
    public GameObject statusPanel;
    public GameObject equipmentPanel;
    public GameObject skillsPanel;

    [Space]
    [Header("Animar a Posição das Caixas")]
    public GameObject downEquipment;
    public GameObject downSkills;


    private void Start()
    {
        inventoryGroup.SetActive(false);
    }

    public void PanelOpen()
    {
        if (panel != null)
        {
            Animator animator = panel.GetComponent<Animator>();
            Animator animatorSelf = GetComponentInParent<Animator>();
            Animator animator1 = statusPanel.GetComponent<Animator>();
            Animator animator2 = equipmentPanel.GetComponent<Animator>();
            Animator animator3 = skillsPanel.GetComponent<Animator>();
            Animator animator4 = downEquipment.GetComponent<Animator>();
            Animator animator5 = downSkills.GetComponent<Animator>();

            bool isOpen = animator.GetBool("open");
            bool isDown = animator4.GetBool("isSlided");
            bool isDown1 = animator5.GetBool("isSlided");
            if (animator4.GetBool("isSlided") && animator5.GetBool("isSlided") && animator.GetBool("open"))
            {
                
                //bool isAlreadyDown = animator1.GetBool("isSlided");

                if (!isOpen)
                {
                    inventoryGroup.SetActive(true);
                    skillGroup.SetActive(false);
                    equipmentGroup.SetActive(false);
                    statsGroup.SetActive(false);
                }
                else
                {
                    inventoryGroup.SetActive(false);
                }

                animator.SetBool("open", !isOpen);
                animatorSelf.SetBool("isSlided", false);
                //animator1.SetBool("isSlided", !isDown);
                animator1.SetBool("open", false);
                animator2.SetBool("open", false);
                animator3.SetBool("open", false);
                animator4.SetBool("isSlided", false);
                animator5.SetBool("isSlided", false);

            }
            else
            {
                animatorSelf.SetBool("isSlided", false);

                if (isOpen) {
                    inventoryGroup.SetActive(false);
                }
                else
                {
                    inventoryGroup.SetActive(true);
                    skillGroup.SetActive(false);
                    equipmentGroup.SetActive(false);
                    statsGroup.SetActive(false);
                }
                animator.SetBool("open", !isOpen);
                animator1.SetBool("open", false);
                animator2.SetBool("open", false);
                animator3.SetBool("open", false);
                animator4.SetBool("isSlided", true);
                animator5.SetBool("isSlided", true);
            }
            /*else
            {
                bool isOpen = animator.GetBool("open");
                bool isDown = animator2.GetBool("isSlided");
                

                animator.SetBool("open", !isOpen);
                animator1.SetBool("isSlided", !isDown);
                
            }*/
        }
    }
}
