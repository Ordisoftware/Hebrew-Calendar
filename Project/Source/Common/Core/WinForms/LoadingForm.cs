/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-01 </created>
/// <edited> 2021-08 </edited>
using System;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  partial class LoadingForm : Form
  {

    public const int QuantaTotalDefault = 10;

    static public LoadingForm Instance { get; private set; }

    static LoadingForm()
    {
      Instance = new LoadingForm();
    }

    private bool UseQuanta;
    private int QuantaTotal;
    private int QuantaLevel;
    private int CurrentQuanta;

    public event Action Progressing;
    public bool CancelRequired { get; set; }
    public bool Hidden { get; set; }

    private LoadingForm()
    {
      InitializeComponent();
      Icon = Globals.MainForm?.Icon;
    }

    private void LoadingForm_Load(object sender, EventArgs e)
    {
      Relocalize();
    }

    public void Relocalize()
    {
      LabelTitle.Text = Globals.AssemblyTitle; // TODO remove ?
    }

    public void Initialize(string text,
                           int count,
                           int minimum = 0,
                           bool quantify = true,
                           int quantaTotal = QuantaTotalDefault,
                           bool showCounter = false,
                           bool canCancel = false,
                           bool topMost = false)
    {
      LabelTitle.Text = Globals.AssemblyTitle;
      TopMost = topMost;
      CancelRequired = false;
      ActionCancel.Visible = canCancel;
      LabelCount.Visible = showCounter;
      QuantaTotal = quantaTotal;
      this.CenterToMainFormElseScreen();
      if ( !Hidden )
        if ( minimum == 0 || ( minimum > 0 && count > minimum ) )
        {
          Show();
          BringToFront();
        }
      if ( count <= 0 ) count = 1;
      UseQuanta = quantify && count > QuantaTotal;
      QuantaLevel = UseQuanta ? count / QuantaTotal : 1;
      CurrentQuanta = 0;
      ProgressBar.Value = 0;
      ProgressBar.Maximum = UseQuanta ? QuantaTotal - 1 : count - 1;
      ProgressBar.Refresh();
      LabelOperation.Text = text;
      LabelCount.Text = LabelCount.Visible ? $"{minimum}/{count}" : string.Empty;
      Refresh();
      Application.DoEvents();
    }

    public void DoProgress(int index = -1)
    {
      bool process = true;
      if ( UseQuanta )
      {
        CurrentQuanta++;
        if ( CurrentQuanta >= QuantaLevel )
          CurrentQuanta = 0;
        else
          process = false;
      }
      if ( process )
      {
        if ( index == -1 )
          ProgressBar.PerformStep();
        else
          ProgressBar.Value = index;
        if ( LabelCount.Visible ) LabelCount.Text = $"{ProgressBar.Value}/{ProgressBar.Maximum}";
        ProgressBar.Refresh();
        Refresh();
        BringToFront();
      }
      SystemManager.TryCatchManage(() => Progressing?.Invoke());
      if ( ActionCancel.Visible ) Application.DoEvents();
    }

    public void SetProgress(int index)
    {
      ProgressBar.Value = index > ProgressBar.Maximum ? ProgressBar.Maximum : index;
      ProgressBar.Refresh();
    }

    private void ActionCancel_Click(object sender, EventArgs e)
    {
      CancelRequired = true;
    }

  }

}
