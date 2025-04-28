using UnityEngine;

// 선택한 이미지의 캐릭터 정보를 모험 캐릭터에 넘겨줌
public class AdvGo : MonoBehaviour
{
    public GameObject targetObject; // 모험 캐릭터
    public Camera roomCam;  // 방 카메라
    public Camera advCam; // 모험 카메라
   
    public RoomEvent RoomManager; //방의 상태를 받기 위함
    public CoverSpwan coverSpwaner;

    void Start()
    {
        roomCam.enabled = true;
        advCam.enabled = false;
    }
    public void SendStatus()
    {
        if (PanelClick.selectedImg == null)
        {
            Debug.Log("선택된 이미지 없음");
            return;
        }

        GameObject selectedCharacter = PanelClick.selectedImg.linkCharacter; // 선택된 캐릭터 이미지
        GameObject seledtedMap = SelectMap.selectedImg.gameObject; 

        Status roomStatus = selectedCharacter.GetComponent<Status>(); // 선택한 캐릭터 정보
        Status advStatus = targetObject.GetComponent<Status>(); // 모험 중 캐릭터 정보

        AdvCharacter AdvMove = targetObject.GetComponent<AdvCharacter>();

        string selectedMap = SelectMap.selectedMap; // 선택된 맵 정보

        advStatus.name = roomStatus.name;
        advStatus.hp = roomStatus.hp;
        advStatus.mental = roomStatus.mental;
        advStatus.adventure = true;
        roomStatus.adventure = true;

        AdvMove.move = 2;
        AdvMove.area = selectedMap;

        advCam.enabled = true;
        roomCam.enabled = false;

        if (RoomManager.isAdv == false) {
            coverSpwaner.setCover();
        }

        Debug.Log("전달 완료");
    }
}
