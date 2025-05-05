using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// ĳ���� �̹��� Ŭ���� ���� ȿ��
public class PanelClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject border; // �׵θ�
    public GameObject linkCharacter; // ������ ĳ����
    public TextMeshProUGUI statusCheck; // ���� ������ ����
    Status status;

    public string imgID;
    public static PanelClick selectedImg; //���� ���õ� �̹���
    public static string selectedID;

    void Start()
    {
        status  = linkCharacter.GetComponent<Status>();
        border.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventdata)
    {
        if (selectedImg != null) // ���õ� �̹����� ���� �� �׵θ� ����
        { 
            selectedImg.border.SetActive(false);
        }
       
        if (selectedImg == this)
        {
            border.SetActive(false);
            selectedImg = null;
            selectedID = null;
            Debug.Log("���� ������");
            statusCheck.text = "";
            return;
        }

        border.SetActive(true); // �׵θ� �ѱ�
        selectedImg = this;
        selectedID = imgID; // �̹��� ID ����

        if (status.hp <= 30)
        {
            statusCheck.text = "���� �� ����...";
        }
        else if (status.hp > 30 && status.hp <= 60)
        {
            statusCheck.text = "�Ҹ���";
        }
        else
        {
            statusCheck.text = "�ڽ��־�!!";
        }

    }
}
