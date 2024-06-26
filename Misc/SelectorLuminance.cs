﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Content.AL.UIKit.Interfaces;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Content.AL.UIKit.Misc;

public sealed class SelectorLuminance : Selector
{
    public Selector Modified { get; }

    public float Luminance { get; }
    public SelectorMode Mode { get; }

    public SelectorLuminance(Selector modified, float luminance, SelectorMode mode)
    {
        Modified = modified;
        Luminance = luminance;
        Mode = mode;
    }

    public override bool Matches(Control control)
    {
        var luminosity = 0.0f;
        {
            var parent = control;
            while (parent is not null)
            {
                parent = parent.Parent;
                if (EngineControlCheck(parent) is { } lum)
                {
                    luminosity = lum;
                    break;
                }
                if (parent is IBrightnessAware b)
                {
                    luminosity = b.Luminance();
                    break;
                }
            }
        }

        return Modified.Matches(control) && Evaluate(luminosity);
    }

    private bool Evaluate(float lum)
    {
        if (Mode == SelectorMode.GreaterThan)
        {
            return Luminance <= lum;
        }
        else if (Mode == SelectorMode.LessThan)
        {
            return Luminance >= lum;
        }

        return false;
    }

    private float? EngineControlCheck(Control? c)
    {
        if (c is ContainerButton b)
        {
            if (b.TryGetStyleProperty<StyleBox>(ContainerButton.StylePropertyStyleBox, out var box))
            {
                return box.Luminance();
            }
        }

        return null;
    }

    public override StyleSpecificity CalculateSpecificity()
    {
        return Modified.CalculateSpecificity(); // We're an operator, not any more specific.
    }

    public enum SelectorMode
    {
        LessThan,
        GreaterThan
    }
}

public sealed class MutableSelectorLuminance : MutableSelector
{
    public MutableSelector Modified { get; }

    public float Luminance { get; }
    public SelectorLuminance.SelectorMode Mode { get; }


    public MutableSelectorLuminance(MutableSelector modified, float luminance, SelectorLuminance.SelectorMode mode)
    {
        Modified = modified;
        Luminance = luminance;
        Mode = mode;
    }

    protected override Selector ToSelector()
    {
        return new SelectorLuminance(Modified, Luminance, Mode);
    }
}
