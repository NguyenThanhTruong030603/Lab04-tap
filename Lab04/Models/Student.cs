namespace Lab04.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [StringLength(20)]
        public string StudentID { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        public double AverageScore { get; set; }

        public int FalcultyID { get; set; }

        public virtual Falculty Falculty { get; set; }
    }
}
