using UnityEngine;

public class OpenDoorButton : MonoBehaviour
{
    ValueManager valueManager = new ValueManager();
    public void TryOpenDoor()
    {
        if (valueManager.EqualityCheck())
            Debug.Log("������� �� ��������");
        else
            Debug.Log("����");
    }
}
