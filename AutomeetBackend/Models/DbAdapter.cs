using DA = System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomeetBackend.Models
{
    public abstract class DbAdapter
    {
        [DA.Key]
        public abstract System.Guid UserId { get; set; }
        public abstract List<string>? Columns { get; set; }
        public abstract List<string>? ActiveColumns { get; set; }

        public abstract Task getColumns();
        public abstract Task<string> getContactData();
    }
}
