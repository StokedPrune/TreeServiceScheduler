using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreeServiceScheduler.Models
{
    public partial class TreeSchedule
    {
        public int Id { get; set; }
        [Display(Name="Date Recorded")]
        [DataType(DataType.Date)]
        public DateTime? RecordDate { get; set; }
        public DateTime? PlantingDate { get; set; }
        public string Genus { get; set; }
        public string Species { get; set; }
        public int? NumTrees { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }
        public string Location { get; set; }
        public string Crmid { get; set; }
        public string AgeClass { get; set; }
        public string Username { get; set; }
        public string Comments { get; set; }
        public string ProjectNo { get; set; }
        public string DrawingNo { get; set; }
        public DateTime? Service1DateDue { get; set; }
        public DateTime? Service1DateComplete { get; set; }
        public DateTime? Service2DateDue { get; set; }
        public DateTime? Service2DateComplete { get; set; }
        public string Service1By { get; set; }
        public string Service2By { get; set; }
        public DateTime? Service3DateDue { get; set; }
        public DateTime? Service3DateComplete { get; set; }
        public string Service3By { get; set; }
        public DateTime? Service4DateDue { get; set; }
        public DateTime? Service4DateComplete { get; set; }
        public string Service4By { get; set; }
        public string DataSource { get; set; }
    }
}
