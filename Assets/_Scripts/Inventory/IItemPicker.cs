using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemPicker
{
    event Action<Item> PickedUp;
}
