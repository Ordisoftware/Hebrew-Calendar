/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2024 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides panel view connector for a component.
/// </summary>
public readonly record struct ViewConnector<TComponent>(
  TComponent Component,
  Panel Panel,
  Control Focused)
where TComponent : Component;

/// <summary>
/// Provides ViewConnector dictionary.
/// </summary>
[SuppressMessage("Major Code Smell", "S3925:\"ISerializable\" should be implemented correctly", Justification = "N/A")]
public sealed class ViewConnectors<TView, TComponent> : Dictionary<TView, ViewConnector<TComponent>>
where TView : Enum
where TComponent : Component;