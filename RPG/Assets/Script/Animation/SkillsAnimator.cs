using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsAnimator : MonoBehaviour
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
    public GameObject inventoryPanel;
    public GameObject equipmentPanel;

    [Space]
    [Header("Animar a Posição das Caixas")]
    public GameObject downInventory;
    public GameObject downEquipment;

    private void Start()
    {
        skillGroup.SetActive(false);
    }

    public void PanelOpener()
    {
        if (panel != null)
        {
            Animator animator = panel.GetComponent<Animator>();
            Animator animatorSelf = GetComponentInParent<Animator>();
            Animator animator1 = downEquipment.GetComponent<Animator>();
            Animator animator2 = downInventory.GetComponent<Animator>();
            Animator animator3 = statusPanel.GetComponent<Animator>();
            Animator animator4 = inventoryPanel.GetComponent<Animator>();
            Animator animator5 = equipmentPanel.GetComponent<Animator>();

            bool isOpen = animator.GetBool("open");
            bool isDown = animator1.GetBool("isSlided");
            if (animator1.GetBool("isSlided") && !animator.GetBool("open"))
            {

                if (!isOpen)
                {
                    skillGroup.SetActive(true);
                    inventoryGroup.SetActive(false);
                    equipmentGroup.SetActive(false);
                    statsGroup.SetActive(false);
                }

                animator.SetBool("open", !isOpen);

                animatorSelf.SetBool("isSlided", false);
                animator2.SetBool("isSlided", false);

                animator3.SetBool("open", false);
                animator4.SetBool("open", false);
                animator5.SetBool("open", false);

                animator1.SetBool("isSlided", isDown);

            }
            else
            {
                animatorSelf.SetBool("isSlided", false);

                if (isOpen)
                {
                    skillGroup.SetActive(false);
                }
                else
                {
                    skillGroup.SetActive(true);
                    inventoryGroup.SetActive(false);
                    equipmentGroup.SetActive(false);
                    statsGroup.SetActive(false);
                }

                animator.SetBool("open", !isOpen);

                animator3.SetBool("open", false);
                animator4.SetBool("open", false);
                animator5.SetBool("open", false);

                animator1.SetBool("isSlided", !isDown);
                animator2.SetBool("isSlided", false);
            }



        }
    }

}
