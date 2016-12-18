﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRegistry.Models
{
    public class tblWAR_Accomplishments
    {
        //PRIMARY KEY
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int AccomoplishmentId { get; set; }

        //FOREIGN KEY
        public virtual int ProjId { get; set; }
        public virtual int AccStatusId { get; set; }
        public virtual int EmpId { get; set; }

        //TABLE FIELDS
        public virtual string Accomplishment { get; set; }
        public virtual DateTimeOffset WeekEndingDate { get; set; }
        public virtual bool AccArchive { get; set; }

        public virtual lutWAR_Projects lutWAR_Projects { get; set; }
        public virtual tblER_Employee tblER_Employee { get; set; }
        public virtual lutWAR_AccStatus lutWAR_AccStatus { get; set; }

    }
}