using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

// �̺�Ʈ �� �̺�Ʈ ����Ʈ
public class EventList : MonoBehaviour
{
    int randInt = 0;

    public GameObject Character;
    AdvCharacter AdvCharacter;
    AdvRoomEvent advRoomEvent;

    public GameObject panel;
    public TextMeshProUGUI eventText;
    
    public Button NextBtn; // �̺�Ʈ �ؽ�Ʈ �Ѿ�� ���
    public Button YesBtn; 
    public Button NoBtn; // �̺�Ʈ ���� ���� ���� ��ư

    string eventType;// � �̺�Ʈ���� ���� ex)���� ���� ��

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

    int index;// ���� �̺�Ʈ �ؽ�Ʈ�� �ε���
    public bool eventState; // false = �̺�Ʈ ������, true = �̺�Ʈ ��
    public bool endState;
    void Start()
    {
        AdvCharacter = Character.GetComponent<AdvCharacter>(); // ������ Ȱ���ϱ� ���� ����

        NextBtn.onClick.AddListener(NextBtnClicked);
        YesBtn.onClick.AddListener(YesBtnClicked);
        NoBtn.onClick.AddListener(NoBtnClicked);

        advRoomEvent = AdvCharacter.GM.GetComponent<AdvRoomEvent>(); // �κ��丮�� ����
    }
    public void NextBtnClicked()
    {
        if (eventType == "repair") // �±׿� ���� �̺�Ʈ ����
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
            if(randInt <= AdvCharacter.status.mental) // mental�� ���� �̺�Ʈ ����Ȯ��
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

    public void callEvent() // Ȯ���� ���� �̺�Ʈ �߻�
    {
        eventState = false;
        endState = false;

        index = 0; // �ε��� �ʱ�ȭ
        eventText.text = ""; // �ؽ�Ʈ �ʱ�ȭ

        Debug.Log("�̺�Ʈ ����Ʈ ����");
        randInt = Random.Range(0, 10);

        if (randInt >=0 && randInt < 5)
        {
            eventType = "repair";
        }
        else if(randInt >=5 && randInt < 10)
        {
            eventType = "box";
        }

        NextBtn.gameObject.SetActive(true); // �̺�Ʈ ���� �� next ��ư�� textâ�� ����
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
