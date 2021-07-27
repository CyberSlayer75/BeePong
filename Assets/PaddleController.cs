using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public enum ControlType { WASD, ARROW}
    public ControlType myType;
    [Range(0,1)]
    public float movementSpeed;
  
    // Update is called once per frame
    void Update()
    {
        if(myType == ControlType.ARROW)
        {
            if (Input.GetKey(KeyCode.DownArrow) && this.transform.position.y > -3.6f)
                this.transform.position += Vector3.down * movementSpeed;
            if (Input.GetKey(KeyCode.UpArrow) && this.transform.position.y < 3.6f)
                this.transform.position += Vector3.up * movementSpeed;
        }
        if (myType == ControlType.WASD)
        {
            if (Input.GetKey(KeyCode.S) && this.transform.position.y > -3.6f)
                this.transform.position += Vector3.down * movementSpeed;
            if (Input.GetKey(KeyCode.W) && this.transform.position.y < 3.6f)
                this.transform.position += Vector3.up * movementSpeed;
        }
    }
}
