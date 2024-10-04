using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerVibration : MonoBehaviour
{
    // This method will trigger the vibration
    public void TriggerVibration(float intensity = 0.5f, float duration = 1.0f)
    {
        // Get the gamepad
        var gamepad = Gamepad.current;
        if (gamepad != null)
        {
            // Start vibrating
            gamepad.SetMotorSpeeds(intensity, intensity);
            StartCoroutine(StopVibrationAfterDuration(duration));
        }
    }

    private System.Collections.IEnumerator StopVibrationAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Stop vibrating
        var gamepad = Gamepad.current;
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0, 0);
        }
    }
}
