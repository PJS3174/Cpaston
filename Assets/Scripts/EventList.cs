using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

// 이벤트 방 이벤트 리스트
public class EventList : MonoBehaviour
{
    int randInt = 0;

    public GameObject Character;
    AdvCharacter AdvCharacter;
    AdvRoomEvent advRoomEvent;

    public GameObject panel;
    public TextMeshProUGUI eventText;
    
    public Button NextBtn; // 이벤트 텍스트 넘어가기 기능
    public Button YesBtn; 
    public Button NoBtn; // 이벤트 진행 여부 선택 버튼

    string eventType;// 어떤 이벤트인지 저장 ex)수리 상자 등

    string[] RepairEvent = new string[]
    {
        "radio detecetd",
        "look breakdown",
        "try repair?"
    };

    string[] BoxEvent = new string[]
    {
        "box detecetd",
        "look closed",
        "try open?"
    };

    int index;// 현재 이벤트 텍스트의 인덱스
    public bool eventState; // false = 이벤트 진행중, true = 이벤트 끝
    public bool endState;
    void Start()
    {
        AdvCharacter = Character.GetComponent<AdvCharacter>(); // 구역을 활용하기 위해 연결

        NextBtn.onClick.AddListener(NextBtnClicked);
        YesBtn.onClick.AddListener(YesBtnClicked);
        NoBtn.onClick.AddListener(NoBtnClicked);

        advRoomEvent = AdvCharacter.GM.GetComponent<AdvRoomEvent>(); // 인벤토리와 연결
    }
    public void NextBtnClicked()
    {
        if (eventType == "repair") // 태그에 따른 이벤트 진행
        {
            if (index < RepairEvent.Length)
            {
                eventText.text += RepairEvent[index] + "\n";
                index++;
            }
            else
            {
                NextBtn.gameObject.SetActive(false);

                if (eventState == false)
                {
                    YesBtn.gameObject.SetActive(true);
                    NoBtn.gameObject.SetActive(true);
                }
                else
                {
                    eventText.gameObject.SetActive(false);
                    AdvCharacter.moveLock = false;
                    endState = true;
                }
            }
        }
        if (eventType == "box")
        {
            if (index < BoxEvent.Length)
            {
                eventText.text += BoxEvent[index] + "\n";
                index++;
            }
            else
            {
                NextBtn.gameObject.SetActive(false);
               
                if (eventState == false)
                {
                    YesBtn.gameObject.SetActive(true);
                    NoBtn.gameObject.SetActive(true);
                }
                else
                {
                    eventText.gameObject.SetActive(false);
                    AdvCharacter.moveLock = false;
                    endState = true;
                }
            }
        }

    }

    public void YesBtnClicked()
    {
        if (eventType == "repair")
        {
            randInt = Random.Range(0, 100);
            if(randInt <= AdvCharacter.status.mental) // mental에 따른 이벤트 성공확률
            {
                eventText.text = "success\nfood 1+";
                advRoomEvent.food++;
                Debug.Log("food: " + advRoomEvent.food);
                endEvent();
            }
            else
            {
                eventText.text = "Fail";
                endEvent();
            }
        }
        if (eventType == "box")
        {
            randInt = Random.Range(0, 100);
            if (randInt <= AdvCharacter.status.mental)
            {
                eventText.text = "success\nwater 1+";
                advRoomEvent.water++;
                Debug.Log("water: " + advRoomEvent.water);
                endEvent();
            }
            else
            {
                eventText.text = "Fail";
                endEvent();
            }
        }
    }

    public void NoBtnClicked()
    {
        if (eventType == "repair")
        {
            endEvent();
        }
        if (eventType == "box")
        {
            endEvent();
        }
    }

    public void callEvent() // 확률에 따라 이벤트 발생
    {
        eventState = false;
        endState = false;

        index = 0; // 인덱스 초기화
        eventText.text = ""; // 텍스트 초기화

        Debug.Log("이벤트 리스트 정상");
        randInt = Random.Range(0, 10);

        if (randInt >=0 && randInt < 5)
        {
            eventType = "repair";
        }
        else if(randInt >=5 && randInt < 10)
        {
            eventType = "box";
        }

        NextBtn.gameObject.SetActive(true); // 이벤트 시작 시 next 버튼과 text창이 보임
        eventText.gameObject.SetActive(true);
    }

    public void endEvent()
    {
        eventText.text = "End \nClick Next Button";
        YesBtn.gameObject.SetActive(false);
        NoBtn.gameObject.SetActive(false);

        NextBtn.gameObject.SetActive(true);
        eventState = true;
    }
}
