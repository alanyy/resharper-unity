﻿using UnityEngine;

public class Foo : MonoBehaviour
{
  [SerializeField] private int myValue, my{caret:Annotate:'myValue2':with:'Range':attribute}Value2, myValue3;
}
