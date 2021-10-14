﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IMS.Models.ViewModel
{
    public class FinancialMaster
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int FinancialId { get; set; }
        public bool IsActive { get; set; }
        public int Createdby { get; set; }
        public int Loginid { get; set; }


        public FinancialMaster FinancialMaster_InsertUpdate(FinancialMaster financialMaster)
        {
            try
            {
                List<SqlParameter> SqlParameters = new List<SqlParameter>();
                SqlParameters.Add(new SqlParameter("@Financial_id", financialMaster.FinancialId));
                SqlParameters.Add(new SqlParameter("@From_date", Convert.ToDateTime(financialMaster.FromDate)));
                SqlParameters.Add(new SqlParameter("@To_date", Convert.ToDateTime(financialMaster.ToDate)));
                SqlParameters.Add(new SqlParameter("@Isactive", financialMaster.IsActive));
                SqlParameters.Add(new SqlParameter("@Loginid", financialMaster.Loginid));
                financialMaster.FinancialId = DBManager.ExecuteScalar("Financial_Master_Insertupdate", CommandType.StoredProcedure, SqlParameters);
            }
            catch (Exception ex)
            { throw ex; }

            return financialMaster;
        }

        public List<FinancialMaster> FinancialMaster_Get()
        {
            DataTable dt = new DataTable();
            List<FinancialMaster> financialMaster = new List<FinancialMaster>();
            try
            {
                dt = GetFinancialData();
                if(dt.Rows.Count > 0)
                financialMaster = CommonUtility.ConvertToList<FinancialMaster>(dt);
            }
            catch (Exception ex)
            { throw ex; }
            return financialMaster;
        }

        public DataTable GetFinancialData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DBManager.ExecuteDataTable("Financial_Master_Getdata", CommandType.StoredProcedure);
            }
            catch (Exception ex)
            { throw ex; }

            return dt;
        }




    }
}