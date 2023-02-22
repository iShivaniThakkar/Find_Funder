using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Domain.Entities
{
    public class Company:Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string CompanyName { get; set;}
        public string CompanyDescription { get; set;}
        public string WebsiteUrl { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long PhoneNo { get; set; }
        public long CurrentRevenue { get; set; }
        public DateTime FoundedDate { get; set; }

        public Company()
        {

        }
        public Company(string companyName,string companyDescription, string websiteUrl,string logo,string address,string email,long phoneNo,long currentRevenue,DateTime foundedDate)
        {
            CompanyName = companyName;
            CompanyDescription= companyDescription;
            WebsiteUrl = websiteUrl;
            Logo = logo;
            Address = address;
            Email = email;
            PhoneNo = phoneNo;
            CurrentRevenue = currentRevenue;
            FoundedDate = foundedDate;
            IsActive= true;
            CreatedOn= DateTime.UtcNow;
        }
      
    }
}
