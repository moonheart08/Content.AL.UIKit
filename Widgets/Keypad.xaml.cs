﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Timing;

namespace Content.AL.UIKit.Widgets;

[PublicAPI]
[GenerateTypedNameReferences]
public sealed partial class Keypad : GridContainer
{
    public Button[] NumKeys;
    public Button ClearKey;
    public Button EnterKey;

    public Keypad()
    {
        Margin = new Thickness(4);
        RobustXamlLoader.Load(this);
        NumKeys = new[] {B0, B1, B2, B3, B4, B5, B6, B7, B8, B9};
        ClearKey = BClr;
        EnterKey = BE;
    }

    protected override void FrameUpdate(FrameEventArgs args)
    {
        base.FrameUpdate(args);
        // Ew.
        var set = ClearKey.Size;

        foreach (var b in NumKeys)
        {
            b.SetSize = set;
        }

        EnterKey.SetSize = set;
    }
}
