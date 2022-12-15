using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public float Horizontal { get; private set; }

    public bool Backspace { get; private set; }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        Backspace = Input.GetKey(KeyCode.Space);
    }
}
