using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardofPardons.Entity
{
    public class AllFormReview
    {
        public int Id { get; set; }
        public int type { get; set; }
        public IncarceratedStep1 IncarceratedStep1 { get; set; }
        public IncarceratedStep2 IncarceratedStep2 { get; set; }
        public IncarceratedStep3 IncarceratedStep3 { get; set; }
        public IncarceratedStep4 IncarceratedStep4 { get; set; }
        public IncarceratedStep5 IncarceratedStep5 { get; set; }
        public IncarceratedStep6 IncarceratedStep6 { get; set; }
        public IncarceratedStep7 IncarceratedStep7 { get; set; }

        public NonIncarceratedStep1 NonIncarceratedStep1 { get; set; }
        public NonIncarceratedStep2 NonIncarceratedStep2 { get; set; }
        public NonIncarceratedStep3 NonIncarceratedStep3 { get; set; }
        public NonIncarceratedStep4 NonIncarceratedStep4 { get; set; }
        public NonIncarceratedStep5 NonIncarceratedStep5 { get; set; }
        public NonIncarceratedStep6 NonIncarceratedStep6 { get; set; }
        public NonIncarceratedStep7 NonIncarceratedStep7 { get; set; }


    }
}
