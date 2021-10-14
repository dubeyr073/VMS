﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IMS.Models.ViewModel
{
    public class CompanyMaster
    {
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int TypeId { get; set; }
        public int FinancialId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Ownership { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public int Createdby { get; set; }
        public int Loginid { get; set; }


        public CompanyMaster CompanyMaster_InsertUpdate(CompanyMaster companyMaster)
        {
            try
            {
                List<SqlParameter> SqlParameters = new List<SqlParameter>();
                SqlParameters.Add(new SqlParameter("@Company_Id", companyMaster.CompanyId));
                SqlParameters.Add(new SqlParameter("@Title", companyMaster.Title));
                SqlParameters.Add(new SqlParameter("@Code", companyMaster.Code));
                SqlParameters.Add(new SqlParameter("@Type_Id", companyMaster.TypeId));
                SqlParameters.Add(new SqlParameter("@Financial_Id", companyMaster.FinancialId));
                SqlParameters.Add(new SqlParameter("@Address1", companyMaster.Address1));
                SqlParameters.Add(new SqlParameter("@Address2", companyMaster.Address2));
                SqlParameters.Add(new SqlParameter("@Ownership", companyMaster.Ownership));
                SqlParameters.Add(new SqlParameter("@Remarks", companyMaster.Remarks));
                SqlParameters.Add(new SqlParameter("@Isactive", companyMaster.IsActive));
                SqlParameters.Add(new SqlParameter("@Loginid", companyMaster.Loginid));
                companyMaster.CompanyId = DBManager.ExecuteScalar("Company_Master_Insertupdate", CommandType.StoredProcedure, SqlParameters);
            }
            catch (Exception ex)
            { throw ex; }

            return companyMaster;
        }

        public List<CompanyMaster> CompanyMaster_Get(CompanyMaster companyMaster)
        {
            DataTable dt = new DataTable();
            List<CompanyMaster> lstcompanyMaster = new List<CompanyMaster>();
            try
            {
                dt = GetCompanyData(companyMaster);
                if (dt.Rows.Count > 0)
                    lstcompanyMaster = CommonUtility.ConvertToList<CompanyMaster>(dt);
            }
            catch (Exception ex)
            { throw ex; }
            return lstcompanyMaster;
        }

        public DataTable GetCompanyData(CompanyMaster companyMaster)
        {
            DataTable dt = new DataTable();
            try
            {
                List<SqlParameter> SqlParameters = new List<SqlParameter>();
                SqlParameters.Add(new SqlParameter("@Company_Id", companyMaster.CompanyId));
                SqlParameters.Add(new SqlParameter("@Title", companyMaster.Title));
                dt = DBManager.ExecuteDataTableWithParameter("Financial_Master_Getdata", CommandType.StoredProcedure,SqlParameters);
            }
            catch (Exception ex)
            { throw ex; }

            return dt;
        }

    }
}