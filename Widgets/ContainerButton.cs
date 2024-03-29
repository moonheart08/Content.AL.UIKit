﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Content.AL.UIKit.Interfaces;
using Robust.Client.Graphics;

namespace Content.AL.UIKit.Widgets;

[PublicAPI]
[Virtual]
public class ContainerButton : Robust.Client.UserInterface.Controls.ContainerButton, IBrightnessAware
{
    protected StyleBox ActualStyleBox
    {
        get
        {
            if (TryGetStyleProperty<StyleBox>(StylePropertyStyleBox, out var box))
            {
                return box;
            }

            return UserInterfaceManager.ThemeDefaults.ButtonStyle;
        }
    }

    public float Luminance()
    {
        return ActualStyleBox.Luminance();
    }
}
