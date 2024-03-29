﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace Content.AL.UIKit.Widgets;

/*
/// <summary>
/// Do not use, incomplete.
/// </summary>
[Virtual]
public class TransformContainer : Container
{
    protected override void RenderChildOverride(IRenderHandle renderHandle, ref int total, Control control, Vector2i position, Color modulate,
        UIBox2i? scissorBox, Matrix3 coordinateTransform)
    {
        var oldXform = renderHandle.DrawingHandleScreen.GetTransform();
        var xform = oldXform;
        if (TryGetStyleProperty(Style.TransformContainerMatrix, out Matrix3 matrix))
        {

            if (TryGetStyleProperty(Style.TransformContainerCenterMatrix, out bool c) && c)
            {
                var centerPoint = new Vector2(PixelSize.X/2.0f, -PixelSize.Y/2.0f);

                var xlate = Matrix3.CreateTranslation(-centerPoint);
                xlate.Multiply(matrix);
                var xlate2 = Matrix3.CreateTranslation(centerPoint);
                xlate.Multiply(xlate2);
                xform.Multiply(xlate);
            }
            else
            {
                xform.Multiply(matrix);
            }

        }

        renderHandle.DrawingHandleScreen.SetTransform(xform);
        base.RenderChildOverride(renderHandle, ref total, control, position, modulate, scissorBox, coordinateTransform);
        renderHandle.DrawingHandleScreen.SetTransform(oldXform);
    }
}*/
