﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winterdom.Viasfora.Languages.BraceExtractors;
using Winterdom.Viasfora.Languages.Sequences;
using Winterdom.Viasfora.Util;

namespace Winterdom.Viasfora.Languages {
  public class Css : LanguageInfo {
    public const String ContentType = "css";
    public const String SassContentType = "SCSS";
    public override String BraceList {
      get { return "()[]{}"; }
    }

    protected override String KeyName {
      get { return "CSS"; }
    }
    protected override String[] ContentTypes {
      get { return new String[] { ContentType, SassContentType }; }
    }
    protected override String[] ControlFlowDefaults {
      get { return EMPTY; }
    }
    protected override String[] LinqDefaults {
      get { return EMPTY; }
    }
    protected override String[] VisibilityDefaults {
      get { return EMPTY; }
    }

    public override IEscapeSequenceParser NewEscapeSequenceParser(string text) {
      return new CssEscapeSequenceParser(text);
    }
    public override IBraceExtractor NewBraceExtractor() {
      return new CssBraceExtractor(this);
    }
  }
}
