using System.ComponentModel.DataAnnotations.Schema;

namespace Sigma.Task.Core.Entities
{
    public abstract class BaseEntity
    {
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdatedDate { get; set; }
    }
}
