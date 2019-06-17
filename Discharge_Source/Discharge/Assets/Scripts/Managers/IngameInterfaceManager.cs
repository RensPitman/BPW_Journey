using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameInterfaceManager : MonoBehaviour
{
    [Header("Global")]
    public bool InstructionIsActive;
    public float TextDisplayTime;
    private int currentText;

    [Header("Instruction 01")]    
    public CanvasGroup InstructionOneGroup;
    public List<GameObject> InstructionText;

    [Header("Instruction 02")]
    public Transform FocusTarget;
    public CanvasGroup InstructionTwoGroup;


    private void Start()
    {
        if(InstructionIsActive)
        {
            InstructionOneGroup.alpha = 1;
            StartCoroutine(WaitForText());

            GameManager.Player.CurrentCamera.AllowFollow = false;
        }
    }

    private void Update()
    {
        if (FocusTarget == null)
        {
            GameManager.Player.PlayerIsCameraTarget();
            Close();
        }
    }

    public void StartInstruction(int index)
    {
        if (!InstructionIsActive)
        {
            //GameManager.Player.CurrentCamera.AllowFollow = false;

            if(index == 2)
            {
                InstructionIsActive = true;

                GameManager.Player.SetCameraTarget(FocusTarget);
                InstructionTwoGroup.alpha = 1;
            }
        }
    }

    IEnumerator WaitForText()
    {
        while(currentText < InstructionText.Count)
        {
            InstructionText[currentText].SetActive(true);

            if(currentText > 0)
                InstructionText[currentText - 1].SetActive(false);

            yield return new WaitForSeconds(TextDisplayTime);
            currentText++;
        }

        Close();
    }

    void Close()
    {
        InstructionOneGroup.alpha = 0;
        InstructionTwoGroup.alpha = 0;
        InstructionIsActive = false;
        GameManager.Player.CurrentCamera.AllowFollow = true;
    }
}
