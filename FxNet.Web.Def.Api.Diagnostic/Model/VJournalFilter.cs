﻿using System;

namespace FxNet.Web.Def.Api.Diagnostic.Model
{
    public class VJournalFilter
    {
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public string Search { get; set; }
    }
}
