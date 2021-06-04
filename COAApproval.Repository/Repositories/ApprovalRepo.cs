using COAApproval.Repository.Context;
using COAApproval.Repository.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Text;
using System.Threading.Tasks;

namespace COAApproval.Repository.Repositories
{
    public class ApprovalRepo
    {
        #region Get
        public ProcessResult<List<COA_Approval>> GetAllapproval()
        {
            ProcessResult<List<COA_Approval>> result = new ProcessResult<List<COA_Approval>>() { ProcessName = "approval.Get" };
            using (var context = new COAApprovalContext())
            {
                try
                {
                    List<COA_Approval> contentData = context.COA_Approvals.ToList();
                    //List<COA_Approval> contentData = context.Database.ExecuteSqlCommand("Select * from public.coa_approval");
                    foreach (var item in contentData)
                    {
                        int dataint = Convert.ToInt32(item.surveyor_id);
                        item.name = context.user_accountss.Where(x => x.user_id == dataint).Select(a => a.username).FirstOrDefault();
                        item.email = context.user_accountss.Where(x => x.user_id == dataint).Select(a => a.email).FirstOrDefault();
                        item.createdBy = context.user_accountss.Where(x => x.user_id == dataint).Select(a => a.username).FirstOrDefault();
                    }

                    result.Data = contentData;

                    ProcessResult.Success(result);
                }
                catch (Exception ex)
                {
                    ProcessResult.Error(result, ex.InnerException);
                }
            }
            return result;
        }

        public ProcessResult<List<COA_Approval>> GetApprovalByID(int id)
        {
            ProcessResult<List<COA_Approval>> result = new ProcessResult<List<COA_Approval>>() { ProcessName = "GetapprovalByID.Get" };
            using (var context = new COAApprovalContext())
            {
                try
                {
                    List<COA_Approval> contentData = context.COA_Approvals
                        .Where(x => x.id == id)
                        .ToList();

                    foreach (var item in contentData)
                    {
                        int dataint = Convert.ToInt32(item.surveyor_id);
                        item.name = context.user_accountss.Where(x => x.user_id == dataint).Select(a => a.username).FirstOrDefault();
                        item.email = context.user_accountss.Where(x => x.user_id == dataint).Select(a => a.email).FirstOrDefault();
                        item.createdBy = context.user_accountss.Where(x => x.user_id == dataint).Select(a => a.username).FirstOrDefault();
                    }

                    result.Data = contentData;

                    ProcessResult.Success(result);
                }
                catch (Exception ex)
                {
                    ProcessResult.Error(result, ex.InnerException);
                }
            }
            return result;
        }

        public ProcessResult<List<COA_Approval>> GetApprovalByPICID(int id)
        {
            ProcessResult<List<COA_Approval>> result = new ProcessResult<List<COA_Approval>>() { ProcessName = "GetapprovalByID.Get" };
            using (var context = new COAApprovalContext())
            {
                try
                {
                    List<COA_Approval> contentData = context.COA_Approvals
                        .Where(x => x.next_approver == id)
                        .ToList();

                    foreach (var item in contentData)
                    {
                        int dataint = Convert.ToInt32(item.surveyor_id);
                        item.name = context.user_accountss.Where(x => x.user_id == dataint).Select(a => a.username).FirstOrDefault();
                        item.email = context.user_accountss.Where(x => x.user_id == dataint).Select(a => a.email).FirstOrDefault();
                        item.createdBy = context.user_accountss.Where(x => x.user_id == dataint).Select(a => a.username).FirstOrDefault();
                    }

                    result.Data = contentData;

                    ProcessResult.Success(result);
                }
                catch (Exception ex)
                {
                    ProcessResult.Error(result, ex.InnerException);
                }
            }
            return result;
        }

        #endregion



        #region CRUD
        public ProcessResult<List<SurveyorInput>> Addapproval(SurveyorInput Input)
        {
            ProcessResult<List<SurveyorInput>> result = new ProcessResult<List<SurveyorInput>>() { ProcessName = "approval.Get" };
            using (var context = new COAApprovalContext())
            {
                try
                {

                    string NikApproval_1st, NikApproval_2nd, queryFinal = string.Empty;
                    int app1 = 0;
                    int app2 = 0;

                    NikApproval_1st = context.user_accountss.Where(x => x.user_id == Input.surveyor_id).Select(a => a.id_atasan).FirstOrDefault().ToString();
                    if (NikApproval_1st == "")
                    {
                        NikApproval_1st = "0";
                    }
                    else
                    {
                        app1 = Convert.ToInt32(NikApproval_1st);
                    }


                    NikApproval_2nd = context.user_accountss.Where(x => x.user_id == app1).Select(a => a.id_atasan).FirstOrDefault().ToString();
                    if (NikApproval_2nd == "")
                    {
                        NikApproval_2nd = "0";
                    }
                    else
                    {
                        app2 = Convert.ToInt32(NikApproval_2nd);
                    }

                    queryFinal = "insert into coa_approval (surveyor_id,date,coa_file,note,status,pic1_id,pic1_approval_status,pic1_note,pic2_id,pic2_approval_status,pic2_note, next_approver)" +
                        "values('"
                        + Input.surveyor_id + "','"
                        + DateTime.Now + "','"
                        + Input.coa_file + "','"
                        + Input.note + "','"
                        + "Submitted" + "','"
                        + app1 + "','"
                        + "" + "','"
                        + "" + "','"
                        + app2 + "','"
                        + "" + "','"
                        + "" + "','"
                        + app1 + "')";


                    context.Database.ExecuteSqlCommand(queryFinal);
                    ProcessResult.Success(result);
                }
                catch (Exception ex)
                {
                    ProcessResult.Error(result, ex.InnerException);
                }
            }
            return result;

        }

        public ProcessResult<List<ApprovalAtasan>> ApprovalAtasan(ApprovalAtasan Input)
        {
            ProcessResult<List<ApprovalAtasan>> result = new ProcessResult<List<ApprovalAtasan>>() { ProcessName = "approval.Get" };
            using (var context = new COAApprovalContext())
            {
                try
                {
                    string NikApproval_1st, NikApproval_2nd, queryFinal = string.Empty;
                    int app1 = 0;
                    int app2 = 0;

                    NikApproval_1st = context.COA_Approvals.Where(x => x.id == Input.id_coa_approval).Select(a => a.pic1_id).FirstOrDefault().ToString();
                    NikApproval_2nd = context.COA_Approvals.Where(x => x.id == Input.id_coa_approval).Select(a => a.pic2_id).FirstOrDefault().ToString();

                    if (NikApproval_1st == "")
                    {
                        NikApproval_1st = "0";
                    }
                    else
                    {
                        app1 = Convert.ToInt32(NikApproval_1st);
                    }

                    if (NikApproval_2nd == "")
                    {
                        NikApproval_2nd = "0";
                    }
                    else
                    {
                        app2 = Convert.ToInt32(NikApproval_2nd);
                    }

                    //approved
                    if (Input.pic_approval_status == "Approved")
                    {
                        // approver ada 2
                        if (NikApproval_2nd != "")
                        {
                            //ini kalo yang pertama kali
                            if (Input.user_id == Convert.ToInt32(NikApproval_1st))
                            {
                                queryFinal = "UPDATE public.coa_approval SET " +
                                "status=" + "'1st Approval'" + ","
                                + "pic1_approval_status='" + Input.pic_approval_status + "',"
                                + "pic1_note ='" + Input.pic1_note + "',"
                                + "next_approver ='" + NikApproval_2nd + "' "
                                + "WHERE id = " + Input.id_coa_approval;
                            }
                            //ini buat yang approver kedua
                            else
                            {
                                queryFinal = "UPDATE public.coa_approval SET " +
                                "status=" + "'Approved'" + ","
                                + "pic2_approval_status='" + Input.pic_approval_status + "',"
                                + "pic2_note ='" + Input.pic1_note + "' "
                                + "WHERE id = " + Input.id_coa_approval;
                            }

                        }
                        //approver 1 doang
                        else
                        {
                            queryFinal = "UPDATE public.coa_approval SET " +
                                "status=" + "'Approved'" + ","
                                + "pic1_approval_status= '" + Input.pic_approval_status + "',"
                                + "pic1_note ='" + Input.pic1_note + "' "
                                + "WHERE id = " + Input.id_coa_approval;
                        }
                    }
                    //rejected
                    else
                    {
                        queryFinal = "UPDATE public.coa_approval SET " +
                               "status=" + "'Rejected'" + ","
                               + "pic1_approval_status= '" + Input.pic_approval_status + "',"
                               + "pic1_note ='" + Input.pic1_note + "' "
                               + "WHERE id = " + Input.id_coa_approval;
                    }

                    context.Database.ExecuteSqlCommand(queryFinal);
                    ProcessResult.Success(result);
                }
                catch (Exception ex)
                {
                    ProcessResult.Error(result, ex.InnerException);
                }
            }
            return result;

        }

        //public ProcessResult<List<COA_Approval>> Updateapproval(COA_Approval Input)
        //{
        //    ProcessResult<List<COA_Approval>> result = new ProcessResult<List<COA_Approval>>() { ProcessName = "approval.Get" };
        //    using (var context = new COAApprovalContext())
        //    {
        //        try
        //        {
        //            //string query = "exec sp_approval_Update "
        //            //+ "'" + Input.Provider_ID + "',"
        //            //+ "'" + Input.Provider_Type + "',"
        //            //+ "'" + Input.Provider_Name + "',"
        //            //+ "'" + Input.Provider_Phone + "',"
        //            //+ "'" + Input.Provider_NPWP + "',"
        //            //+ "'" + Input.Provider_Address + "',"
        //            //+ "'" + Input.Provider_Contact_Person + "',"
        //            //+ "'" + Input.Provider_Contact_Person_Phone + "',"
        //            //+ "'" + Input.Provider_Email + "',"
        //            //+ "'" + Input.userid + "'"; //modified by

        //            //// delete dulu yang lama
        //            //string queryDelete = "exec sp_Training_Manfaat_Delete"
        //            //       + "'" + Input.Provider_ID + "','"
        //            //       + Input.userid + "'";
        //            //context.Database.ExecuteSqlCommand(queryDelete);

        //            //for (int i = 0; i < Input.kompetensiFormAdd.Count(); i++)
        //            //{
        //            //    if (!string.IsNullOrEmpty(Input.kompetensiFormAdd[i].Parameter_Kompetensi_ID))
        //            //    {
        //            //        string queryDetail = "exec sp_approval_Detail_Insert "
        //            //        + "'" + Input.Provider_ID + "',"
        //            //        + "'" + Input.kompetensiFormAdd[i].Parameter_Kompetensi_ID + "',"
        //            //        + "'" + Input.userid + "'";

        //            //        context.Database.ExecuteSqlCommand(queryDetail);
        //            //    }
        //            //}

        //            //context.Database.ExecuteSqlCommand(query);
        //            context.Database.ExecuteSqlCommand("Update QUery");

        //            ProcessResult.Success(result);
        //        }
        //        catch (Exception ex)
        //        {
        //            ProcessResult.Error(result, ex.InnerException);
        //        }
        //    }
        //    return result;

        //}

        //public ProcessResult<List<COA_Approval>> Deleteapproval(COA_Approval Input)
        //{
        //    ProcessResult<List<COA_Approval>> result = new ProcessResult<List<COA_Approval>>() { ProcessName = "approval.Get" };
        //    using (var context = new COAApprovalContext())
        //    {
        //        try
        //        {
        //            context.Database.ExecuteSqlCommand("Delete QUery");

        //            //context.Database.ExecuteSqlCommand(query);

        //            ProcessResult.Success(result);
        //        }
        //        catch (Exception ex)
        //        {
        //            ProcessResult.Error(result, ex.InnerException);
        //        }
        //    }
        //    return result;

        //}

        #endregion
    }
}
