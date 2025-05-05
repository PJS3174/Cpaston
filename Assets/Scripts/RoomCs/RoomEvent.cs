using TMPro;
using UnityEngine;

public class RoomEvent : MonoBehaviour
{
    public int day; //현재 날짜 표시
    public bool isAdv; //현재 모험중인 캐릭터가 있는지 체크

    public Camera roomCam;  // 방 카메라
    public Camera advCam; // 모험 카메라

    public TextMeshProUGUI DayText; //현재 날짜 표시 text

    public GameObject Character1; //캐릭터 정보
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
