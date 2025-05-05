using System.Collections;
using System.Linq;
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

    public GameObject PW; // 비밀번호 이벤트 오브젝트
    public PWMission PWMission;

    public GameObject PWBox; // 비밀번호박스 이벤트 오브젝트
    public SequenceMission PWBoxMission;

    string[] RepairEvent = new string[]
    {
        "라디오를 발견했다.",
        "잡음이 계속해서 들린다.",
        "수리해볼까?"
    };

    string[] BoxEvent = new string[]
    {
        "박스를 발견했다.",
        "열려있는것 같다.",
        "확인해볼까?"
    };

    string[] BedRoomEvent = new string[]
    {
        "열려있는 문이 보인다.",
        "방안이 깜깜해서 아무것도 보이지 않는다.",
        "불을 켜볼까?"
    };

    string[] MedicineEvent = new string[]
    {
        "의무실에 들어왔다.",
        "수상한 약이 보인다.",
        "지금 사용해볼 수 있을 것 같은데...."
    };

    string[] ShowerRoomEvent = new string[]
    {
        "샤워실이다.",
        "배수구에 수돗물이 남아있지 않을까?",
        "확인해볼까?"
    };

    string[] ResearchRoomEvent = new string[]
    {
        "실험실에 들어왔다.",
        "실험중이던 장비가 보인다.",
        "가져갈까?"
    };

    string[] ToiletEvent = new string[]
    {
        "화장실이다.",
        "변기 안에 물이 남아있는것같다.",
        "물을 가져갈까?"
    };

    string[] PowerRoomEvent = new string[]
    {
        "발전실이 보인다.",
        "전기가 누출되지 않았을까...",
        "한번 살펴볼까?"
    };

    string[] WareHouseEvent = new string[]
    {
        "창고에 들어갔다.",
        "경비원이 쓰려져있다.",
        "창고에서 빠져나오지 못한것 같다.",
        "주변을 둘러볼까?"
    };

    string[] RestaurantEvent = new string[]
    {
        "식당이다.",
        "먹을게 남아있는지 찾아볼까?"
    };

    string[] PWEvent = new string[]
    {
        "실험실 한켠에 문이 보인다.",
        "비밀번호로 잠겨있다.",
        "주변에 힌트가 있을것 같은데....",
    };

    string[] PWBoxEvent = new string[]
    {
        "박스를 발견했다.",
        "잠겨있는것 같다.",
        "주변에는 순서대로라는 메모가 있다.",
        "비밀번호를 눌러볼까?"
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
                CommonPart();
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
                CommonPart();
            }
        }
        if (eventType == "BedRoom")
        {
            if (index < BedRoomEvent.Length)
            {
                eventText.text += BedRoomEvent[index] + "\n";
                index++;
            }
            else
            {
                CommonPart();
            }
        }
        if (eventType == "Medicine")
        {
            if (index < MedicineEvent.Length)
            {
                eventText.text += MedicineEvent[index] + "\n";
                index++;
            }
            else
            {
                CommonPart();
            }
        }
        if (eventType == "Shower")
        {
            if (index < ShowerRoomEvent.Length)
            {
                eventText.text += ShowerRoomEvent[index] + "\n";
                index++;
            }
            else
            {
                CommonPart();
            }
        }
        if (eventType == "Research") // 태그에 따른 이벤트 진행
        {
            if (index < ResearchRoomEvent.Length)
            {
                eventText.text += ResearchRoomEvent[index] + "\n";
                index++;
            }
            else
            {
                CommonPart();
            }
        }
        if (eventType == "Toilet") // 태그에 따른 이벤트 진행
        {
            if (index < ToiletEvent.Length)
            {
                eventText.text += ToiletEvent[index] + "\n";
                index++;
            }
            else
            {
                CommonPart();
            }
        }
        if (eventType == "PowerRoom") // 태그에 따른 이벤트 진행
        {
            if (index < PowerRoomEvent.Length)
            {
                eventText.text += PowerRoomEvent[index] + "\n";
                index++;
            }
            else
            {
                CommonPart();
            }
        }
        if (eventType == "Warehouse") // 태그에 따른 이벤트 진행
        {
            if (index < WareHouseEvent.Length)
            {
                eventText.text += WareHouseEvent[index] + "\n";
                index++;
            }
            else
            {
                CommonPart();
            }
        }
        if (eventType == "Restaurant") // 태그에 따른 이벤트 진행
        {
            if (index < RestaurantEvent.Length)
            {
                eventText.text += RestaurantEvent[index] + "\n";
                index++;
            }
            else
            {
                CommonPart();
            }
        }


        if (eventType == "PW")
        {
            if (index < PWEvent.Length)
            {
                eventText.text += PWEvent[index] + "\n";
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
                    PW.SetActive(false);
                    AdvCharacter.moveLock = false;
                    endState = true;
                }
            }
        }
        if (eventType == "PWBox")
        {
            if (index < PWBoxEvent.Length)
            {
                eventText.text += PWBoxEvent[index] + "\n";
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
                    PWBox.SetActive(false);
                    AdvCharacter.moveLock = false;
                    endState = true;
                }
            }
        }
    }

    public void CommonPart()
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

    public void YesBtnClicked()
    {
        if (eventType == "repair")
        {
            randInt = Random.Range(0, 100);
            if(randInt <= AdvCharacter.status.mental) // mental에 따른 이벤트 성공확률
            {
                eventText.text = "성공!\n음식 1+";
                advRoomEvent.Food++;
            }
            else
            {
                eventText.text = "실패";
            }
            endNormalEvent();
        }
        if (eventType == "box")
        {
            randInt = Random.Range(0, 100);
            if (randInt <= AdvCharacter.status.mental)
            {
                eventText.text = "성공!\n물 1+";
                advRoomEvent.Water++;
            }
            else
            {
                eventText.text = "실패";
            }
            endNormalEvent();
        }
        if (eventType == "BedRoom")
        {
            AdvCharacter.status.hp -= 10; //체력감소
            eventText.text = "감전당했다!!\n체력 10감소";
            endNormalEvent();
        }
        if (eventType == "Medicine")
        {
            randInt = Random.Range(0, 100);
            if (randInt <=50)
            {
                AdvCharacter.status.hp += 20;
                eventText.text = "건강해지는 느낌이다.\n체력 20증가";
                
            }
            else
            {
                AdvCharacter.status.hp -= 20;
                eventText.text = "몸이 무거워진다....\n체력 20감소";
            }
            endNormalEvent();
        }
        if(eventType == "Shower")
        {
            if (advRoomEvent.Water > 0)
            {
                advRoomEvent.Water--;
            }
            eventText.text = "바닷물이 나왔다.\n물병의 물을 버렸다.\n물 1감소";
            endNormalEvent();
        }
        if (eventType == "Research")
        {
            int randint = Random.Range(0, 2);
            if(randint == 0)
            {
                advRoomEvent.Tool++;
                eventText.text = "장비가 멀쩡한 것같다.\n도구 1획득";
            }
            else
            {
                eventText.text = "장비가 고장나 있다.\n아무것도 얻지 못했다.";
            }
            endNormalEvent();
        }
        if (eventType == "Toilet")
        {
            advRoomEvent.Water++;
            AdvCharacter.status.mental -= 10;
            eventText.text = "마실 수 있는 물 같다.\n하지만 뭔가 찝찝하다...\n물 1획득\n 멘탈 10감소";
            endNormalEvent();
        }

        if (eventType == "PowerRoom")
        {
            advRoomEvent.Battery++;
            eventText.text = "배터리를 발견했다.\n배터리 1획득";
            endNormalEvent();
        }
        if (eventType == "Warehouse")
        {
            randInt = Random.Range(0, 100);
            if (randInt <= AdvCharacter.status.mental) // mental에 따른 이벤트 성공확률
            {
                eventText.text = "쓸만한 도구를 발견했다\n도구 1획득";
                advRoomEvent.Tool++;
            }
            else
            {
                eventText.text = "실패";
            }
            endNormalEvent();
        }
        if (eventType == "Restaurant")
        {
            int randint = Random.Range(0, 4);
            if (randint == 0)
            {
                advRoomEvent.Food += 2;
                eventText.text = "음식을 발견했다.\n음식 2획득";
            }
            else if(randint == 1)
            {
                advRoomEvent.Water += 2;
                eventText.text = "물을 발견했다.\n물 2획득";
            }
            else if (randint == 2)
            {
                advRoomEvent.Food++;
                advRoomEvent.Water++;
                eventText.text = "음식과 물을 발견했다.\n음식, 물 1획득";
            }
            else
            {
                eventText.text = "아무것도 찾지 못했다.";
            }
            endNormalEvent();
        }


        if (eventType == "PW")
        {
            PW.SetActive(true);
            PWMission.MakePW();
            StartCoroutine(WaitPW());
        }
        if (eventType == "PWBox")
        {
            PWBox.SetActive(true);
            PWBoxMission.end = false;
            StartCoroutine(WaitPWBox());
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
        // 구역A
        if (eventType == "Shower" || eventType == "BedRoom" || eventType == "Medicine")
        {
            endEvent();
        }

        // 구역B
        if(eventType == "Research" || eventType == "Toilet")
        {
            endEvent();
        }

        // 구역C
        if (eventType == "PowerRoom" || eventType == "Warehouse" || eventType == "Restaurant")
        {
            endEvent();
        }

        // 미니게임
        if (eventType == "PW" || eventType == "PWBox")
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
        randInt = Random.Range(0, 100);

        if (AdvCharacter.area == "A")
        {
            if (randInt >= 0 && randInt < 10)
            {
                eventType = "repair";
            }
            else if (randInt >= 10 && randInt < 11)
            {
                eventType = "box";
            }
            else if (randInt >= 11 && randInt < 12)
            {
                eventType = "BedRoom";
            }
            else if (randInt >= 12 && randInt < 13)
            {
                eventType = "Medicine";
            }
            else if (randInt >= 13 && randInt < 80)
            {
                eventType = "Shower";
            }
            else if (randInt >= 80 && randInt < 100)
            {
                eventType = "PWBox";
            }
        }
        else if (AdvCharacter.area == "B")
        {
            if (randInt >= 0 && randInt < 10)
            {
                eventType = "repair";
            }
            else if (randInt >= 10 && randInt < 20)
            {
                eventType = "box";
            }
            else if (randInt >= 20 && randInt < 30)
            {
                eventType = "Research";
            }
            else if (randInt >= 30 && randInt < 40)
            {
                eventType = "Toilet";
            }
            else if (randInt >= 40 && randInt < 100)
            {
                eventType = "PW";
            }
        }
        else if (AdvCharacter.area == "C")
        {
            if (randInt >= 0 && randInt < 10)
            {
                eventType = "repair";
            }
            else if (randInt >= 10 && randInt < 20)
            {
                eventType = "box";
            }
            else if (randInt >= 20 && randInt < 30)
            {
                eventType = "PowerRoom";
            }
            else if (randInt >= 30 && randInt < 90)
            {
                eventType = "Warehouse";
            }
            else if (randInt >= 90 && randInt < 100)
            {
                eventType = "Restaurant";
            }
        }
        NextBtn.gameObject.SetActive(true); // 이벤트 시작 시 next 버튼과 text창이 보임
        eventText.gameObject.SetActive(true);
    }

    public void endEvent()
    {
        eventText.text = "아무일도 일어나지 않았다.";
        YesBtn.gameObject.SetActive(false);
        NoBtn.gameObject.SetActive(false);

        NextBtn.gameObject.SetActive(true);
        eventState = true;
    }
    public void endNormalEvent()
    {
        YesBtn.gameObject.SetActive(false);
        NoBtn.gameObject.SetActive(false);

        NextBtn.gameObject.SetActive(true);
        eventState = true;
    }

    private IEnumerator WaitPW() // 미션이 끝날때까지 기다림
    {
        yield return new WaitUntil(() => PWMission.end == true);
        advRoomEvent.Research++;
        eventText.text = "잠김문을 열어보니 연구자료가 들어있다.\n연구자료 1 획득.";
        endNormalEvent();
    }

    private IEnumerator WaitPWBox() // 미션이 끝날때까지 기다림
    {
        yield return new WaitUntil(() => PWBoxMission.end == true);
        advRoomEvent.Food += 2;
        advRoomEvent.Water += 2;
        eventText.text = "상자안에 비상식량이 들어있다.\n식량, 물 2 획득.";
        endNormalEvent();
    }
}
