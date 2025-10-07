using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public delegate void TriggerDelegateVoid();
    public delegate void TriggerDelegateInt(int Val);
    public delegate void TriggerDelegateFloat(float Val);
    public delegate void TriggerDelegateString(string Val);
    public delegate void TriggerDelegateBool(bool Val);

    [SerializeField] private string triggerTag = "Player";

    public TriggerDelegateVoid triggerDelegateVoid;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == triggerTag)
        {
            triggerDelegateVoid.Invoke();
        }
    }
}
