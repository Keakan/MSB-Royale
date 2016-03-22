using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public int joystickNumber;
        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }
        private void Update()
        {
            string joystickString = joystickNumber.ToString();
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButton("Y_P" + joystickString);
            }
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Movement_P" + joystickString);
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
    //private Vector3 movementVector;
    //    private float movementSpeed = 8;
    //    private float jumpPower = 15;
    //    private float gravity = 40;
    //    public int joystickNumber;

    //    private PlatformerCharacter2D m_Character;
    //    private bool m_Jump;

    //    private void start()
    //    {
    //        m_Character = GetComponent<PlatformerCharacter2D>();
    //    }
    //    void Update()
    //    {
    //    }
        
    //    private void FixedUpdate()
    //    {
    //        string joystickString = joystickNumber.ToString();
    //        float h = Input.GetAxis("LeftJoystickX_P" + joystickString) * movementSpeed;
    //        bool crouch = Input.GetButtonDown("A_P" + joystickString);
    //        if (!m_Jump)
    //        {
    //            // Read the jump input in Update so button presses aren't missed.
    //            m_Jump = CrossPlatformInputManager.GetButtonDown("A_P" + joystickString);
    //        }
    //        // Pass all parameters to the character control script.
    //        m_Character.Move(h, crouch, m_Jump);
    //        m_Jump = false;
    //    }
    //}
}

