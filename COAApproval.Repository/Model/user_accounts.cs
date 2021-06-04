namespace COAApproval.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user_accounts", Schema = "public")]
    public partial class user_accounts
    {
        [Key]
        public int user_id { get; set; }

        [StringLength(250)]
        public string username { get; set; }

        [StringLength(250)]
        public string password { get; set; }

        [StringLength(250)]
        public string email { get; set; }

        [StringLength(250)]
        public string role { get; set; }

        public int? id_atasan { get; set; }
    }

    public partial class user_login
    {
        [StringLength(250)]
        public string username { get; set; }

        [StringLength(250)]
        public string password { get; set; }
    }
}