using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Domain.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } 
        public string CityName { get; set; }
        
        [ForeignKey(nameof(StateId))]
        public long StateId { get; set; }
        public virtual State State { get; set; }

        public City() { }

        public City(string cityName,long stateId)
        {
            CityName = cityName;
            StateId = stateId;
           
        }
    }
}
