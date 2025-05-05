using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PWMission : MonoBehaviour
{
    public TextMeshProUGUI Hint; // ��Ʈ
    public TextMeshProUGUI InputPW; // �Է� ��й�ȣ
    public Image backGround;

    public string correctPW; //���� ��й�ȣ
    public bool end;
    public void MakePW()
    {
        correctPW = "";
        InputPW.text = "";

        backGround.color = Color.black;

        for(int i = 0; i< 8; i++)
        {
            correctPW += Random.Range(0, 10).ToString();
        }

        Hint.text = correctPW;
        end = false;
    }


    public void CheckPW()
    {
        if (Hint.text == InputPW.text)
        {
            InputPW.text = "CORRECT!!";
            backGround.color = Color.green;
            end = true;
        }
        else
        {
            InputPW.text = "";
            backGround.color = Color.red;
        }
    }
}
