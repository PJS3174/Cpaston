using UnityEngine;
using UnityEngine.EventSystems;

// �� �̹��� ���� ��
public class SelectMap : MonoBehaviour, IPointerClickHandler
{
    public GameObject border; // �׵θ�

    public string Map;
    public static SelectMap selectedImg; //���� ���õ� �̹���
    public static string selectedMap;

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
            selectedMap = null;
            Debug.Log("���� ������");
            return;
        }

        border.SetActive(true); // �׵θ� �ѱ�
        selectedImg = this;
        selectedMap = Map; // �� �̸� ����

        Debug.Log("���õ� �̹���: " + selectedMap);
    }
}
