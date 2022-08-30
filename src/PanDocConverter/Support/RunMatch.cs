using System;

namespace PanDocConverter.Support
{
    public class RunMatch
    {
        public RunMatch(DocumentFormat.OpenXml.Wordprocessing.Run run)
        {
            Run = run;
        }

        public DocumentFormat.OpenXml.Wordprocessing.Run Run { get; set; }

        public int RunStartPosition { get; set; }

        public int RunEndPosition { get; set; }
    }
}
