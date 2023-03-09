using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform  CameraPosistion;
    // Update is called once per frame
   private  void Update()
    {
        transform.position = CameraPosistion.position;
    }
}
