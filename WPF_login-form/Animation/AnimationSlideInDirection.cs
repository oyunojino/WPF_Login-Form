﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_login_form;

/// <summary>
/// The direction an animation slides in (the slide out direction is reversed)
/// <summary>
public enum AnimationSlideInDirection
{
    /// <summary>
    /// Slide in from the left
    /// </summary>
    Left = 0,
    /// <summary>
    /// Slide in from the right
    /// </summary>
    Right = 1,
    /// <summary>
    /// Slide in from the top
    /// </summary>
    Top = 2,
    /// <summary>
    /// Slide in from the bottom
    /// </summary>
    Bottom = 3
}
