﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace Content.AL.UIKit.Widgets.Decorative;

/// <summary>
///     A set of vertical bars meant to look like a grille. Decorative, no function.
/// </summary>
public sealed class BarPatch : VStack
{
    public BarPatch()
    {
        VerticalExpand = false;
        VerticalAlignment = VAlignment.Center;
        HorizontalExpand = true;
        HorizontalAlignment = HAlignment.Stretch;
    }

    public int Count
    {
        set
        {
            RemoveAllChildren();
            for (int i = 0; i < value; i++)
            {
                AddChild(new HBar { Margin = new (2)});
            }
        }
    }
}
