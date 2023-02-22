using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Domain.Entities
{
    public class Proposal:Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string ProposalName { get; set; }
        public string ProposalDescription { get; set;}
        public string Pitch { get; set;}
        public long RequestedAmount { get; set; }
        public decimal MaximumEquity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Proposal()
        {

        }
        public Proposal(string proposalName, string proposalDescription, string pitch, long requestedAmount, decimal maximumEquity, DateTime createdDate, DateTime startDate, DateTime endDate)
        {
            ProposalName=proposalName;
            ProposalDescription=proposalDescription;
            Pitch=pitch;
            RequestedAmount=requestedAmount;
            MaximumEquity=maximumEquity;
            CreatedDate=createdDate;
            StartDate=startDate;
            EndDate=endDate;
            IsActive=true;
        }

        public Proposal DeleteData()
        {
            IsActive = false;
            UpdatedOn = DateTime.UtcNow;

            return this;
        }
    }
}
