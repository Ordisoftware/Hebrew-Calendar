// <copyright file="Extensions.cs" company="Brown University">
// Copyright (c) 2009 by John Mertus
// https://www.codeproject.com/Articles/43472/A-Pretty-Good-Menu-Cloner
// </copyright>
// <author>John Mertus</author>
// <date>10/31/2009 9:30:22 AM</date>
// <summary></summary>
namespace Ordisoftware.Core;

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

/// <summary>
/// This is a set of extensions for accessing the Event Handlers as well as cloning menu items
/// </summary>
[SuppressMessage("Naming", "GCop209:Use PascalCasing for {0} names", Justification = "<En attente>")]
public static class ToolStripMenuItemHelper
{

  //////////////////////////////////////////////////
  // Private static fields
  //////////////////////////////////////////////////
  #region Public static methods

  /// <summary>
  /// This contains a counter to help make names unique
  /// </summary>
  private static int menuNameCounter = 0;

  #endregion

  //////////////////////////////////////////////////
  // Public static methods
  //////////////////////////////////////////////////
  #region Public static methods

  /// <summary>
  /// Clones the specified source tool strip menu item.
  /// </summary>
  /// <param name="sourceToolStripMenuItem">The source tool strip menu item.</param>
  /// <returns>A cloned version of the toolstrip menu item</returns>
  [SuppressMessage("Usage", "RCS1202:Avoid NullReferenceException.", Justification = "N/A")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "N/A")]
  [SuppressMessage("Performance", "GCop318:This will cause the query to be computed multiple times. Instead call .ToList() on the variable declaration line to avoid unwanted extra processing.", Justification = "<En attente>")]
  public static ToolStripMenuItem Clone(this ToolStripMenuItem sourceToolStripMenuItem)
  {
    var menuItem = new ToolStripMenuItem();
    var propInfoList = from p in typeof(ToolStripMenuItem).GetProperties()
                       let attributes = p.GetCustomAttributes(true)
                       let notBrowseable = ( from a in attributes
                                             where a is BrowsableAttribute
                                             select !( a as BrowsableAttribute ).Browsable ).FirstOrDefault()
                       where !notBrowseable && p.CanRead && p.CanWrite && p.Name != "DropDown"
                       orderby p.Name
                       select p;
    // Copy over using reflections
    foreach ( var propertyInfo in propInfoList )
    {
      var propertyInfoValue = propertyInfo.GetValue(sourceToolStripMenuItem, null);
      propertyInfo.SetValue(menuItem, propertyInfoValue, null);
    }

    // Create a new menu name
    menuItem.Name = $"{sourceToolStripMenuItem.Name} - {menuNameCounter++}";

    // Process any other properties
    if ( sourceToolStripMenuItem.ImageIndex != -1 )
    {
      menuItem.ImageIndex = sourceToolStripMenuItem.ImageIndex;
    }

    if ( !sourceToolStripMenuItem.ImageKey.IsNullOrEmpty() )
    {
      menuItem.ImageKey = sourceToolStripMenuItem.ImageKey;
    }

    // We need to make this visible 
    menuItem.Visible = true;

    // Recursively clone the drop down list
    foreach ( var item in sourceToolStripMenuItem.DropDownItems )
    {
      ToolStripItem newItem;
      if ( item is ToolStripMenuItem menuitem )
      {
        newItem = menuitem.Clone();
      }
      else
      if ( item is ToolStripSeparator )
      {
        newItem = new ToolStripSeparator();
      }
      else
      {
        throw new TypeAccessException("Menu item is not a ToolStripMenuItem or a ToolStripSeparatorr");
      }

      menuItem.DropDownItems.Add(newItem);
    }

    // The handler list starts empty because we created its parent via a new
    // So this is equivalen to a copy.
    menuItem.AddHandlers(sourceToolStripMenuItem);

    return menuItem;
  }

  /// <summary>
  /// Adds the handlers from the source component to the destination component
  /// </summary>
  /// <typeparam name="T">An IComponent type</typeparam>
  /// <param name="destinationComponent">The destination component.</param>
  /// <param name="sourceComponent">The source component.</param>
  public static void AddHandlers<T>(this T destinationComponent, T sourceComponent) where T : IComponent
  {
    // If there are other handlers, they will not be erased
    var destEventHandlerList = destinationComponent.GetEventHandlerList();
    var sourceEventHandlerList = sourceComponent.GetEventHandlerList();

    destEventHandlerList.AddHandlers(sourceEventHandlerList);
  }

  /// <summary>
  /// Gets the event handler list from a component
  /// </summary>
  /// <param name="component">The source component.</param>
  /// <returns>The EventHanderList or null if none</returns>
  [SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "N/A")]
  [SuppressMessage("ReflectionAnalyzers.SystemReflection", "REFL003:The member does not exist", Justification = "N/A")]
  public static EventHandlerList GetEventHandlerList(this IComponent component)
  {
    var eventsInfo = component.GetType().GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
    return (EventHandlerList)eventsInfo.GetValue(component, null);
  }

  #endregion

  //////////////////////////////////////////////////
  // Private static methods
  //////////////////////////////////////////////////

}
