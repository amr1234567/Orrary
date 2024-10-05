using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue
{
    [TextArea(1,4)]
    public string[] questions;
    [TextArea(5,25)]
    public string[] answers;
}
