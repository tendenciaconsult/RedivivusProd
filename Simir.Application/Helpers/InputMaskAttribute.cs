using System;

namespace Simir.Application.Helpers
{
    public class InputMaskAttribute : Attribute //, IMetadataAware
    {
        public InputMaskAttribute(string mask)
        {
            Mask = mask;
            IsReverso = false;
        }

        public string Final { get; set; }
        public string Mask { get; set; }
        public string Url { get; set; }
        public bool IsReverso { get; set; }

        public bool TemFinal
        {
            get { return !String.IsNullOrWhiteSpace(Final); }
        }
    }
}