using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Domain.Entities
{
    public class Entrepreneur:Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public long UserId { get; set; }
        public virtual User User { get; set; }  
        public Entrepreneur()
        {

        }
        public Entrepreneur(long userId)
        {
            
            UserId = userId;
            CreatedOn = DateTime.UtcNow;
            //CreatedBy = User.FirstName;
            IsActive= true;
        }
    }
}
