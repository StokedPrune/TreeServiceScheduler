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
        [Display(Name = "Date Planted")]
        [DataType(DataType.Date)]
        public DateTime? PlantingDate { get; set; }
        public string Genus { get; set; }
        public string Species { get; set; }
        [Display(Name = "Number Trees")]
        public int? NumTrees { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }
        public string Location { get; set; }
        [Display(Name = "CRMid")]
        public string Crmid { get; set; }
        public string AgeClass { get; set; }
        public string Username { get; set; }
        public string Comments { get; set; }
        public string ProjectNo { get; set; }
        public string DrawingNo { get; set; }
        [Display(Name = "Svc1Due")]
        [DataType(DataType.Date)]
        public DateTime? Service1DateDue { get; set; }
        [Display(Name = "Svc1 Complete")]
        [DataType(DataType.Date)]
        public DateTime? Service1DateComplete { get; set; }
        [Display(Name = "Svc1 By")]
        public string Service1By { get; set; }
        [Display(Name = "Svc2Due")]
        [DataType(DataType.Date)]
        public DateTime? Service2DateDue { get; set; }
        [Display(Name = "Svc2 Complete")]
        [DataType(DataType.Date)]
        public DateTime? Service2DateComplete { get; set; }
        [Display(Name = "Svc2 By")]
        public string Service2By { get; set; }
        [Display(Name = "Svc3Due")]
        [DataType(DataType.Date)]
        public DateTime? Service3DateDue { get; set; }
        [Display(Name = "Svc3 Complete")]
        [DataType(DataType.Date)]
        public DateTime? Service3DateComplete { get; set; }
        [Display(Name = "Svc3 By")]
        public string Service3By { get; set; }
        [Display(Name = "Svc4Due")]
        [DataType(DataType.Date)]
        public DateTime? Service4DateDue { get; set; }
        [Display(Name = "Svc4 Complete")]
        [DataType(DataType.Date)]
        public DateTime? Service4DateComplete { get; set; }
        [Display(Name = "Svc4 By")]
        public string Service4By { get; set; }
        public string DataSource { get; set; }
    }
}
