﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using Winterdom.Viasfora.Design;
using Winterdom.Viasfora.Text;
using Winterdom.Viasfora.Util;
using System.Collections.ObjectModel;

namespace Winterdom.Viasfora.Options {
  [Guid(Guids.TextObfuscationOptions)]
  public class TextObfuscationOptions : UIElementDialogPage {
    private TextObfuscationDialog dialog;
    protected override System.Windows.UIElement Child {
      get { return dialog; }
    }
    public TextObfuscationOptions() {
     this.dialog = new TextObfuscationDialog();
    }
    public override void SaveSettingsToStorage() {
      base.SaveSettingsToStorage();

      // This call is necessary so that if the grid has the focus
      // it loses it so that changes to the data context are
      // propagated properly!
      MoveFocusToNext();

      VsfSettings.TextObfuscationRegexes = dialog.Entries.ListToJson();
      VsfSettings.Save();
    }
    public override void LoadSettingsFromStorage() {
      base.LoadSettingsFromStorage();
      this.dialog.Entries.Clear();
      var entries = VsfSettings.TextObfuscationRegexes.ListFromJson<RegexEntry>();
      foreach ( var entry in entries ) {
        this.dialog.Entries.Add(entry);
      }
    }
  }
}