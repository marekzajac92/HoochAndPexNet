﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace HoochAndPexNet.Core.Graphic.Interface
{
    public interface IDrawableObject
    {
        Drawable Get();
        int Layer { get; set; }
    }
}
