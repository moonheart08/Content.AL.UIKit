﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Content.AL.UIKit.Interfaces;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Localization;

namespace Content.AL.UIKit.Widgets;

[PublicAPI]
[Virtual]
public class Button : ContainerButton
{
    [Dependency] private ILocalizationManager _localization = default!;

    public Text TextWidget { get; }

    /// <summary>
    ///     The text displayed by the button.
    /// </summary>
    [ViewVariables]
    public string? Text { get => TextWidget.Text; set => TextWidget.Text = value; }

    public Label.AlignMode TextAlign { set => TextWidget.Align = value; }

    public string? GroupName { get; set; }


    protected override void StylePropertiesChanged()
    {
        base.StylePropertiesChanged();
        TextWidget.ForceRunStyleUpdate();
        UpdateGroupAssignment();
    }

    protected override void Parented(Control newParent)
    {
        base.Parented(newParent);
        UpdateGroupAssignment();
    }

    protected override void EnteredTree()
    {
        base.EnteredTree();
        UpdateGroupAssignment();
        if (this.TryGetLocString(_localization) is { } s)
            Text = s;
        if (string.IsNullOrEmpty(Text) && Name is not null)
            Text = Name;
    }

    protected void UpdateGroupAssignment()
    {
        if (GroupName is { } gn && this.GetImplementingParent<IGroupOrganizer>() is {} org)
        {
            Group = org.GetButtonGroup(gn);
        }
    }

    public Button()
    {
        IoCManager.InjectDependencies(this);
        HorizontalExpand = false;
        AddStyleClass(StyleClassButton);
        TextWidget = new Text
        {
            StyleClasses = { StyleClassButton },
            HorizontalAlignment = HAlignment.Center,
        };
        AddChild(TextWidget);
    }


}
