using UnityEngine;
using UnityEngine.EventSystems;

// ĳ���� �̹��� Ŭ���� ���� ȿ��
public class PanelClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject border; // �׵θ�
    public GameObject linkCharacter; // ������ ĳ����

    public string imgID;
    public static PanelClick selectedImg; //���� ���õ� �̹���
    public static string selectedID;

    void Start()
    {
        border.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventdata)
    {
        if (selectedImg != null) // ���õ� �̹����� ���� �� �׵θ� ����
            selectedImg.border.SetActive(false);
       
        if (selectedImg == this)
        {
            border.SetActive(false);
            selectedImg = null;
            selectedID = null;
            Debug.Log("���� ������");
            return;
        }

        border.SetActive(true); // �׵θ� �ѱ�
        selectedImg = this;
        selectedID = imgID; // �̹��� ID ����

        Debug.Log("���õ� �̹���: " + selectedID);
    }
}
