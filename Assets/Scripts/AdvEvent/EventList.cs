using System.Collections;
using System.Linq;
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

    public GameObject PW; // ��й�ȣ �̺�Ʈ ������Ʈ
    public PWMission PWMission;

    public GameObject PWBox; // ��й�ȣ�ڽ� �̺�Ʈ ������Ʈ
    public SequenceMission PWBoxMission;

    string[] RepairEvent = new string[]
    {
        "������ �߰��ߴ�.",
        "������ ����ؼ� �鸰��.",
        "�����غ���?"
    };

    string[] BoxEvent = new string[]
    {
        "�ڽ��� �߰��ߴ�.",
        "�����ִ°� ����.",
        "Ȯ���غ���?"
    };

    string[] BedRoomEvent = new string[]
    {
        "�����ִ� ���� ���δ�.",
        "����� �����ؼ� �ƹ��͵� ������ �ʴ´�.",
        "���� �Ѻ���?"
    };

    string[] MedicineEvent = new string[]
    {
        "�ǹ��ǿ� ���Դ�.",
        "������ ���� ���δ�.",
        "���� ����غ� �� ���� �� ������...."
    };

    string[] ShowerRoomEvent = new string[]
    {
        "�������̴�.",
        "������� �������� �������� ������?",
        "Ȯ���غ���?"
    };

    string[] ResearchRoomEvent = new string[]
    {
        "����ǿ� ���Դ�.",
        "�������̴� ��� ���δ�.",
        "��������?"
    };

    string[] ToiletEvent = new string[]
    {
        "ȭ����̴�.",
        "���� �ȿ� ���� �����ִ°Ͱ���.",
        "���� ��������?"
    };

    string[] PowerRoomEvent = new string[]
    {
        "�������� ���δ�.",
        "���Ⱑ ������� �ʾ�����...",
        "�ѹ� ���캼��?"
    };

    string[] WareHouseEvent = new string[]
    {
        "â�� ����.",
        "������ �������ִ�.",
        "â���� ���������� ���Ѱ� ����.",
        "�ֺ��� �ѷ�����?"
    };

    string[] RestaurantEvent = new string[]
    {
        "�Ĵ��̴�.",
        "������ �����ִ��� ã�ƺ���?"
    };

    string[] PWEvent = new string[]
    {
        "����� ���ҿ� ���� ���δ�.",
        "��й�ȣ�� ����ִ�.",
        "�ֺ��� ��Ʈ�� ������ ������....",
    };

    string[] PWBoxEvent = new string[]
    {
        "�ڽ��� �߰��ߴ�.",
        "����ִ°� ����.",
        "�ֺ����� ������ζ�� �޸� �ִ�.",
        "��й�ȣ�� ��������?"
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
        if (eventType == "Research") // �±׿� ���� �̺�Ʈ ����
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
        if (eventType == "Toilet") // �±׿� ���� �̺�Ʈ ����
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
        if (eventType == "PowerRoom") // �±׿� ���� �̺�Ʈ ����
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
        if (eventType == "Warehouse") // �±׿� ���� �̺�Ʈ ����
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
        if (eventType == "Restaurant") // �±׿� ���� �̺�Ʈ ����
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
            if(randInt <= AdvCharacter.status.mental) // mental�� ���� �̺�Ʈ ����Ȯ��
            {
                eventText.text = "����!\n���� 1+";
                advRoomEvent.Food++;
            }
            else
            {
                eventText.text = "����";
            }
            endNormalEvent();
        }
        if (eventType == "box")
        {
            randInt = Random.Range(0, 100);
            if (randInt <= AdvCharacter.status.mental)
            {
                eventText.text = "����!\n�� 1+";
                advRoomEvent.Water++;
            }
            else
            {
                eventText.text = "����";
            }
            endNormalEvent();
        }
        if (eventType == "BedRoom")
        {
            AdvCharacter.status.hp -= 10; //ü�°���
            eventText.text = "�������ߴ�!!\nü�� 10����";
            endNormalEvent();
        }
        if (eventType == "Medicine")
        {
            randInt = Random.Range(0, 100);
            if (randInt <=50)
            {
                AdvCharacter.status.hp += 20;
                eventText.text = "�ǰ������� �����̴�.\nü�� 20����";
                
            }
            else
            {
                AdvCharacter.status.hp -= 20;
                eventText.text = "���� ���ſ�����....\nü�� 20����";
            }
            endNormalEvent();
        }
        if(eventType == "Shower")
        {
            if (advRoomEvent.Water > 0)
            {
                advRoomEvent.Water--;
            }
            eventText.text = "�ٴ幰�� ���Դ�.\n������ ���� ���ȴ�.\n�� 1����";
            endNormalEvent();
        }
        if (eventType == "Research")
        {
            int randint = Random.Range(0, 2);
            if(randint == 0)
            {
                advRoomEvent.Tool++;
                eventText.text = "��� ������ �Ͱ���.\n���� 1ȹ��";
            }
            else
            {
                eventText.text = "��� ���峪 �ִ�.\n�ƹ��͵� ���� ���ߴ�.";
            }
            endNormalEvent();
        }
        if (eventType == "Toilet")
        {
            advRoomEvent.Water++;
            AdvCharacter.status.mental -= 10;
            eventText.text = "���� �� �ִ� �� ����.\n������ ���� �����ϴ�...\n�� 1ȹ��\n ��Ż 10����";
            endNormalEvent();
        }

        if (eventType == "PowerRoom")
        {
            advRoomEvent.Battery++;
            eventText.text = "���͸��� �߰��ߴ�.\n���͸� 1ȹ��";
            endNormalEvent();
        }
        if (eventType == "Warehouse")
        {
            randInt = Random.Range(0, 100);
            if (randInt <= AdvCharacter.status.mental) // mental�� ���� �̺�Ʈ ����Ȯ��
            {
                eventText.text = "������ ������ �߰��ߴ�\n���� 1ȹ��";
                advRoomEvent.Tool++;
            }
            else
            {
                eventText.text = "����";
            }
            endNormalEvent();
        }
        if (eventType == "Restaurant")
        {
            int randint = Random.Range(0, 4);
            if (randint == 0)
            {
                advRoomEvent.Food += 2;
                eventText.text = "������ �߰��ߴ�.\n���� 2ȹ��";
            }
            else if(randint == 1)
            {
                advRoomEvent.Water += 2;
                eventText.text = "���� �߰��ߴ�.\n�� 2ȹ��";
            }
            else if (randint == 2)
            {
                advRoomEvent.Food++;
                advRoomEvent.Water++;
                eventText.text = "���İ� ���� �߰��ߴ�.\n����, �� 1ȹ��";
            }
            else
            {
                eventText.text = "�ƹ��͵� ã�� ���ߴ�.";
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
        // ����A
        if (eventType == "Shower" || eventType == "BedRoom" || eventType == "Medicine")
        {
            endEvent();
        }

        // ����B
        if(eventType == "Research" || eventType == "Toilet")
        {
            endEvent();
        }

        // ����C
        if (eventType == "PowerRoom" || eventType == "Warehouse" || eventType == "Restaurant")
        {
            endEvent();
        }

        // �̴ϰ���
        if (eventType == "PW" || eventType == "PWBox")
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
        NextBtn.gameObject.SetActive(true); // �̺�Ʈ ���� �� next ��ư�� textâ�� ����
        eventText.gameObject.SetActive(true);
    }

    public void endEvent()
    {
        eventText.text = "�ƹ��ϵ� �Ͼ�� �ʾҴ�.";
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

    private IEnumerator WaitPW() // �̼��� ���������� ��ٸ�
    {
        yield return new WaitUntil(() => PWMission.end == true);
        advRoomEvent.Research++;
        eventText.text = "��蹮�� ����� �����ڷᰡ ����ִ�.\n�����ڷ� 1 ȹ��.";
        endNormalEvent();
    }

    private IEnumerator WaitPWBox() // �̼��� ���������� ��ٸ�
    {
        yield return new WaitUntil(() => PWBoxMission.end == true);
        advRoomEvent.Food += 2;
        advRoomEvent.Water += 2;
        eventText.text = "���ھȿ� ���ķ��� ����ִ�.\n�ķ�, �� 2 ȹ��.";
        endNormalEvent();
    }
}
