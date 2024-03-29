﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Numerics;
using Content.AL.UIKit.Sheets;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using static Robust.Client.UserInterface.StylesheetHelpers;
using static Content.AL.UIKit.ALStylesheetHelpers;

namespace Content.AL.UIKit.Widgets;

[Stylesheet]
internal sealed class WindowStylesheet : BaseSubsheet
{
    public override StyleRule[] GetRules(BaseStyle origin)
    {
        var (WindowTextures, _, _) =
            origin.LoadIndefiniteNinePatchSet($"{origin.FileRoot}/window_cross_{{0}}.png", 0);
        return new StyleRule[]
        {
            Element().Class(ALStyleConsts.WindowBackground).Prop(PanelContainer.StylePropertyPanel, origin.PanelBackgrounds[0]),
            Element().Class(ALStyleConsts.WindowContentsBackground).Prop(PanelContainer.StylePropertyPanel, origin.PanelBackgrounds[0]),
            E<TextureButton>().Class(DefaultWindow.StyleClassWindowCloseButton).ParentOf(E<TextureRect>())
                .Prop(TextureRect.StylePropertyTexture, WindowTextures[2])
                .Prop(TextureRect.StylePropertyTextureSizeTarget, new Vector2(32, 32)),

            E<TextureButton>().Hover().Class(DefaultWindow.StyleClassWindowCloseButton).ParentOf(E<TextureRect>())
                .Prop(TextureButton.StylePropertyTexture, WindowTextures[3]),
            E<TextureButton>().Pressed().Class(DefaultWindow.StyleClassWindowCloseButton).ParentOf(E<TextureRect>())
                .Prop(TextureButton.StylePropertyTexture, WindowTextures[1]),

            E<TextureRect>().Class("WindowIcon")
                .Prop(TextureRect.StylePropertyTextureSizeTarget, new Vector2(28, 28)),
        };
    }
}
