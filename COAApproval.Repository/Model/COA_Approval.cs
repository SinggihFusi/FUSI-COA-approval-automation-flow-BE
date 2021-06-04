namespace COAApproval.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("coa_approval", Schema = "public")]
    public partial class COA_Approval
    {
        [Key]
        public int id { get; set; }

        public int surveyor_id { get; set; }

        public DateTime date { get; set; }

        public string coa_file { get; set; }

        [StringLength(1000)]
        public string note { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        public int pic1_id { get; set; }

        [StringLength(50)]
        public string pic1_approval_status { get; set; }

        [StringLength(1000)]
        public string pic1_note { get; set; }

        public int pic2_id { get; set; }

        [StringLength(50)]
        public string pic2_approval_status { get; set; }

        [StringLength(1000)]
        public string pic2_note { get; set; }

        public int next_approver { get; set; }

        [NotMapped]
        public string email { get; set; }

        [NotMapped]
        public string createdBy { get; set; }

        [NotMapped]
        public string name { get; set; }

    }

    public partial class SurveyorInput
    {
        [NotMapped]
        public int surveyor_id { get; set; }

        [NotMapped]
        public string coa_file { get; set; }

        [NotMapped]
        [StringLength(1000)]
        public string note { get; set; }

    }

    public partial class ApprovalAtasan
    {
        [NotMapped]
        public int user_id { get; set; }

        [NotMapped]
        public int id_coa_approval { get; set; }

        [NotMapped]
        [StringLength(50)]
        public string pic_approval_status { get; set; }

        [NotMapped]
        [StringLength(1000)]
        public string pic1_note { get; set; }

    }
}