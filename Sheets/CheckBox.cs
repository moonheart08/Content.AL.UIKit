﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Numerics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Content.AL.UIKit.ALStylesheetHelpers;


namespace Content.AL.UIKit.Sheets;

[Stylesheet]
public sealed class CheckBox : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        return new StyleRule[]
        {
            E<TextureRect>().Class(Robust.Client.UserInterface.Controls.CheckBox.StyleClassCheckBox)
                .Prop(TextureRect.StylePropertyTexture, origin.LoadTexture($"{origin.FileRoot}/checkbox_off.png"))
                .Prop(TextureRect.StylePropertyTextureSizeTarget, new Vector2(28, 28)),
            E<TextureRect>().Class(Robust.Client.UserInterface.Controls.CheckBox.StyleClassCheckBoxChecked)
                .Prop(TextureRect.StylePropertyTexture, origin.LoadTexture($"{origin.FileRoot}/checkbox_on.png"))
                .Prop(TextureRect.StylePropertyTextureSizeTarget, new Vector2(28, 28)),
        };
    }
}
