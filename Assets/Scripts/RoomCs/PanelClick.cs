using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// 캐릭터 이미지 클릭시 선택 효과
public class PanelClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject border; // 테두리
    public GameObject linkCharacter; // 연결할 캐릭터
    public TextMeshProUGUI statusCheck; // 모험 성공률 추측
    Status status;

    public string imgID;
    public static PanelClick selectedImg; //현재 선택된 이미지
    public static string selectedID;

    void Start()
    {
        status  = linkCharacter.GetComponent<Status>();
        border.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventdata)
    {
        if (selectedImg != null) // 선택된 이미지가 없을 시 테두리 끄기
        { 
            selectedImg.border.SetActive(false);
        }
       
        if (selectedImg == this)
        {
            border.SetActive(false);
            selectedImg = null;
            selectedID = null;
            Debug.Log("선택 해제됨");
            statusCheck.text = "";
            return;
        }

        border.SetActive(true); // 테두리 켜기
        selectedImg = this;
        selectedID = imgID; // 이미지 ID 저장

        if (status.hp <= 30)
        {
            statusCheck.text = "힘들 것 같아...";
        }
        else if (status.hp > 30 && status.hp <= 60)
        {
            statusCheck.text = "할만해";
        }
        else
        {
            statusCheck.text = "자신있어!!";
        }

    }
}
