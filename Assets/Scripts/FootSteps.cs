using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] private AudioSource footStepsSound;
    [SerializeField] private AudioSource jumpSound;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W)
          || Input.GetKey(KeyCode.A)
          || Input.GetKey(KeyCode.S)
          || Input.GetKey(KeyCode.D)
          || Input.GetKey(KeyCode.UpArrow)
          || Input.GetKey(KeyCode.DownArrow)
          || Input.GetKey(KeyCode.LeftArrow)
          || Input.GetKey(KeyCode.RightArrow))
        {
            footStepsSound.enabled = true;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            jumpSound.enabled = true;
        }
        else
        {
            jumpSound.enabled = false;
            footStepsSound.enabled = false;
        }
    }
}
