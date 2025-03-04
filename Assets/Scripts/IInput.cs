using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    event System.Action<Vector3> OnMoveInput;
    //event System.Action<Touch> OnTouchInput;
}
