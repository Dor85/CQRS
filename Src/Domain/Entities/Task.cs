using Company.Project.Domain.Common;
using Company.Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.Domain.Entities
{
    public class Task : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TaskEnum Status { get; set; }

        public int ResponsableId { get; set; }
        public Person Responsable { get; set; }

        public int AssignedId { get; set; }
        public Person Assigned { get; set; }

        public string GetResponsableName()
        {
            return Responsable.GetFullName();
        }

        public string GetAssigneeName()
        {
            return Assigned.GetFullName();
        }
    }
}
