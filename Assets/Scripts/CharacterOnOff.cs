using UnityEngine;

public class CharacterOnOff : MonoBehaviour
{
    public GameObject cha;
    public GameObject character;
    private Status status;

    void Start()
    {
        status = cha.GetComponent<Status>();
    }
    void Update()
    {
        if (status.adventure == true)
        {
            character.SetActive(false);
        }
        else if(status.adventure == false)
        {
            character.SetActive(true);
        }
    }
}
