﻿/*
 *  NetDemo - A Unity client/standalone server demo using Railgun and MiniUDP
 *  Copyright (c) 2016 - Alexander Shoulson - http://ashoulson.com
 *
 *  This software is provided 'as-is', without any express or implied
 *  warranty. In no event will the authors be held liable for any damages
 *  arising from the use of this software.
 *  Permission is granted to anyone to use this software for any purpose,
 *  including commercial applications, and to alter it and redistribute it
 *  freely, subject to the following restrictions:
 *  
 *  1. The origin of this software must not be misrepresented; you must not
 *     claim that you wrote the original software. If you use this software
 *     in a product, an acknowledgment in the product documentation would be
 *     appreciated but is not required.
 *  2. Altered source versions must be plainly marked as such, and must not be
 *     misrepresented as being the original software.
 *  3. This notice may not be removed or altered from any source distribution.
*/

#if SERVER
using UnityStandalone;
#else
using UnityEngine;
#endif

namespace GameLogic
{
  public static class GameMath
  {
    internal const float FIXED_DELTA_TIME = 0.02f;

    internal const float COORDINATE_PRECISION = 0.001f;
    internal const float ANGLE_PRECISION = 0.001f;

    internal static bool CoordinatesEqual(float a, float b)
    {
      return Mathf.Abs(a - b) < GameMath.COORDINATE_PRECISION;
    }

    internal static bool AnglesEqual(float a, float b)
    {
      return Mathf.Abs(a - b) < GameMath.ANGLE_PRECISION;
    }

    internal static float LerpUnclampedFloat(
      float from,
      float to,
      float t)
    {
      return (from + ((to - from) * t));
    }
  }
}