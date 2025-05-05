using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class TemperMission : MonoBehaviour
{

    public TextMeshProUGUI adjust;
    public TextMeshProUGUI goal;

    int plusTemper;
    int minusTemper;

    void Start()
    {
        plusTemper = Random.Range(1, 16) * 10; // 10 ~ 150 ���� ����
        minusTemper = Random.Range(-15, 0) * 10; // -150 ~ -10 ���� ����

        int randint = Random.Range(0, 2);

        if(randint == 0)
        {
            goal.text = plusTemper.ToString();
        }
        else
        {
            goal.text = minusTemper.ToString();
        }
    }

    public void checkTemper()
    {
        if (adjust.text == goal.text)
        {
            goal.text = "SUCCESS";
        }
    }
}
