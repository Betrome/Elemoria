using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOffset : MonoBehaviour
{
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(this.transform.parent.rotation.x * -1.0f, this.transform.parent.rotation.y * -1.0f, this.transform.parent.rotation.z * -1.0f);
    }
}
