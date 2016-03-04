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
            string commandText = "SELECT DISTINCT * FROM CVPONL_OWNER.DRUG_PRODUCTS";

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


        public List<DrugProduct> GetDrugProductByDrugName(string drugName)
        {
            var items = new List<DrugProduct>();
            string commandText = "SELECT DISTINCT DRUG_PRODUCT_ID, PRODUCT_ID, DRUGNAME, CPD_FLAG FROM CVPONL_OWNER.DRUG_PRODUCTS WHERE UPPER(DRUGNAME) LIKE '%" + drugName.ToUpper() + "%' ORDER BY DRUGNAME ASC";

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

                                items.Add(item);

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetDrugProductByName()");
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


        public List<Report> GetAEReportByDrugName(string drugName)
        {
            var items = new List<Report>();
            string strDrugNames = "'" + drugName.Replace(",", "','") + "'";
            string commandText = " SELECT rp.* FROM REPORTS rp WHERE rp.REPORT_ID IN (SELECT DISTINCT r.REPORT_ID ";
            commandText += "from ADR_MV r, REPORT_DRUGS_MV rd, (SELECT DISTINCT report_id COL1 from REPORT_DRUGS_MV where UPPER(DRUGNAME) IN (SELECT DISTINCT dp.DRUGNAME FROM DRUG_PRODUCTS dp where dp.DRUGNAME IN (" + strDrugNames.ToUpper() + "))) TEMP1 ";
            commandText += "where r.datreceived BETWEEN TO_DATE('1965-01-01', 'YYYY/MM/DD') AND TO_DATE('2015-09-30', 'YYYY/MM/DD')and r.REPORT_ID = TEMP1.COL1 AND r.REPORT_ID = rd.REPORT_ID) ";
            commandText += "ORDER BY rp.report_id, rp.datreceived";

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

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetReportByDrugName()");
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


        public List<AEReport> GetAEExportReportByDrugName(string drugName)
        {
            var items = new List<AEReport>();
            string strDrugNames = "'" + drugName.Replace(",", "','") + "'";
            string commandText = "SELECT r.ADR_ID, r.REPORT_ID, r.REPORT_NO, r.VERSION_NO, r.DATRECEIVED, ";
            commandText += "r.DATINTRECEIVED, r.MAH_NO, r.REPORT_TYPE_ENG, r.REPORT_TYPE_FR, r.GENDER_ENG, ";
            commandText += "r.GENDER_FR, r.AGE, r.AGE_UNIT_ENG, r.AGE_UNIT_FR, r.AGE_GROUP_CODE, r.OUTCOME_ENG, r.OUTCOME_FR, r.WEIGHT, r.WEIGHT_UNIT_ENG, ";
            commandText += "r.WEIGHT_UNIT_FR, r.HEIGHT, r.HEIGHT_UNIT_ENG, r.HEIGHT_UNIT_FR, r.SERIOUSNESS_ENG, r.SERIOUSNESS_FR, r.DEATH, r.DISABILITY, ";
            commandText += "r.CONGENITAL_ANOMALY, r.LIFE_THREATENING, r.HOSP_REQUIRED, r.OTHER_MEDICALLY_IMP_COND, r.REPORTER_TYPE_ENG, r.REPORTER_TYPE_FR, ";
            commandText += "r.SOURCE_ENG, r.SOURCE_FR, r.REPORT_LINK_FLG, r.DURATION, r.DURATION_UNIT_ENG, r.DURATION_UNIT_FR, r.PT_NAME_ENG, ";
            commandText += "r.PT_NAME_FR, r.SOC_NAME_ENG, r.SOC_NAME_FR, r.MEDDRA_VERSION, rd.REPORT_DRUG_ID, rd.DRUGNAME, rd.DRUGINVOLV_ENG, rd.DRUGINVOLV_FR, ";
            commandText += "rd.ROUTEADMIN_ENG, rd.ROUTEADMIN_FR, rd.UNIT_DOSE_QTY, rd.DOSE_UNIT_ENG, rd.DOSE_UNIT_FR, rd.FREQUENCY, rd.FREQ_TIME_UNIT_ENG, ";
            commandText += "rd.FREQ_TIME_UNIT_FR, rd.THERAPY_DURATION, rd.THERAPY_DURATION_UNIT_ENG, rd.THERAPY_DURATION_UNIT_FR, ";
            commandText += "rd.DOSAGEFORM_ENG, rd.DOSAGEFORM_FR, rd.DRUG_PRODUCT_ID, rd.FREQ_TIME, rd.FREQUENCY_TIME_ENG, rd.FREQUENCY_TIME_FR, r.AGE_GROUP_ENG, r.AGE_GROUP_FR, ";
            commandText += "rl.REPORT_LINK, rl.RECORD_TYPE_ENG, rl.RECORD_TYPE_FR, rd.INDICATION_NAME_ENG, rd.INDICATION_NAME_FR ";
            commandText += "from ADR_MV r, REPORT_DRUG rd, REPORT_LINKS rl ";
            commandText += "where r.REPORT_ID = rd.REPORT_ID ";
            commandText += "and r.REPORT_ID = rl.REPORT_ID(+) ";
            commandText += "and r.REPORT_ID in ( ";
            commandText += "select DISTINCT r.REPORT_ID ";
            commandText += "from ADR_MV r, REPORT_DRUGS_MV rd, (SELECT DISTINCT report_id COL1 from REPORT_DRUGS_MV where UPPER(DRUGNAME) IN(SELECT DISTINCT dp.DRUGNAME FROM DRUG_PRODUCTS dp WHERE UPPER(dp.DRUGNAME) IN (" + strDrugNames.ToUpper() + "))) TEMP1 ";
            commandText += " WHERE r.datreceived BETWEEN TO_DATE('1965-01-01', 'YYYY/MM/DD') AND TO_DATE('2015-09-30', 'YYYY/MM/DD') AND r.REPORT_ID = TEMP1.COL1) ";
            commandText += "ORDER BY r.report_id, r.datreceived";

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
                                var item = new AEReport();

                                item.ReportNo = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
                                item.VersionNo = dr["VERSION_NO"] == DBNull.Value ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
                                item.MahNo = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
                                item.DateIntReceived = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
                                item.DateReceived = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
                                item.ReporterTypeEng = dr["REPORTER_TYPE_ENG"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_ENG"].ToString().Trim();
                                item.ReporterTypeFr = dr["REPORTER_TYPE_FR"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_FR"].ToString().Trim();
                                item.SeriousnessEng = dr["SERIOUSNESS_ENG"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_ENG"].ToString().Trim();
                                item.SeriousnessFr = dr["SERIOUSNESS_FR"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_FR"].ToString().Trim();
                                item.AgeGroupEng = dr["AGE_GROUP_ENG"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_ENG"].ToString().Trim();
                                item.AgeGroupFr = dr["AGE_GROUP_FR"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_FR"].ToString().Trim();
                                item.Age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
                                item.AgeUnitEng = dr["AGE_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_ENG"].ToString().Trim();
                                item.AgeUnitFr = dr["AGE_UNIT_FR"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_FR"].ToString().Trim();
                                item.GenderEng = dr["GENDER_ENG"] == DBNull.Value ? string.Empty : dr["GENDER_ENG"].ToString().Trim();
                                item.GenderFr = dr["GENDER_FR"] == DBNull.Value ? string.Empty : dr["GENDER_FR"].ToString().Trim();
                                item.Weight = dr["WEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["WEIGHT"]);
                                item.WeightUnitEng = dr["WEIGHT_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_ENG"].ToString().Trim();
                                item.WeightUnitFr = dr["WEIGHT_UNIT_FR"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_FR"].ToString().Trim();
                                item.Height = dr["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["HEIGHT"]);
                                item.HeightUnitEng = dr["HEIGHT_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_ENG"].ToString().Trim();
                                item.HeightUnitFr = dr["HEIGHT_UNIT_FR"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_FR"].ToString().Trim();
                                item.OutcomeEng = dr["OUTCOME_ENG"] == DBNull.Value ? string.Empty : dr["OUTCOME_ENG"].ToString().Trim();
                                item.OutcomeFr = dr["OUTCOME_FR"] == DBNull.Value ? string.Empty : dr["OUTCOME_FR"].ToString().Trim();
                                item.ReporterTypeEng = dr["REPORTER_TYPE_ENG"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_ENG"].ToString().Trim();
                                item.ReporterTypeFr = dr["REPORTER_TYPE_FR"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_FR"].ToString().Trim();
                                item.SourceEng = dr["SOURCE_ENG"] == DBNull.Value ? string.Empty : dr["SOURCE_ENG"].ToString().Trim();
                                item.SourceFr = dr["SOURCE_FR"] == DBNull.Value ? string.Empty : dr["SOURCE_FR"].ToString().Trim();
                                item.Death = dr["DEATH"] == DBNull.Value ? string.Empty : dr["DEATH"].ToString().Trim();
                                item.Disability = dr["DISABILITY"] == DBNull.Value ? string.Empty : dr["DISABILITY"].ToString().Trim();
                                item.CongenitalAnomaly = dr["CONGENITAL_ANOMALY"] == DBNull.Value ? string.Empty : dr["CONGENITAL_ANOMALY"].ToString().Trim();
                                item.LifeThreatening = dr["LIFE_THREATENING"] == DBNull.Value ? string.Empty : dr["LIFE_THREATENING"].ToString().Trim();
                                item.HospRequired = dr["HOSP_REQUIRED"] == DBNull.Value ? string.Empty : dr["HOSP_REQUIRED"].ToString().Trim();
                                item.OtherMedicallyImpCond = dr["OTHER_MEDICALLY_IMP_COND"] == DBNull.Value ? string.Empty : dr["OTHER_MEDICALLY_IMP_COND"].ToString().Trim();
                                item.DrugName = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.DosageFormEng = dr["DOSAGEFORM_ENG"] == DBNull.Value ? string.Empty : dr["DOSAGEFORM_ENG"].ToString().Trim();
                                item.DosageFormFr = dr["DOSAGEFORM_FR"] == DBNull.Value ? string.Empty : dr["DOSAGEFORM_FR"].ToString().Trim();
                                item.DrugInvolvEng = dr["DRUGINVOLV_ENG"] == DBNull.Value ? string.Empty : dr["DRUGINVOLV_ENG"].ToString().Trim();
                                item.DrugInvolvFr = dr["DRUGINVOLV_FR"] == DBNull.Value ? string.Empty : dr["DRUGINVOLV_FR"].ToString().Trim();
                                item.RouteAdminEng = dr["ROUTEADMIN_ENG"] == DBNull.Value ? string.Empty : dr["ROUTEADMIN_ENG"].ToString().Trim();
                                item.RouteAdminFr = dr["ROUTEADMIN_FR"] == DBNull.Value ? string.Empty : dr["ROUTEADMIN_FR"].ToString().Trim();
                                item.UnitDoseQty = dr["UNIT_DOSE_QTY"] == DBNull.Value ? string.Empty : dr["UNIT_DOSE_QTY"].ToString().Trim();
                                item.DoseUnitEng = dr["DOSE_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["DOSE_UNIT_ENG"].ToString().Trim();
                                item.DoseUnitFr = dr["DOSE_UNIT_FR"] == DBNull.Value ? string.Empty : dr["DOSE_UNIT_FR"].ToString().Trim();
                                item.FrequencyTimeEng = dr["FREQUENCY_TIME_ENG"] == DBNull.Value ? string.Empty : dr["FREQUENCY_TIME_ENG"].ToString().Trim();
                                item.FrequencyTimeFr = dr["FREQUENCY_TIME_FR"] == DBNull.Value ? string.Empty : dr["FREQUENCY_TIME_FR"].ToString().Trim();
                                item.TherapyDuration = dr["THERAPY_DURATION"] == DBNull.Value ? string.Empty : dr["THERAPY_DURATION"].ToString().Trim();
                                item.TherapyDurationUnitEng = dr["THERAPY_DURATION_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["THERAPY_DURATION_UNIT_ENG"].ToString().Trim();
                                item.TherapyDurationUnitFr = dr["THERAPY_DURATION_UNIT_FR"] == DBNull.Value ? string.Empty : dr["THERAPY_DURATION_UNIT_FR"].ToString().Trim();
                                item.PtNameEng = dr["PT_NAME_ENG"] == DBNull.Value ? string.Empty : dr["PT_NAME_ENG"].ToString().Trim();
                                item.PtNameFr = dr["PT_NAME_FR"] == DBNull.Value ? string.Empty : dr["PT_NAME_FR"].ToString().Trim();
                                item.SocNameEng = dr["SOC_NAME_ENG"] == DBNull.Value ? string.Empty : dr["SOC_NAME_ENG"].ToString().Trim();
                                item.SocNameFr = dr["SOC_NAME_FR"] == DBNull.Value ? string.Empty : dr["SOC_NAME_FR"].ToString().Trim();
                                item.Duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
                                item.DurationUnitEng = dr["DURATION_UNIT_ENG"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT_ENG"].ToString().Trim();
                                item.DurationUnitFr = dr["DURATION_UNIT_FR"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT_FR"].ToString().Trim();
                                item.MeddraVersion = dr["MEDDRA_VERSION"] == DBNull.Value ? string.Empty : dr["MEDDRA_VERSION"].ToString().Trim();
                                item.RecordTypeEng = dr["RECORD_TYPE_ENG"] == DBNull.Value ? string.Empty : dr["RECORD_TYPE_ENG"].ToString().Trim();
                                item.ReportLinkFlg = dr["REPORT_LINK_FLG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_LINK_FLG"]);

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetReportByDrugName()");
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
        public List<Report> GetReportByDrugName(string drugName)
        {
            var items = new List<Report>();
            string commandText = "SELECT * FROM CVPONL_OWNER.REPORTS WHERE UPPER(DRUGNAME) IN ('" + drugName.ToUpper() + "')";

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

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetReportByDrugName()");
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

        public List<ReportInfo> GetReportInfoByDrugName(string drugName)
        {
            var items = new List<ReportInfo>();

            string strDrugNames = "'" + drugName.Replace(",", "','") + "'";

            string commandText = "SELECT REPORT_ID, REPORT_NO, DATRECEIVED, DATINTRECEIVED, MAH_NO, GENDER_ENG, GENDER_FR,";
            commandText += "AGE, AGE_UNIT_ENG, AGE_UNIT_FR, PT_NAME_ENG, PT_NAME_FR, SOC_NAME_ENG, SOC_NAME_FR, DRUGNAME FROM CVPONL_OWNER.REPORTS WHERE UPPER(DRUGNAME) IN (" + strDrugNames.ToUpper() + ")";

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

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetReportByDrugName()");
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

    }

}
