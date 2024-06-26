﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Content.AL.UIKit.Interfaces;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.AL.UIKit.Widgets;

[PublicAPI]
[Virtual]
public class BorderedPanel : PanelContainer, IDepthMeasure<BorderedPanel>, IBrightnessAware
{
    public BorderedPanel()
    {
    }

    protected override void StylePropertiesChanged()
    {
        base.StylePropertiesChanged();
        ((IDepthMeasure<BorderedPanel>)this).CheckChanges(this);
    }

    protected override void Parented(Control newParent)
    {
        base.Parented(newParent);
        ((IDepthMeasure<BorderedPanel>)this).CheckChanges(this);
    }

    protected override void EnteredTree()
    {
        base.EnteredTree();
        ((IDepthMeasure<BorderedPanel>)this).CheckChanges(this);
    }

    public virtual void OnDepthUpdate(int n)
    {
        if (TryGetStyleProperty(ALStyleConsts.BackgroundPanelStyleboxes, out StyleBox[]? boxes))
        {
            if (boxes is null)
                return;

            PanelOverride = boxes[n % boxes.Length];
        }
        return;
    }

    public float Luminance()
    {
        return PanelOverride.Luminance();
    }
}

public sealed class VBorderedPanel : BorderedPanel
{
    public readonly VStack Inner = new() {Margin = new Thickness(4)};

    public VBorderedPanel()
    {
        Margin = new Thickness(2);
        AddChild(Inner);
        XamlChildren = Inner.Children;
    }
}

public sealed class HBorderedPanel : BorderedPanel
{
    public readonly HStack Inner = new() {Margin = new Thickness(4)};

    public HBorderedPanel()
    {
        Margin = new Thickness(2);
        AddChild(Inner);
        XamlChildren = Inner.Children;
    }
}
