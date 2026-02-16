using UnityEngine;

public class FrameClick : MonoBehaviour
{
    public RoomOneController room;

    void OnMouseDown()
    {
        room.ClickOnFrame(gameObject);
    }
}
    