using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Domain.Entities
{
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string StateName { get; set; }
        
        [ForeignKey(nameof(CountryId))]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }
        public State()
        {

        }
        public State(string stateName, long countryId)
        {
            StateName=stateName;
            CountryId=countryId;
        }
    }
}
