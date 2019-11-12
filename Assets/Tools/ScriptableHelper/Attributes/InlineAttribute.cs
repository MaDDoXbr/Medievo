﻿using UnityEngine;

// Source: https://forum.unity.com/threads/editor-tool-better-scriptableobject-inspector-editing.484393/
// Credits go to @Fydar at the Unity Forums

/// <summary>
/// Use this property on a ScriptableObject type to allow the editors drawing the field to draw an expandable
/// area that allows for changing the values on the object without having to change editor.
/// </summary>
public class InlineAttribute : PropertyAttribute
{
    public InlineAttribute()
    { }
}