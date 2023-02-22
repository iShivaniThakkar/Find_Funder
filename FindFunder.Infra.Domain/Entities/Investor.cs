using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Domain.Entities
{
    public class Investor:Audit
    {
        [Key]
        public long Id { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public long CityId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public Investor()
        {

        }
        public Investor(DateTime birthdate, string address,long cityId, long userId)
        {
            Birthdate = birthdate;
            Address = address;
            CityId = cityId;
            UserId = userId;    
            CreatedOn= DateTime.UtcNow;
            //CreatedBy = User.FirstName;
            IsActive = true;
        }
    }
}
