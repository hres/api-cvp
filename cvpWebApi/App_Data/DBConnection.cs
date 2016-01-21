using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
//using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using cvpWebApi.Models;
using System.Data.Odbc;
using Oracle.ManagedDataAccess.Client;
namespace cvp
{
    public class DBConnection
    {

        private string _lang;
        public string Lang
        {
            get { return this._lang; }
            set { this._lang = value; }
        }

        public DBConnection(string lang)
        {
            this._lang = lang;
        }

        private string DpdDBConnection
        {
            get { return ConfigurationManager.ConnectionStrings["cvp"].ToString(); }
        }


        public List<DrugProduct> GetAllDrugProduct()
        {
            var items = new List<DrugProduct>();
            string commandText = "SELECT * FROM CVPONL_OWNER.DRUG_PRODUCTS";

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new DrugProduct();
                                item.DrugProductId = dr["DRUG_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_ID"]);
                                item.ProductId = dr["PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PRODUCT_ID"]);
                                item.DrugName = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.CpdFlag = dr["CPD_FLAG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CPD_FLAG"]);

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllDrugProducts()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public DrugProduct GetDrugProductById(int id)
        {
            var drugProduct = new DrugProduct();
            string commandText = "SELECT * FROM CVPONL_OWNER.DRUG_PRODUCTS WHERE DRUG_PRODUCT_ID = " + id;

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
            using (

                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new DrugProduct();
                                item.DrugProductId = dr["DRUG_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_ID"]);
                                item.ProductId = dr["PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PRODUCT_ID"]);
                                item.DrugName = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.CpdFlag = dr["CPD_FLAG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CPD_FLAG"]);

                                drugProduct = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetDrugProductById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return drugProduct;
        }


        public List<DrugProductIngredient> GetAllDrugProductIngredient()
        {
            var items = new List<DrugProductIngredient>();
            string commandText = "SELECT * FROM CVPONL_OWNER.DRUG_PRODUCT_INGREDIENTS";

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new DrugProductIngredient();
                                item.DrugProductIngredientId = dr["DRUG_PRODUCT_INGREDIENT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_INGREDIENT_ID"]);
                                item.DrugProductId = dr["DRUG_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_ID"]);
                                item.ProductId = dr["PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PRODUCT_ID"]);
                                item.ActiveIngredientId = dr["ACTIVE_INGREDIENT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ACTIVE_INGREDIENT_ID"]);
                                item.DrugName = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.ActiveIngredientName = dr["ACTIVE_INGREDIENT_NAME"] == DBNull.Value ? string.Empty : dr["ACTIVE_INGREDIENT_NAME"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllDrugProductIngredients()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public DrugProductIngredient GetDrugProductIngredientById(int id)
        {
            var drugProductIngredient = new DrugProductIngredient();
            string commandText = "SELECT * FROM CVPONL_OWNER.DRUG_PRODUCT_INGREDIENTS WHERE DRUG_PRODUCT_INGREDIENT_ID = " + id;

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
            using (

                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new DrugProductIngredient();
                                item.DrugProductIngredientId = dr["DRUG_PRODUCT_INGREDIENT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_INGREDIENT_ID"]);
                                item.DrugProductId = dr["DRUG_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_ID"]);
                                item.ProductId = dr["PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PRODUCT_ID"]);
                                item.ActiveIngredientId = dr["ACTIVE_INGREDIENT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ACTIVE_INGREDIENT_ID"]);
                                item.DrugName = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.ActiveIngredientName = dr["ACTIVE_INGREDIENT_NAME"] == DBNull.Value ? string.Empty : dr["ACTIVE_INGREDIENT_NAME"].ToString().Trim();

                                drugProductIngredient = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetDrugProductIngredientById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return drugProductIngredient;
        }


        public List<Report> GetAllReport()
        {
            var items = new List<Report>();
            string commandText = "SELECT * FROM CVPONL_OWNER.REPORTS";

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Report();
                                item.ReportId = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.ReportNo = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
                                item.VersionNo = dr["VERSION_NO"] == DBNull.Value ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
                                item.DateReceived = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
                                item.DateIntReceived = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
                                item.MahNo = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
                                item.ReportTypeCode = dr["REPORT_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_CODE"].ToString().Trim();
                                item.ReportTypeEng = dr["REPORT_TYPE_ENG"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_ENG"].ToString().Trim();
                                item.ReportTypeFr = dr["REPORT_TYPE_FR"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_FR"].ToString().Trim();
                                item.GenderCode = dr["GENDER_CODE"] == DBNull.Value ? string.Empty : dr["GENDER_CODE"].ToString().Trim();
                                item.GenderEng = dr["GENDER_ENG"] == DBNull.Value ? string.Empty : dr["GENDER_ENG"].ToString().Trim();
                                item.GenderFr = dr["GENDER_FR"] == DBNull.Value ? string.Empty : dr["GENDER_FR"].ToString().Trim();
                                item.Age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
                                item.AgeY = dr["AGE_Y"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE_Y"]);
                                item.AgeUnitCode = dr["AGE_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_CODE"].ToString().Trim();
                                item.AgeUnitEng = dr["AGE_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_ENG"].ToString().Trim();
                                item.AgeUnitFr = dr["AGE_UNIT_FR"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_FR"].ToString().Trim();
                                item.AgeGroupCode = dr["AGE_GROUP_CODE"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_CODE"].ToString().Trim();
                                item.AgeGroupEng = dr["AGE_GROUP_ENG"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_ENG"].ToString().Trim();
                                item.AgeGroupFr = dr["AGE_GROUP_FR"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_FR"].ToString().Trim();
                                item.OutcomeCode = dr["OUTCOME_CODE"] == DBNull.Value ? string.Empty : dr["OUTCOME_CODE"].ToString().Trim();
                                item.OutcomeEng = dr["OUTCOME_ENG"] == DBNull.Value ? string.Empty : dr["OUTCOME_ENG"].ToString().Trim();
                                item.OutcomeFr = dr["OUTCOME_FR"] == DBNull.Value ? string.Empty : dr["OUTCOME_FR"].ToString().Trim();
                                item.Weight = dr["WEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["WEIGHT"]);
                                item.WeightUnitCode = dr["WEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_CODE"].ToString().Trim();
                                item.WeightUnitEng = dr["WEIGHT_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_ENG"].ToString().Trim();
                                item.WeightUnitFr = dr["WEIGHT_UNIT_FR"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_FR"].ToString().Trim();
                                item.Height = dr["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["HEIGHT"]);
                                item.HeightUnitCode = dr["HEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_CODE"].ToString().Trim();
                                item.HeightUnitEng = dr["HEIGHT_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_ENG"].ToString().Trim();
                                item.HeightUnitFr = dr["HEIGHT_UNIT_FR"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_FR"].ToString().Trim();
                                item.SeriousnessCode = dr["SERIOUSNESS_CODE"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_CODE"].ToString().Trim();
                                item.SeriousnessEng = dr["SERIOUSNESS_ENG"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_ENG"].ToString().Trim();
                                item.SeriousnessFr = dr["SERIOUSNESS_FR"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_FR"].ToString().Trim();
                                item.Death = dr["DEATH"] == DBNull.Value ? string.Empty : dr["DEATH"].ToString().Trim();
                                item.Disability = dr["DISABILITY"] == DBNull.Value ? string.Empty : dr["DISABILITY"].ToString().Trim();
                                item.CongenitalAnomaly = dr["CONGENITAL_ANOMALY"] == DBNull.Value ? string.Empty : dr["CONGENITAL_ANOMALY"].ToString().Trim();
                                item.LifeThreatening = dr["LIFE_THREATENING"] == DBNull.Value ? string.Empty : dr["LIFE_THREATENING"].ToString().Trim();
                                item.HospRequired = dr["HOSP_REQUIRED"] == DBNull.Value ? string.Empty : dr["HOSP_REQUIRED"].ToString().Trim();
                                item.OtherMedicallyImpCond = dr["OTHER_MEDICALLY_IMP_COND"] == DBNull.Value ? string.Empty : dr["OTHER_MEDICALLY_IMP_COND"].ToString().Trim();
                                item.ReporterTypeCode = dr["REPORTER_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_CODE"].ToString().Trim();
                                item.ReporterTypeEng = dr["REPORTER_TYPE_ENG"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_ENG"].ToString().Trim();
                                item.ReporterTypeFr = dr["REPORTER_TYPE_FR"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_FR"].ToString().Trim();
                                item.SourceCode = dr["SOURCE_CODE"] == DBNull.Value ? string.Empty : dr["SOURCE_CODE"].ToString().Trim();
                                item.SourceEng = dr["SOURCE_ENG"] == DBNull.Value ? string.Empty : dr["SOURCE_ENG"].ToString().Trim();
                                item.SourceFr = dr["SOURCE_FR"] == DBNull.Value ? string.Empty : dr["SOURCE_FR"].ToString().Trim();
                                item.ReportLinkFlg = dr["REPORT_LINK_FLG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_LINK_FLG"]);
                                item.AerId = dr["AER_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["AER_ID"]);
                                item.PtNameEng = dr["PT_NAME_ENG"] == DBNull.Value ? string.Empty : dr["PT_NAME_ENG"].ToString().Trim();
                                item.PtNameFr = dr["PT_NAME_FR"] == DBNull.Value ? string.Empty : dr["PT_NAME_FR"].ToString().Trim();
                                item.SocNameEng = dr["SOC_NAME_ENG"] == DBNull.Value ? string.Empty : dr["SOC_NAME_ENG"].ToString().Trim();
                                item.SocNameFr = dr["SOC_NAME_FR"] == DBNull.Value ? string.Empty : dr["SOC_NAME_FR"].ToString().Trim();
                                item.Duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
                                item.DurationUnitEng = dr["DURATION_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT_ENG"].ToString().Trim();
                                item.DurationUnitFr = dr["DURATION_UNIT_FR"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT_FR"].ToString().Trim();
                                item.DrugName = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                    
                                    items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllReport()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public Report GetReportById(int id)
        {
            var report = new Report();
            string commandText = "SELECT * FROM CVPONL_OWNER.REPORTS WHERE REPORT_ID = " + id;

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
            using (

                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Report();
                                item.ReportId = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.ReportNo = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
                                item.VersionNo = dr["VERSION_NO"] == DBNull.Value ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
                                item.DateReceived = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
                                item.DateIntReceived = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
                                item.MahNo = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
                                item.ReportTypeCode = dr["REPORT_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_CODE"].ToString().Trim();
                                item.ReportTypeEng = dr["REPORT_TYPE_ENG"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_ENG"].ToString().Trim();
                                item.ReportTypeFr = dr["REPORT_TYPE_FR"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_FR"].ToString().Trim();
                                item.GenderCode = dr["GENDER_CODE"] == DBNull.Value ? string.Empty : dr["GENDER_CODE"].ToString().Trim();
                                item.GenderEng = dr["GENDER_ENG"] == DBNull.Value ? string.Empty : dr["GENDER_ENG"].ToString().Trim();
                                item.GenderFr = dr["GENDER_FR"] == DBNull.Value ? string.Empty : dr["GENDER_FR"].ToString().Trim();
                                item.Age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
                                item.AgeY = dr["AGE_Y"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE_Y"]);
                                item.AgeUnitCode = dr["AGE_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_CODE"].ToString().Trim();
                                item.AgeUnitEng = dr["AGE_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_ENG"].ToString().Trim();
                                item.AgeUnitFr = dr["AGE_UNIT_FR"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_FR"].ToString().Trim();
                                item.AgeGroupCode = dr["AGE_GROUP_CODE"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_CODE"].ToString().Trim();
                                item.AgeGroupEng = dr["AGE_GROUP_ENG"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_ENG"].ToString().Trim();
                                item.AgeGroupFr = dr["AGE_GROUP_FR"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_FR"].ToString().Trim();
                                item.OutcomeCode = dr["OUTCOME_CODE"] == DBNull.Value ? string.Empty : dr["OUTCOME_CODE"].ToString().Trim();
                                item.OutcomeEng = dr["OUTCOME_ENG"] == DBNull.Value ? string.Empty : dr["OUTCOME_ENG"].ToString().Trim();
                                item.OutcomeFr = dr["OUTCOME_FR"] == DBNull.Value ? string.Empty : dr["OUTCOME_FR"].ToString().Trim();
                                item.Weight = dr["WEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["WEIGHT"]);
                                item.WeightUnitCode = dr["WEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_CODE"].ToString().Trim();
                                item.WeightUnitEng = dr["WEIGHT_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_ENG"].ToString().Trim();
                                item.WeightUnitFr = dr["WEIGHT_UNIT_FR"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_FR"].ToString().Trim();
                                item.Height = dr["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["HEIGHT"]);
                                item.HeightUnitCode = dr["HEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_CODE"].ToString().Trim();
                                item.HeightUnitEng = dr["HEIGHT_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_ENG"].ToString().Trim();
                                item.HeightUnitFr = dr["HEIGHT_UNIT_FR"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_FR"].ToString().Trim();
                                item.SeriousnessCode = dr["SERIOUSNESS_CODE"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_CODE"].ToString().Trim();
                                item.SeriousnessEng = dr["SERIOUSNESS_ENG"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_ENG"].ToString().Trim();
                                item.SeriousnessFr = dr["SERIOUSNESS_FR"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_FR"].ToString().Trim();
                                item.Death = dr["DEATH"] == DBNull.Value ? string.Empty : dr["DEATH"].ToString().Trim();
                                item.Disability = dr["DISABILITY"] == DBNull.Value ? string.Empty : dr["DISABILITY"].ToString().Trim();
                                item.CongenitalAnomaly = dr["CONGENITAL_ANOMALY"] == DBNull.Value ? string.Empty : dr["CONGENITAL_ANOMALY"].ToString().Trim();
                                item.LifeThreatening = dr["LIFE_THREATENING"] == DBNull.Value ? string.Empty : dr["LIFE_THREATENING"].ToString().Trim();
                                item.HospRequired = dr["HOSP_REQUIRED"] == DBNull.Value ? string.Empty : dr["HOSP_REQUIRED"].ToString().Trim();
                                item.OtherMedicallyImpCond = dr["OTHER_MEDICALLY_IMP_COND"] == DBNull.Value ? string.Empty : dr["OTHER_MEDICALLY_IMP_COND"].ToString().Trim();
                                item.ReporterTypeCode = dr["REPORTER_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_CODE"].ToString().Trim();
                                item.ReporterTypeEng = dr["REPORTER_TYPE_ENG"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_ENG"].ToString().Trim();
                                item.ReporterTypeFr = dr["REPORTER_TYPE_FR"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_FR"].ToString().Trim();
                                item.SourceCode = dr["SOURCE_CODE"] == DBNull.Value ? string.Empty : dr["SOURCE_CODE"].ToString().Trim();
                                item.SourceEng = dr["SOURCE_ENG"] == DBNull.Value ? string.Empty : dr["SOURCE_ENG"].ToString().Trim();
                                item.SourceFr = dr["SOURCE_FR"] == DBNull.Value ? string.Empty : dr["SOURCE_FR"].ToString().Trim();
                                item.ReportLinkFlg = dr["REPORT_LINK_FLG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_LINK_FLG"]);
                                item.AerId = dr["AER_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["AER_ID"]);
                                item.PtNameEng = dr["PT_NAME_ENG"] == DBNull.Value ? string.Empty : dr["PT_NAME_ENG"].ToString().Trim();
                                item.PtNameFr = dr["PT_NAME_FR"] == DBNull.Value ? string.Empty : dr["PT_NAME_FR"].ToString().Trim();
                                item.SocNameEng = dr["SOC_NAME_ENG"] == DBNull.Value ? string.Empty : dr["SOC_NAME_ENG"].ToString().Trim();
                                item.SocNameFr = dr["SOC_NAME_FR"] == DBNull.Value ? string.Empty : dr["SOC_NAME_FR"].ToString().Trim();
                                item.Duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
                                item.DurationUnitEng = dr["DURATION_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT_ENG"].ToString().Trim();
                                item.DurationUnitFr = dr["DURATION_UNIT_FR"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT_FR"].ToString().Trim();
                                item.DrugName = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                 
                                report = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetReportById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }


            return report;
        }

        public List<ReportInfo> GetAllReportInfo()
        {
            var items = new List<ReportInfo>();
            string commandText = "SELECT REPORT_ID, REPORT_NO, DATRECEIVED, DATINTRECEIVED, MAH_NO, GENDER_ENG, GENDER_FR,";
            commandText += "AGE, AGE_UNIT_ENG, AGE_UNIT_FR, PT_NAME_ENG, PT_NAME_FR, SOC_NAME_ENG, SOC_NAME_FR, DRUGNAME FROM CVPONL_OWNER.REPORTS";

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new ReportInfo();
                                item.ReportId = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.ReportNo = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
                                item.DateReceived = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
                                item.DateIntReceived = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
                                item.MahNo = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
                                item.GenderEng = dr["GENDER_ENG"] == DBNull.Value ? string.Empty : dr["GENDER_ENG"].ToString().Trim();
                                item.GenderFr = dr["GENDER_FR"] == DBNull.Value ? string.Empty : dr["GENDER_FR"].ToString().Trim();
                                item.Age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
                                item.AgeUnitEng = dr["AGE_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_ENG"].ToString().Trim();
                                item.AgeUnitFr = dr["AGE_UNIT_FR"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_FR"].ToString().Trim();
                                item.PtNameEng = dr["PT_NAME_ENG"] == DBNull.Value ? string.Empty : dr["PT_NAME_ENG"].ToString().Trim();
                                item.PtNameFr = dr["PT_NAME_FR"] == DBNull.Value ? string.Empty : dr["PT_NAME_FR"].ToString().Trim();
                                item.SocNameEng = dr["SOC_NAME_ENG"] == DBNull.Value ? string.Empty : dr["SOC_NAME_ENG"].ToString().Trim();
                                item.SocNameFr = dr["SOC_NAME_FR"] == DBNull.Value ? string.Empty : dr["SOC_NAME_FR"].ToString().Trim();
                                item.DrugName = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllReport()");
                    ExceptionHelper.LogException(ex, errorMessages);

                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return items;
        }

        public ReportInfo GetReportInfoById(int id)
        {
            var report = new ReportInfo();
            string commandText = "SELECT REPORT_ID, REPORT_NO, DATRECEIVED, DATINTRECEIVED, MAH_NO, GENDER_ENG, GENDER_FR,";
            commandText += "AGE, AGE_UNIT_ENG, AGE_UNIT_FR, PT_NAME_ENG, PT_NAME_FR, SOC_NAME_ENG, SOC_NAME_FR, DRUGNAME FROM CVPONL_OWNER.REPORTS WHERE REPORT_ID = " + id; 

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
            using (

                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new ReportInfo();
                                item.ReportId = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.ReportNo = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
                                item.DateReceived = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
                                item.DateIntReceived = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
                                item.MahNo = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
                                item.GenderEng = dr["GENDER_ENG"] == DBNull.Value ? string.Empty : dr["GENDER_ENG"].ToString().Trim();
                                item.GenderFr = dr["GENDER_FR"] == DBNull.Value ? string.Empty : dr["GENDER_FR"].ToString().Trim();
                                item.Age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
                                item.AgeUnitEng = dr["AGE_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_ENG"].ToString().Trim();
                                item.AgeUnitFr = dr["AGE_UNIT_FR"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_FR"].ToString().Trim();
                                item.PtNameEng = dr["PT_NAME_ENG"] == DBNull.Value ? string.Empty : dr["PT_NAME_ENG"].ToString().Trim();
                                item.PtNameFr = dr["PT_NAME_FR"] == DBNull.Value ? string.Empty : dr["PT_NAME_FR"].ToString().Trim();
                                item.SocNameEng = dr["SOC_NAME_ENG"] == DBNull.Value ? string.Empty : dr["SOC_NAME_ENG"].ToString().Trim();
                                item.SocNameFr = dr["SOC_NAME_FR"] == DBNull.Value ? string.Empty : dr["SOC_NAME_FR"].ToString().Trim();
                                item.DrugName = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();

                                report = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetReportById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return report;
        }

    }

}
