﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Content.AL.UIKit.Interfaces;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Utility;

namespace Content.AL.UIKit.Widgets;

public sealed class RichText : RichTextLabel
{
    private const float SwitchToDarkLevel = 0.65f;

    public RichText()
    {
    }

    protected override void Parented(Control newParent)
    {
        base.Parented(newParent);
        Update();
    }

    protected override void EnteredTree()
    {
        base.EnteredTree();
        Update();
    }

    protected override void StylePropertiesChanged()
    {
        base.StylePropertiesChanged();
        Update();
    }

    public FormattedMessage? FormattedText { get; set; }


    public string Text
    {
        set
        {
            FormattedText = FormattedMessage.FromMarkup(value);
            Update();
        }
    }

    public Type[]? TagsAllowed = null;

    public void Update()
    {
        var luminosity = 0.0f;
        {
            var parent = (Control)this;
            while (parent is not null)
            {
                parent = parent.Parent;
                if (parent is IBrightnessAware b)
                {
                    luminosity = b.Luminance();
                    break;
                }
            }
        }
        if (luminosity >= SwitchToDarkLevel && TryGetStyleProperty(ALStyleConsts.FontColorLightBg, out Color color))
        {
            if (FormattedText is not null)
                SetMessage(FormattedText, tagsAllowed: TagsAllowed, defaultColor: color);
        }
        else if (TryGetStyleProperty(ALStyleConsts.FontColor, out Color c))
        {
            if (FormattedText is not null)
                SetMessage(FormattedText, tagsAllowed: TagsAllowed, defaultColor: c);
        }


    }


}
