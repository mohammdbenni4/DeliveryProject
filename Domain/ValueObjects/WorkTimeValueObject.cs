using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    [NotMapped]
    public class WorkTimeValueObject : IEquatable<WorkTimeValueObject>
    {
        List<string>? Days { get; }
        List<Dictionary<TimeOnly, TimeOnly>>? Times { get; }

        public bool Equals(WorkTimeValueObject? other)
        {
            if (other == null)
                return false;

            return Days == other.Days && Times == other.Times;
            
        }
    }
}
