using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Domain.Entities
{
    public  class Client:BaseEntity
    {

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } =string.Empty;

        public string ContactNo { get; set; } = string.Empty;

        public DateOnly AgreementDate { get; set; }

        public int TotalEmployees { get; set; }

        public int SecurityDeposit { get; set; }

        public bool IsDeleted { get; set; }

        public AppFile AgreementDocument { get; set; } = null!;

        public Guid UserId { get; set; }


        #region NavigationProperties
        [ForeignKey(nameof(Id))]
        public User User { get; set; } =null!;

        #endregion

    }
}
