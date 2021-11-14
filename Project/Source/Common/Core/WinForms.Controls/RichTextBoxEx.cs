using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Represents a standard <see cref="RichTextBox"/> with some
  /// minor added functionality.
  /// http://geekswithblogs.net/pvidler/archive/2003/10/14/182.aspx
  /// </summary>
  /// <remarks>
  /// AdvRichTextBox provides methods to maintain performance
  /// while it is being updated. Additional formatting features
  /// have also been added.
  /// </remarks>
  class RichTextBoxEx : RichTextBox
  {
    /// <summary>
    /// Maintains performance while updating.
    /// </summary>
    /// <remarks>
    /// <para>
    /// It is recommended to call this method before doing
    /// any major updates that you do not wish the user to
    /// see. Remember to call EndUpdate when you are finished
    /// with the update. Nested calls are supported.
    /// </para>
    /// <para>
    /// Calling this method will prevent redrawing. It will
    /// also setup the event mask of the underlying richedit
    /// control so that no events are sent.
    /// </para>
    /// </remarks>
    public void BeginUpdate()
    {
      // Deal with nested calls.
      ++updating;
      if ( updating > 1 ) return;

      // Prevent the control from raising any events.
      oldEventMask = NativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.EM_SETEVENTMASK, 0, 0);

      // Prevent the control from redrawing itself.
      NativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.WM_SETREDRAW, 0, 0);
    }

    /// <summary>
    /// Resumes drawing and event handling.
    /// </summary>
    /// <remarks>
    /// This method should be called every time a call is made
    /// made to BeginUpdate. It resets the event mask to it's
    /// original value and enables redrawing of the control.
    /// </remarks>
    public void EndUpdate()
    {
      // Deal with nested calls.
      --updating;
      if ( updating > 0 ) return;

      // Allow the control to redraw itself.
      NativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.WM_SETREDRAW, 1, 0);

      // Allow the control to raise event messages.
      NativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.EM_SETEVENTMASK, 0, oldEventMask);
    }

    /// <summary>
    /// Gets or sets the alignment to apply to the current
    /// selection or insertion point.
    /// </summary>
    /// <remarks>
    /// Replaces the SelectionAlignment from
    /// <see cref="RichTextBox"/>.
    /// </remarks>
    public new TextAlign SelectionAlignment
    {
      get
      {
        var fmt = new NativeMethods.PARAFORMAT();
        fmt.cbSize = Marshal.SizeOf(fmt);

        // Get the alignment.
        NativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.EM_GETPARAFORMAT, NativeMethods.SCF_SELECTION, ref fmt);

        // Default to Left align.
        if ( ( fmt.dwMask & NativeMethods.PFM_ALIGNMENT ) == 0 )
          return TextAlign.Left;
        else
          return (TextAlign)fmt.wAlignment;
      }

      set
      {
        var fmt = new NativeMethods.PARAFORMAT();
        fmt.cbSize = Marshal.SizeOf(fmt);
        fmt.dwMask = NativeMethods.PFM_ALIGNMENT;
        fmt.wAlignment = (short)value;

        // Set the alignment.
        NativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.EM_SETPARAFORMAT, NativeMethods.SCF_SELECTION, ref fmt);
      }
    }

    /// <summary>
    /// This member overrides
    /// <see cref="Control"/>.OnHandleCreated.
    /// </summary>
    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);

      // Enable support for justification.
      NativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.EM_SETTYPOGRAPHYOPTIONS, NativeMethods.TO_ADVANCEDTYPOGRAPHY, NativeMethods.TO_ADVANCEDTYPOGRAPHY);
    }

    private int updating = 0;
    private int oldEventMask = 0;


  }

  /// <summary>
  /// Specifies how text in a AdvRichTextBox is horizontally aligned.
  /// </summary>
  public enum TextAlign
  {
    /// <summary>
    /// The text is aligned to the left.
    /// </summary>
    Left = 1,

    /// <summary>
    /// The text is aligned to the right.
    /// </summary>
    Right = 2,

    /// <summary>
    /// The text is aligned in the center.
    /// </summary>
    Center = 3,

    /// <summary>
    /// The text is justified.
    /// </summary>
    Justify = 4
  }

}
