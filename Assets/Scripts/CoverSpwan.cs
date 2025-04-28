using UnityEngine;

//방 생성 스크립트
public class CoverSpwan : MonoBehaviour
{
    public GameObject Normal;
    public GameObject Empty;
    public GameObject Event;

    public float xSize = 1f;
    public float ySize = 1f;
    int randInt = 0;
    public void setCover()
    {
        for (float x = 37.5f; x <= 43.5f; x += xSize)
        {
            for (float y = -0.5f; y <= 1.5f; y += ySize)
            {
                Vector3 spawnPos = new Vector3(x, y);

                if (Mathf.Approximately(x, 37.5f) && Mathf.Approximately(y, 0.5f)) // 캐릭터 시작 좌표만 제외
                    continue;

                randInt = Random.Range(0, 10);
                if (randInt <= 3)
                {
                    Instantiate(Normal, spawnPos, Quaternion.identity);
                }
                else if (randInt > 3 && randInt <= 6)
                {
                    Instantiate(Empty, spawnPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(Event, spawnPos, Quaternion.identity);
                }
            }
        }
    }

}
