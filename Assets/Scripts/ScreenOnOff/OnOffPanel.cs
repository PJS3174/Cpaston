using UnityEngine;

// UI OnOff ���
public class OnOffPanel : MonoBehaviour
{
    public GameObject panel;
    public void PanelOnOff()
    {
        panel.SetActive(!panel.activeSelf); // �ǳ��� ������ �ݴ� ���·� �ٲ�
    }
}
