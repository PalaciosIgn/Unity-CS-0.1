using UnityEngine;

public class BloquearCursor: MonoBehaviour
{
    void Update()
    {
        //Press the space bar to apply no locking to the Cursor
        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }

    void OnGUI()
    {
        //Press this button to lock the Cursor
        if (GUI.Button(new Rect(5, 0, 100, 50), "Bloc Cursor"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}