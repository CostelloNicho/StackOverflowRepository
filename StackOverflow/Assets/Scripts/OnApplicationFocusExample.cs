#region Directives

using UnityEngine;

#endregion

public class OnApplicationFocusExample : MonoBehaviour
{
    protected void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus)
            OnFocus();
        else
            OnFocusLost();
    }

    private void OnFocus()
    {
        Debug.Log("Game now active on device");
    }

    private void OnFocusLost()
    {
        Debug.Log("Game now inactive");
    }
}