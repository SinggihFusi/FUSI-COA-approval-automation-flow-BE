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
    public class UserRepo
    {
        #region Get
        public ProcessResult<List<user_accounts>> GetAlluser_accounts()
        {
            ProcessResult<List<user_accounts>> result = new ProcessResult<List<user_accounts>>() { ProcessName = "user_accounts.Get" };
            using (var context = new COAApprovalContext())
            {
                    try
                    {
                        List<user_accounts> contentData = context.user_accountss.ToList();
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

        public ProcessResult<List<user_accounts>> Getuser_accountsByID(int id)
        {
            ProcessResult<List<user_accounts>> result = new ProcessResult<List<user_accounts>>() { ProcessName = "Getuser_accountsByID.Get" };
            using (var context = new COAApprovalContext())
            {
                try
                {
                    List<user_accounts> contentData = context.user_accountss
                        .Where(x => x.user_id == id)
                        .ToList();

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

        public ProcessResult<List<user_accounts>> Getuser_accountsByUsername(string username)
        {
            ProcessResult<List<user_accounts>> result = new ProcessResult<List<user_accounts>>() { ProcessName = "Getuser_accountsByUsername.Get" };
            using (var context = new COAApprovalContext())
            {
                try
                {
                    List<user_accounts> contentData = context.user_accountss
                        .Where(x => x.username == username)
                        .ToList();

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

        public ProcessResult<List<user_accounts>> LoginCheck(user_login Input)
        {
            ProcessResult<List<user_accounts>> result = new ProcessResult<List<user_accounts>>() { ProcessName = "Getuser_accountsByUsername.Get" };
            using (var context = new COAApprovalContext())
            {
                try
                {
                    List<user_accounts> contentData = context.user_accountss
                        .Where(x => x.username == Input.username)
                        .Where(x => x.password == Input.password)
                        .ToList();

                    result.Data = contentData;

                    //if (contentData.Count == 1)
                    //{
                    //    return "True";
                    //}
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
        public ProcessResult<List<user_accounts>> Adduser_accounts(user_accounts Input)
        {
            ProcessResult<List<user_accounts>> result = new ProcessResult<List<user_accounts>>() { ProcessName = "user_accounts.Get" };
            using (var context = new COAApprovalContext())
            {
                try
                {
                    //string query = "exec sp_user_accounts_Insert "
                    //+ "'" + newID + "',"
                    //+ "'" + Input.Provider_Type + "',"
                    //+ "'" + Input.Provider_Name + "',"
                    //+ "'" + Input.Provider_Phone + "',"
                    //+ "'" + Input.Provider_NPWP + "',"
                    //+ "'" + Input.Provider_Address + "',"
                    //+ "'" + Input.Provider_Contact_Person + "',"
                    //+ "'" + Input.Provider_Contact_Person_Phone + "',"
                    //+ "'" + Input.Provider_Email + "',"
                    //+ "'" + Input.userid + "'";

                    //for (int i = 0; i < Input.kompetensiFormAdd.Count(); i++)
                    //{
                    //    if (!string.IsNullOrEmpty(Input.kompetensiFormAdd[i].Parameter_Kompetensi_ID))
                    //    {
                    //        string queryDetail = "exec sp_user_accounts_Detail_Insert "
                    //        + "'" + newID + "',"
                    //        + "'" + Input.kompetensiFormAdd[i].Parameter_Kompetensi_ID + "',"
                    //        + "'" + Input.userid + "'";

                    //        context.Database.ExecuteSqlCommand(queryDetail);
                    //    }
                    //}

                    //context.Database.ExecuteSqlCommand(query);
                    context.Database.ExecuteSqlCommand("insert query");
                    ProcessResult.Success(result);
                }
                catch (Exception ex)
                {
                    ProcessResult.Error(result, ex.InnerException);
                }
            }
            return result;

        }

        public ProcessResult<List<user_accounts>> Updateuser_accounts(user_accounts Input)
        {
            ProcessResult<List<user_accounts>> result = new ProcessResult<List<user_accounts>>() { ProcessName = "user_accounts.Get" };
            using (var context = new COAApprovalContext())
            {
                try
                {
                    //string query = "exec sp_user_accounts_Update "
                    //+ "'" + Input.Provider_ID + "',"
                    //+ "'" + Input.Provider_Type + "',"
                    //+ "'" + Input.Provider_Name + "',"
                    //+ "'" + Input.Provider_Phone + "',"
                    //+ "'" + Input.Provider_NPWP + "',"
                    //+ "'" + Input.Provider_Address + "',"
                    //+ "'" + Input.Provider_Contact_Person + "',"
                    //+ "'" + Input.Provider_Contact_Person_Phone + "',"
                    //+ "'" + Input.Provider_Email + "',"
                    //+ "'" + Input.userid + "'"; //modified by

                    //// delete dulu yang lama
                    //string queryDelete = "exec sp_Training_Manfaat_Delete"
                    //       + "'" + Input.Provider_ID + "','"
                    //       + Input.userid + "'";
                    //context.Database.ExecuteSqlCommand(queryDelete);

                    //for (int i = 0; i < Input.kompetensiFormAdd.Count(); i++)
                    //{
                    //    if (!string.IsNullOrEmpty(Input.kompetensiFormAdd[i].Parameter_Kompetensi_ID))
                    //    {
                    //        string queryDetail = "exec sp_user_accounts_Detail_Insert "
                    //        + "'" + Input.Provider_ID + "',"
                    //        + "'" + Input.kompetensiFormAdd[i].Parameter_Kompetensi_ID + "',"
                    //        + "'" + Input.userid + "'";

                    //        context.Database.ExecuteSqlCommand(queryDetail);
                    //    }
                    //}

                    //context.Database.ExecuteSqlCommand(query);
                    context.Database.ExecuteSqlCommand("Update QUery");

                    ProcessResult.Success(result);
                }
                catch (Exception ex)
                {
                    ProcessResult.Error(result, ex.InnerException);
                }
            }
            return result;

        }

        public ProcessResult<List<user_accounts>> Deleteuser_accounts(user_accounts Input)
        {
            ProcessResult<List<user_accounts>> result = new ProcessResult<List<user_accounts>>() { ProcessName = "user_accounts.Get" };
            using (var context = new COAApprovalContext())
            {
                try
                {
                    string query = "exec sp_user_accounts_Delete "
                    + "'" + Input.username + "',"
                    + "'" + Input.password + "'";

                    context.Database.ExecuteSqlCommand(query);

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
    }
}
