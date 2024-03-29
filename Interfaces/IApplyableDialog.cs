﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at https://mozilla.org/MPL/2.0/.

using Robust.Client.UserInterface;

namespace Content.AL.UIKit.Interfaces;

public interface IApplyableDialog
{
    public event Action? OnModified;

    public abstract void Modified(Control control);

    public abstract void Apply();
}

