using TMPro;
using UnityEngine;

public class RoomEvent : MonoBehaviour
{
    public int day; //���� ��¥ ǥ��
    public bool isAdv; //���� �������� ĳ���Ͱ� �ִ��� üũ

    public Camera roomCam;  // �� ī�޶�
    public Camera advCam; // ���� ī�޶�

    public TextMeshProUGUI DayText; //���� ��¥ ǥ�� text

    public GameObject Character1; //ĳ���� ����
    public GameObject Character2;
    public GameObject Character3;
    Status cha1;
    Status cha2;
    Status cha3;

    void Start()
    {
        roomCam.enabled = true;
        advCam.enabled = false;

        day = 1;
        cha1 = Character1.GetComponent<Status>();
        cha2 = Character2.GetComponent<Status>();
        cha3 = Character3.GetComponent<Status>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DayText.text = "Day:" + day.ToString();

        for (int i = 0; i < 3; i++)
        {
            if (cha1.adventure == true || cha2.adventure == true || cha3.adventure == true)
            {
                isAdv = true;
            }
            else
            {
                isAdv = false;
            }
        }
    }
}
