using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
//using System.Data.SqlClient;
using System.Configuration;
using cvpWebApi.Models;
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


        // used by API
        public List<DrugProduct> GetAllDrugProduct(string lang)
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
                                item.drug_product_id = dr["DRUG_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_ID"]);
                                item.product_id = dr["PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PRODUCT_ID"]);
                                item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.cpd_flag = dr["CPD_FLAG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CPD_FLAG"]);

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

        // used by API
        public DrugProduct GetDrugProductById(int id, string lang)
        {
            var drugProduct = new DrugProduct();
            string commandText = "SELECT * FROM CVPONL_OWNER.DRUG_PRODUCTS WHERE DRUG_PRODUCT_ID = :id ";

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
            using (

                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":id", id);
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
                                item.drug_product_id = dr["DRUG_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_ID"]);
                                item.product_id = dr["PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PRODUCT_ID"]);
                                item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.cpd_flag = dr["CPD_FLAG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CPD_FLAG"]);

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




        //used by API
        public List<DrugProductIngredient> GetAllDrugProductIngredient(string lang)
        {
            var items = new List<DrugProductIngredient>();
            string commandText = "SELECT * FROM CVPONL_OWNER.DRUG_PRODUCT_INGREDIENTS";

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
                                item.drug_product_ingredient_id = dr["DRUG_PRODUCT_INGREDIENT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_INGREDIENT_ID"]);
                                item.drug_product_id = dr["DRUG_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_ID"]);
                                item.product_id = dr["PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PRODUCT_ID"]);
                                item.active_ingredient_id = dr["ACTIVE_INGREDIENT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ACTIVE_INGREDIENT_ID"]);
                                item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.active_ingredient_name = dr["ACTIVE_INGREDIENT_NAME"] == DBNull.Value ? string.Empty : dr["ACTIVE_INGREDIENT_NAME"].ToString().Trim();

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

        // used by API
        public DrugProductIngredient GetDrugProductIngredientById(int id, string lang)
        {
            var drugProductIngredient = new DrugProductIngredient();
            string commandText = "SELECT * FROM CVPONL_OWNER.DRUG_PRODUCT_INGREDIENTS WHERE DRUG_PRODUCT_INGREDIENT_ID = :id ";

            //using (SqlConnection con = new SqlConnection(DpdDBConnection))
            using (

                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":id", id);
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
                                item.drug_product_ingredient_id = dr["DRUG_PRODUCT_INGREDIENT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_INGREDIENT_ID"]);
                                item.drug_product_id = dr["DRUG_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_ID"]);
                                item.product_id = dr["PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PRODUCT_ID"]);
                                item.active_ingredient_id = dr["ACTIVE_INGREDIENT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ACTIVE_INGREDIENT_ID"]);
                                item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.active_ingredient_name = dr["ACTIVE_INGREDIENT_NAME"] == DBNull.Value ? string.Empty : dr["ACTIVE_INGREDIENT_NAME"].ToString().Trim();

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


        // used by API
        public List<Report> GetAllReport(string lang)
        {
            var items = new List<Report>();
            string commandText = "SELECT REPORT_ID, REPORT_NO, VERSION_NO, DATRECEIVED, DATINTRECEIVED, MAH_NO, REPORT_TYPE_CODE, GENDER_CODE, ";
            commandText += " AGE, AGE_Y, AGE_UNIT_CODE, AGE_UNIT_CODE, AGE_GROUP_CODE, OUTCOME_CODE, WEIGHT, WEIGHT_UNIT_CODE, HEIGHT, HEIGHT_UNIT_CODE, ";
            commandText += " SERIOUSNESS_CODE, DEATH, DISABILITY, CONGENITAL_ANOMALY,LIFE_THREATENING, HOSP_REQUIRED, OTHER_MEDICALLY_IMP_COND, DURATION, ";
            commandText += " REPORTER_TYPE_CODE, SOURCE_CODE, REPORT_LINK_FLG, AER_ID, DRUGNAME, ";

            if (lang.Equals("fr"))
            {
                commandText += " REPORT_TYPE_FR as REPORT_TYPE, GENDER_FR as GENDER, AGE_UNIT_FR as AGE_UNIT, AGE_GROUP_FR as AGE_GROUP, ";
                commandText += " OUTCOME_FR as OUTCOME, WEIGHT_UNIT_FR as WEIGHT_UNIT, HEIGHT_UNIT_FR as HEIGHT_UNIT, SERIOUSNESS_FR as SERIOUSNESS, ";
                commandText += " REPORTER_TYPE_FR as REPORTER_TYPE, SOURCE_FR as SOURCE, PT_NAME_FR as PT_NAME, SOC_NAME_FR as SOC_NAME, DURATION_UNIT_FR as DURATION_UNIT";
            }
            else {
                commandText += " REPORT_TYPE_ENG as REPORT_TYPE, GENDER_ENG as GENDER, AGE_UNIT_ENG as AGE_UNIT, AGE_GROUP_ENG as AGE_GROUP, ";
                commandText += " OUTCOME_ENG as OUTCOME, WEIGHT_UNIT_ENG as WEIGHT_UNIT, HEIGHT_UNIT_ENG as HEIGHT_UNIT, SERIOUSNESS_ENG as SERIOUSNESS, ";
                commandText += " REPORTER_TYPE_ENG as REPORTER_TYPE, SOURCE_ENG as SOURCE, PT_NAME_ENG as PT_NAME, SOC_NAME_ENG as SOC_NAME, DURATION_UNIT_ENG as DURATION_UNIT";
            }
            commandText += " FROM CVPONL_OWNER.REPORTS";
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
                                item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.report_no = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
                                item.version_no = dr["VERSION_NO"] == DBNull.Value ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
                                item.date_received = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
                                item.date_int_received = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
                                item.mah_no = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
                                item.reporter_type_code = dr["REPORT_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_CODE"].ToString().Trim();
                                item.report_type_name = dr["REPORT_TYPE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE"].ToString().Trim();
                                item.gender_code = dr["GENDER_CODE"] == DBNull.Value ? string.Empty : dr["GENDER_CODE"].ToString().Trim();
                                item.gender_name = dr["GENDER"] == DBNull.Value ? string.Empty : dr["GENDER"].ToString().Trim();
                                item.age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
                                item.age_y = dr["AGE_Y"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE_Y"]);
                                item.age_unit_code = dr["AGE_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_CODE"].ToString().Trim();
                                item.age_unit = dr["AGE_UNIT"] == DBNull.Value ? string.Empty : dr["AGE_UNIT"].ToString().Trim();
                                item.age_group_code = dr["AGE_GROUP_CODE"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_CODE"].ToString().Trim();
                                item.age_group_name = dr["AGE_GROUP"] == DBNull.Value ? string.Empty : dr["AGE_GROUP"].ToString().Trim();
                                item.outcome_code = dr["OUTCOME_CODE"] == DBNull.Value ? string.Empty : dr["OUTCOME_CODE"].ToString().Trim();
                                item.outcome = dr["OUTCOME"] == DBNull.Value ? string.Empty : dr["OUTCOME"].ToString().Trim();
                                item.weight = dr["WEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["WEIGHT"]);
                                item.weight_unit_code = dr["WEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_CODE"].ToString().Trim();
                                item.weight_unit = dr["WEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT"].ToString().Trim();
                                item.height = dr["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["HEIGHT"]);
                                item.height_unit_code = dr["HEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_CODE"].ToString().Trim();
                                item.height_unit = dr["HEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT"].ToString().Trim();
                                item.seriousness_code = dr["SERIOUSNESS_CODE"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_CODE"].ToString().Trim();
                                item.seriousness = dr["SERIOUSNESS"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS"].ToString().Trim();
                                item.death = dr["DEATH"] == DBNull.Value ? string.Empty : dr["DEATH"].ToString().Trim();
                                item.disability = dr["DISABILITY"] == DBNull.Value ? string.Empty : dr["DISABILITY"].ToString().Trim();
                                item.congenital_anomaly = dr["CONGENITAL_ANOMALY"] == DBNull.Value ? string.Empty : dr["CONGENITAL_ANOMALY"].ToString().Trim();
                                item.life_threatening = dr["LIFE_THREATENING"] == DBNull.Value ? string.Empty : dr["LIFE_THREATENING"].ToString().Trim();
                                item.hosp_required = dr["HOSP_REQUIRED"] == DBNull.Value ? string.Empty : dr["HOSP_REQUIRED"].ToString().Trim();
                                item.other_medically_imp_cond = dr["OTHER_MEDICALLY_IMP_COND"] == DBNull.Value ? string.Empty : dr["OTHER_MEDICALLY_IMP_COND"].ToString().Trim();
                                item.reporter_type_code = dr["REPORTER_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_CODE"].ToString().Trim();
                                item.reporter_type = dr["REPORTER_TYPE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE"].ToString().Trim();
                                item.source_code = dr["SOURCE_CODE"] == DBNull.Value ? string.Empty : dr["SOURCE_CODE"].ToString().Trim();
                                item.source_name = dr["SOURCE"] == DBNull.Value ? string.Empty : dr["SOURCE"].ToString().Trim();
                                item.report_link_flg = dr["REPORT_LINK_FLG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_LINK_FLG"]);
                                item.aer_id = dr["AER_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["AER_ID"]);
                                item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
                                item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
                                item.duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
                                item.duration_unit = dr["DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT"].ToString().Trim();
                                item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();

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


        //public Report GetReportById(int id, string lang)
        //{
        //    var report = new Report();
        //    string commandText = "SELECT REPORT_ID, REPORT_NO, VERSION_NO, DATRECEIVED, DATINTRECEIVED, MAH_NO, REPORT_TYPE_CODE, GENDER_CODE, ";
        //    commandText += " AGE, AGE_Y, AGE_UNIT_CODE, AGE_UNIT_CODE, AGE_GROUP_CODE, OUTCOME_CODE, WEIGHT, WEIGHT_UNIT_CODE, HEIGHT, HEIGHT_UNIT_CODE, DURATION, ";
        //    commandText += " SERIOUSNESS_CODE, DEATH, DISABILITY, CONGENITAL_ANOMALY,LIFE_THREATENING, HOSP_REQUIRED, OTHER_MEDICALLY_IMP_COND, ";
        //    commandText += " REPORTER_TYPE_CODE, SOURCE_CODE, REPORT_LINK_FLG, AER_ID, DRUGNAME";

        //    if (lang.Equals("fr"))
        //    {
        //        commandText += " REPORT_TYPE_FR as REPORT_TYPE, GENDER_FR as GENDER, AGE_UNIT_FR as AGE_UNIT, AGE_GROUP_FR as AGE_GROUP, ";
        //        commandText += " OUTCOME_FR as OUTCOME, WEIGHT_UNIT_FR as WEIGHT_UNIT, HEIGHT_UNIT_FR as HEIGHT_UNIT, SERIOUSNESS_FR as SERIOUSNESS, ";
        //        commandText += " REPORTER_TYPE_FR as REPORTER_TYPE, SOURCE_FR as SOURCE, PT_NAME_FR as PT_NAME, SOC_NAME_FR as SOC_NAME, DURATION_UNIT_FR as DURATION_UNIT";
        //    }
        //    else {
        //        commandText += " REPORT_TYPE_ENG as REPORT_TYPE, GENDER_ENG as GENDER, AGE_UNIT_ENG as AGE_UNIT, AGE_GROUP_ENG as AGE_GROUP, ";
        //        commandText += " OUTCOME_ENG as OUTCOME, WEIGHT_UNIT_ENG as WEIGHT_UNIT, HEIGHT_UNIT_ENG as HEIGHT_UNIT, SERIOUSNESS_ENG as SERIOUSNESS, ";
        //        commandText += " REPORTER_TYPE_ENG as REPORTER_TYPE, SOURCE_ENG as SOURCE, PT_NAME_ENG as PT_NAME, SOC_NAME_ENG as SOC_NAME, DURATION_UNIT_ENG as DURATION_UNIT";
        //    }
        //    commandText += " FROM CVPONL_OWNER.REPORTS WHERE REPORT_ID = :id ";

        //    using (

        //    OracleConnection con = new OracleConnection(DpdDBConnection))
        //    {
        //        OracleCommand cmd = new OracleCommand(commandText, con);
        //        cmd.Parameters.Add("id", id);
        //        try
        //        {
        //            con.Open();
        //            using (OracleDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        var item = new Report();
        //                        item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
        //                        item.report_no = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
        //                        item.version_no = dr["VERSION_NO"] == DBNull.Value ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
        //                        item.date_received = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
        //                        item.date_int_received = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
        //                        item.mah_no = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
        //                        item.reporter_type_code = dr["REPORT_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_CODE"].ToString().Trim();
        //                        item.report_type_name = dr["REPORT_TYPE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE"].ToString().Trim();
        //                        item.gender_code = dr["GENDER_CODE"] == DBNull.Value ? string.Empty : dr["GENDER_CODE"].ToString().Trim();
        //                        item.gender_name = dr["GENDER"] == DBNull.Value ? string.Empty : dr["GENDER"].ToString().Trim();
        //                        item.age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
        //                        item.age_y = dr["AGE_Y"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE_Y"]);
        //                        item.age_unit_code = dr["AGE_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_CODE"].ToString().Trim();
        //                        item.age_unit = dr["AGE_UNIT"] == DBNull.Value ? string.Empty : dr["AGE_UNIT"].ToString().Trim();
        //                        item.age_group_code = dr["AGE_GROUP_CODE"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_CODE"].ToString().Trim();
        //                        item.age_group_name = dr["AGE_GROUP"] == DBNull.Value ? string.Empty : dr["AGE_GROUP"].ToString().Trim();
        //                        item.outcome_code = dr["OUTCOME_CODE"] == DBNull.Value ? string.Empty : dr["OUTCOME_CODE"].ToString().Trim();
        //                        item.outcome = dr["OUTCOME"] == DBNull.Value ? string.Empty : dr["OUTCOME"].ToString().Trim();
        //                        item.weight = dr["WEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["WEIGHT"]);
        //                        item.weight_unit_code = dr["WEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_CODE"].ToString().Trim();
        //                        item.weight_unit = dr["WEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT"].ToString().Trim();
        //                        item.height = dr["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["HEIGHT"]);
        //                        item.height_unit_code = dr["HEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_CODE"].ToString().Trim();
        //                        item.height_unit = dr["HEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT"].ToString().Trim();
        //                        item.seriousness_code = dr["SERIOUSNESS_CODE"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_CODE"].ToString().Trim();
        //                        item.seriousness = dr["SERIOUSNESS"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS"].ToString().Trim();
        //                        item.death = dr["DEATH"] == DBNull.Value ? string.Empty : dr["DEATH"].ToString().Trim();
        //                        item.disability = dr["DISABILITY"] == DBNull.Value ? string.Empty : dr["DISABILITY"].ToString().Trim();
        //                        item.congenital_anomaly = dr["CONGENITAL_ANOMALY"] == DBNull.Value ? string.Empty : dr["CONGENITAL_ANOMALY"].ToString().Trim();
        //                        item.life_threatening = dr["LIFE_THREATENING"] == DBNull.Value ? string.Empty : dr["LIFE_THREATENING"].ToString().Trim();
        //                        item.hosp_required = dr["HOSP_REQUIRED"] == DBNull.Value ? string.Empty : dr["HOSP_REQUIRED"].ToString().Trim();
        //                        item.other_medically_imp_cond = dr["OTHER_MEDICALLY_IMP_COND"] == DBNull.Value ? string.Empty : dr["OTHER_MEDICALLY_IMP_COND"].ToString().Trim();
        //                        item.reporter_type_code = dr["REPORTER_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_CODE"].ToString().Trim();
        //                        item.reporter_type = dr["REPORTER_TYPE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE"].ToString().Trim();
        //                        item.source_code = dr["SOURCE_CODE"] == DBNull.Value ? string.Empty : dr["SOURCE_CODE"].ToString().Trim();
        //                        item.source_name = dr["SOURCE"] == DBNull.Value ? string.Empty : dr["SOURCE"].ToString().Trim();
        //                        item.report_link_flg = dr["REPORT_LINK_FLG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_LINK_FLG"]);
        //                        item.aer_id = dr["AER_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["AER_ID"]);
        //                        item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
        //                        item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
        //                        item.duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
        //                        item.duration_unit = dr["DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT"].ToString().Trim();
        //                        item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();

        //                        report = item;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            string errorMessages = string.Format("DbConnection.cs - GetReportById()");
        //            ExceptionHelper.LogException(ex, errorMessages);
        //            Console.WriteLine(errorMessages);
        //        }
        //        finally
        //        {
        //            if (con.State == ConnectionState.Open)
        //                con.Close();
        //        }
        //    }


        //    return report;
        //}

        //used by detail page and API
        public Report GetReportById(int id, string lang)
        {
            var report = new Report();
            string commandText = "SELECT REPORT_ID, REPORT_NO, VERSION_NO, DATRECEIVED, DATINTRECEIVED, MAH_NO, REPORT_TYPE_CODE, GENDER_CODE, ";
            commandText += " AGE, AGE_Y, AGE_UNIT_CODE, AGE_UNIT_CODE, AGE_GROUP_CODE, OUTCOME_CODE, WEIGHT, WEIGHT_UNIT_CODE, HEIGHT, HEIGHT_UNIT_CODE, ";
            commandText += " SERIOUSNESS_CODE, DEATH, DISABILITY, CONGENITAL_ANOMALY,LIFE_THREATENING, HOSP_REQUIRED, OTHER_MEDICALLY_IMP_COND, DURATION, ";
            commandText += " REPORTER_TYPE_CODE, SOURCE_CODE, REPORT_LINK_FLG, AER_ID, DRUGNAME, ";

            if (lang.Equals("fr"))
            {
                commandText += " REPORT_TYPE_FR as REPORT_TYPE, GENDER_FR as GENDER, AGE_UNIT_FR as AGE_UNIT, AGE_GROUP_FR as AGE_GROUP, ";
                commandText += " OUTCOME_FR as OUTCOME, WEIGHT_UNIT_FR as WEIGHT_UNIT, HEIGHT_UNIT_FR as HEIGHT_UNIT, SERIOUSNESS_FR as SERIOUSNESS, ";
                commandText += " REPORTER_TYPE_FR as REPORTER_TYPE, SOURCE_FR as SOURCE, PT_NAME_FR as PT_NAME, SOC_NAME_FR as SOC_NAME, DURATION_UNIT_FR as DURATION_UNIT";
            }
            else {
                commandText += " REPORT_TYPE_ENG as REPORT_TYPE, GENDER_ENG as GENDER, AGE_UNIT_ENG as AGE_UNIT, AGE_GROUP_ENG as AGE_GROUP, ";
                commandText += " OUTCOME_ENG as OUTCOME, WEIGHT_UNIT_ENG as WEIGHT_UNIT, HEIGHT_UNIT_ENG as HEIGHT_UNIT, SERIOUSNESS_ENG as SERIOUSNESS, ";
                commandText += " REPORTER_TYPE_ENG as REPORTER_TYPE, SOURCE_ENG as SOURCE, PT_NAME_ENG as PT_NAME, SOC_NAME_ENG as SOC_NAME, DURATION_UNIT_ENG as DURATION_UNIT";
            }
            commandText += " FROM CVPONL_OWNER.REPORTS WHERE REPORT_ID = :id ";
            using (

            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":id", id);
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
                                item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.report_no = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
                                item.version_no = dr["VERSION_NO"] == DBNull.Value ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
                                item.date_received = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
                                item.date_int_received = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
                                item.mah_no = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
                                item.reporter_type_code = dr["REPORT_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_CODE"].ToString().Trim();
                                item.report_type_name = dr["REPORT_TYPE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE"].ToString().Trim();
                                item.gender_code = dr["GENDER_CODE"] == DBNull.Value ? string.Empty : dr["GENDER_CODE"].ToString().Trim();
                                item.gender_name = dr["GENDER"] == DBNull.Value ? string.Empty : dr["GENDER"].ToString().Trim();
                                item.age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
                                item.age_y = dr["AGE_Y"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE_Y"]);
                                item.age_unit_code = dr["AGE_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_CODE"].ToString().Trim();
                                item.age_unit = dr["AGE_UNIT"] == DBNull.Value ? string.Empty : dr["AGE_UNIT"].ToString().Trim();
                                item.age_group_code = dr["AGE_GROUP_CODE"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_CODE"].ToString().Trim();
                                item.age_group_name = dr["AGE_GROUP"] == DBNull.Value ? string.Empty : dr["AGE_GROUP"].ToString().Trim();
                                item.outcome_code = dr["OUTCOME_CODE"] == DBNull.Value ? string.Empty : dr["OUTCOME_CODE"].ToString().Trim();
                                item.outcome = dr["OUTCOME"] == DBNull.Value ? string.Empty : dr["OUTCOME"].ToString().Trim();
                                item.weight = dr["WEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["WEIGHT"]);
                                item.weight_unit_code = dr["WEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_CODE"].ToString().Trim();
                                item.weight_unit = dr["WEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT"].ToString().Trim();
                                item.height = dr["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["HEIGHT"]);
                                item.height_unit_code = dr["HEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_CODE"].ToString().Trim();
                                item.height_unit = dr["HEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT"].ToString().Trim();
                                item.seriousness_code = dr["SERIOUSNESS_CODE"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_CODE"].ToString().Trim();
                                item.seriousness = dr["SERIOUSNESS"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS"].ToString().Trim();
                                item.death = dr["DEATH"] == DBNull.Value ? string.Empty : dr["DEATH"].ToString().Trim();
                                item.disability = dr["DISABILITY"] == DBNull.Value ? string.Empty : dr["DISABILITY"].ToString().Trim();
                                item.congenital_anomaly = dr["CONGENITAL_ANOMALY"] == DBNull.Value ? string.Empty : dr["CONGENITAL_ANOMALY"].ToString().Trim();
                                item.life_threatening = dr["LIFE_THREATENING"] == DBNull.Value ? string.Empty : dr["LIFE_THREATENING"].ToString().Trim();
                                item.hosp_required = dr["HOSP_REQUIRED"] == DBNull.Value ? string.Empty : dr["HOSP_REQUIRED"].ToString().Trim();
                                item.other_medically_imp_cond = dr["OTHER_MEDICALLY_IMP_COND"] == DBNull.Value ? string.Empty : dr["OTHER_MEDICALLY_IMP_COND"].ToString().Trim();
                                item.reporter_type_code = dr["REPORTER_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_CODE"].ToString().Trim();
                                item.reporter_type = dr["REPORTER_TYPE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE"].ToString().Trim();
                                item.source_code = dr["SOURCE_CODE"] == DBNull.Value ? string.Empty : dr["SOURCE_CODE"].ToString().Trim();
                                item.source_name = dr["SOURCE"] == DBNull.Value ? string.Empty : dr["SOURCE"].ToString().Trim();
                                item.report_link_flg = dr["REPORT_LINK_FLG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_LINK_FLG"]);
                                item.aer_id = dr["AER_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["AER_ID"]);
                                item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
                                item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
                                item.duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
                                item.duration_unit = dr["DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT"].ToString().Trim();
                                item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
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


        //public List<Report> GetAEReportByDrugName(string drugName)
        //{
        //    var items = new List<Report>();
        //    string strDrugNames = "'" + drugName.Replace(",", "','") + "'";
        //    string commandText = " SELECT rp.* FROM REPORTS rp WHERE rp.REPORT_ID IN (SELECT DISTINCT r.REPORT_ID ";
        //    commandText += "from ADR_MV r, REPORT_DRUGS_MV rd, (SELECT DISTINCT report_id COL1 from REPORT_DRUGS_MV where UPPER(DRUGNAME) IN (SELECT DISTINCT dp.DRUGNAME FROM DRUG_PRODUCTS dp where dp.DRUGNAME IN (" + strDrugNames.ToUpper() + "))) TEMP1 ";
        //    commandText += "where r.datreceived BETWEEN TO_DATE('1965-01-01', 'YYYY/MM/DD') AND TO_DATE('2015-09-30', 'YYYY/MM/DD')and r.REPORT_ID = TEMP1.COL1 AND r.REPORT_ID = rd.REPORT_ID) ";
        //    commandText += "ORDER BY rp.report_id, rp.datreceived";

        //    using (

        //        OracleConnection con = new OracleConnection(DpdDBConnection))
        //    {
        //        OracleCommand cmd = new OracleCommand(commandText, con);
        //        try
        //        {
        //            con.Open();
        //            using (OracleDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        var item = new Report();
        //                        item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
        //                        item.report_no = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
        //                        item.version_no = dr["VERSION_NO"] == DBNull.Value ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
        //                        item.date_received = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
        //                        item.date_int_received = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
        //                        item.mah_no = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
        //                        item.reporter_type_code = dr["REPORT_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_CODE"].ToString().Trim();
        //                        item.report_type_name = dr["REPORT_TYPE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE"].ToString().Trim();
        //                        item.gender_code = dr["GENDER_CODE"] == DBNull.Value ? string.Empty : dr["GENDER_CODE"].ToString().Trim();
        //                        item.gender_name = dr["GENDER"] == DBNull.Value ? string.Empty : dr["GENDER"].ToString().Trim();
        //                        item.age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
        //                        item.age_y = dr["AGE_Y"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE_Y"]);
        //                        item.age_unit_code = dr["AGE_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_CODE"].ToString().Trim();
        //                        item.age_unit = dr["AGE_UNIT"] == DBNull.Value ? string.Empty : dr["AGE_UNIT"].ToString().Trim();
        //                        item.age_group_code = dr["AGE_GROUP_CODE"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_CODE"].ToString().Trim();
        //                        item.age_group_name = dr["AGE_GROUP"] == DBNull.Value ? string.Empty : dr["AGE_GROUP"].ToString().Trim();
        //                        item.outcome_code = dr["OUTCOME_CODE"] == DBNull.Value ? string.Empty : dr["OUTCOME_CODE"].ToString().Trim();
        //                        item.outcome = dr["OUTCOME"] == DBNull.Value ? string.Empty : dr["OUTCOME"].ToString().Trim();
        //                        item.weight = dr["WEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["WEIGHT"]);
        //                        item.weight_unit_code = dr["WEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_CODE"].ToString().Trim();
        //                        item.weight_unit = dr["WEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT"].ToString().Trim();
        //                        item.height = dr["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["HEIGHT"]);
        //                        item.height_unit_code = dr["HEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_CODE"].ToString().Trim();
        //                        item.height_unit = dr["HEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT"].ToString().Trim();
        //                        item.seriousness_code = dr["SERIOUSNESS_CODE"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_CODE"].ToString().Trim();
        //                        item.seriousness = dr["SERIOUSNESS"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS"].ToString().Trim();
        //                        item.death = dr["DEATH"] == DBNull.Value ? string.Empty : dr["DEATH"].ToString().Trim();
        //                        item.disability = dr["DISABILITY"] == DBNull.Value ? string.Empty : dr["DISABILITY"].ToString().Trim();
        //                        item.congenital_anomaly = dr["CONGENITAL_ANOMALY"] == DBNull.Value ? string.Empty : dr["CONGENITAL_ANOMALY"].ToString().Trim();
        //                        item.life_threatening = dr["LIFE_THREATENING"] == DBNull.Value ? string.Empty : dr["LIFE_THREATENING"].ToString().Trim();
        //                        item.hosp_required = dr["HOSP_REQUIRED"] == DBNull.Value ? string.Empty : dr["HOSP_REQUIRED"].ToString().Trim();
        //                        item.other_medically_imp_cond = dr["OTHER_MEDICALLY_IMP_COND"] == DBNull.Value ? string.Empty : dr["OTHER_MEDICALLY_IMP_COND"].ToString().Trim();
        //                        item.reporter_type_code = dr["REPORTER_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_CODE"].ToString().Trim();
        //                        item.reporter_type = dr["REPORTER_TYPE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE"].ToString().Trim();
        //                        item.source_code = dr["SOURCE_CODE"] == DBNull.Value ? string.Empty : dr["SOURCE_CODE"].ToString().Trim();
        //                        item.source_name = dr["SOURCE"] == DBNull.Value ? string.Empty : dr["SOURCE"].ToString().Trim();
        //                        item.report_link_flg = dr["REPORT_LINK_FLG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_LINK_FLG"]);
        //                        item.aer_id = dr["AER_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["AER_ID"]);
        //                        item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
        //                        item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
        //                        item.duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
        //                        item.duration_unit = dr["DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT"].ToString().Trim();
        //                        item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
        //                        items.Add(item);
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            string errorMessages = string.Format("DbConnection.cs - GetReportByDrugName()");
        //            ExceptionHelper.LogException(ex, errorMessages);
        //            Console.WriteLine(errorMessages);
        //        }
        //        finally
        //        {
        //            if (con.State == ConnectionState.Open)
        //                con.Close();
        //        }
        //    }
        //    return items;
        //}


        //public List<AEReport> GetAEExportReportByDrugName(string drugName, string lang)
        //{
        //    var items = new List<AEReport>();
        //    string commandText = "";
        //    //string strDrugNames = "'" + drugName.Replace(",", "','") + "'";
        //    //string commandText = "SELECT r.ADR_ID, r.REPORT_ID, r.REPORT_NO, r.VERSION_NO, r.DATRECEIVED, ";
        //    //commandText += "r.DATINTRECEIVED, r.MAH_NO, r.REPORT_TYPE_ENG, r.REPORT_TYPE_FR, r.GENDER_ENG, ";
        //    //commandText += "r.GENDER_FR, r.AGE, r.AGE_UNIT_ENG, r.AGE_UNIT_FR, r.AGE_GROUP_CODE, r.OUTCOME_ENG, r.OUTCOME_FR, r.WEIGHT, r.WEIGHT_UNIT_ENG, ";
        //    //commandText += "r.WEIGHT_UNIT_FR, r.HEIGHT, r.HEIGHT_UNIT_ENG, r.HEIGHT_UNIT_FR, r.SERIOUSNESS_ENG, r.SERIOUSNESS_FR, r.DEATH, r.DISABILITY, ";
        //    //commandText += "r.CONGENITAL_ANOMALY, r.LIFE_THREATENING, r.HOSP_REQUIRED, r.OTHER_MEDICALLY_IMP_COND, r.REPORTER_TYPE_ENG, r.REPORTER_TYPE_FR, ";
        //    //commandText += "r.SOURCE_ENG, r.SOURCE_FR, r.REPORT_LINK_FLG, r.DURATION, r.DURATION_UNIT_ENG, r.DURATION_UNIT_FR, r.PT_NAME_ENG, ";
        //    //commandText += "r.PT_NAME_FR, r.SOC_NAME_ENG, r.SOC_NAME_FR, r.MEDDRA_VERSION, rd.REPORT_DRUG_ID, rd.DRUGNAME, rd.DRUGINVOLV_ENG, rd.DRUGINVOLV_FR, ";
        //    //commandText += "rd.ROUTEADMIN_ENG, rd.ROUTEADMIN_FR, rd.UNIT_DOSE_QTY, rd.DOSE_UNIT_ENG, rd.DOSE_UNIT_FR, rd.FREQUENCY, rd.FREQ_TIME_UNIT_ENG, ";
        //    //commandText += "rd.FREQ_TIME_UNIT_FR, rd.THERAPY_DURATION, rd.THERAPY_DURATION_UNIT_ENG, rd.THERAPY_DURATION_UNIT_FR, ";
        //    //commandText += "rd.DOSAGEFORM_ENG, rd.DOSAGEFORM_FR, rd.DRUG_PRODUCT_ID, rd.FREQ_TIME, rd.FREQUENCY_TIME_ENG, rd.FREQUENCY_TIME_FR, r.AGE_GROUP_ENG, r.AGE_GROUP_FR, ";
        //    //commandText += "rl.REPORT_LINK, rl.RECORD_TYPE_ENG, rl.RECORD_TYPE_FR, rd.INDICATION_NAME_ENG, rd.INDICATION_NAME_FR ";
        //    //commandText += "from ADR_MV r, REPORT_DRUG rd, REPORT_LINKS rl ";
        //    //commandText += "where r.REPORT_ID = rd.REPORT_ID ";
        //    //commandText += "and r.REPORT_ID = rl.REPORT_ID(+) ";
        //    //commandText += "and r.REPORT_ID in ( ";
        //    //commandText += "select DISTINCT r.REPORT_ID ";
        //    //commandText += "from ADR_MV r, REPORT_DRUGS_MV rd, (SELECT DISTINCT report_id COL1 from REPORT_DRUGS_MV where UPPER(DRUGNAME) IN(SELECT DISTINCT dp.DRUGNAME FROM DRUG_PRODUCTS dp WHERE UPPER(dp.DRUGNAME) IN (" + strDrugNames.ToUpper() + "))) TEMP1 ";
        //    //commandText += " WHERE r.datreceived BETWEEN TO_DATE('1965-01-01', 'YYYY/MM/DD') AND TO_DATE('2015-09-30', 'YYYY/MM/DD') AND r.REPORT_ID = TEMP1.COL1) ";
        //    //commandText += "ORDER BY r.report_id, r.datreceived";

        //    using (

        //        OracleConnection con = new OracleConnection(DpdDBConnection))
        //    {
        //        OracleCommand cmd = new OracleCommand(commandText, con);
        //        try
        //        {
        //            con.Open();
        //            using (OracleDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        var item = new AEReport();

        //                        //                    item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
        //                        //                    item.report_no = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
        //                        //                    item.version_no = dr["VERSION_NO"] == DBNull.Value ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
        //                        //                    item.date_received = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
        //                        //                    item.date_int_received = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
        //                        //                    item.mah_no = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
        //                        //                    item.reporter_type_code = dr["REPORT_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_CODE"].ToString().Trim();
        //                        //                    item.report_type_name = dr["REPORT_TYPE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE"].ToString().Trim();
        //                        //                    item.gender_code = dr["GENDER_CODE"] == DBNull.Value ? string.Empty : dr["GENDER_CODE"].ToString().Trim();
        //                        //                    item.gender_name = dr["GENDER"] == DBNull.Value ? string.Empty : dr["GENDER"].ToString().Trim();
        //                        //                    item.age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
        //                        //                    item.age_y = dr["AGE_Y"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE_Y"]);
        //                        //                    item.age_unit_code = dr["AGE_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_CODE"].ToString().Trim();
        //                        //                    item.age_unit = dr["AGE_UNIT"] == DBNull.Value ? string.Empty : dr["AGE_UNIT"].ToString().Trim();
        //                        //                    item.age_group_code = dr["AGE_GROUP_CODE"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_CODE"].ToString().Trim();
        //                        //                    item.age_group_name = dr["AGE_GROUP"] == DBNull.Value ? string.Empty : dr["AGE_GROUP"].ToString().Trim();
        //                        //                    item.outcome_code = dr["OUTCOME_CODE"] == DBNull.Value ? string.Empty : dr["OUTCOME_CODE"].ToString().Trim();
        //                        //                    item.outcome = dr["OUTCOME"] == DBNull.Value ? string.Empty : dr["OUTCOME"].ToString().Trim();
        //                        //                    item.weight = dr["WEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["WEIGHT"]);
        //                        //                    item.weight_unit_code = dr["WEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_CODE"].ToString().Trim();
        //                        //                    item.weight_unit = dr["WEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT"].ToString().Trim();
        //                        //                    item.height = dr["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["HEIGHT"]);
        //                        //                    item.height_unit_code = dr["HEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_CODE"].ToString().Trim();
        //                        //                    item.height_unit = dr["HEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT"].ToString().Trim();
        //                        //                    item.seriousness_code = dr["SERIOUSNESS_CODE"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_CODE"].ToString().Trim();
        //                        //                    item.seriousness = dr["SERIOUSNESS"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS"].ToString().Trim();
        //                        //                    item.death = dr["DEATH"] == DBNull.Value ? string.Empty : dr["DEATH"].ToString().Trim();
        //                        //                    item.disability = dr["DISABILITY"] == DBNull.Value ? string.Empty : dr["DISABILITY"].ToString().Trim();
        //                        //                    item.congenital_anomaly = dr["CONGENITAL_ANOMALY"] == DBNull.Value ? string.Empty : dr["CONGENITAL_ANOMALY"].ToString().Trim();
        //                        //                    item.life_threatening = dr["LIFE_THREATENING"] == DBNull.Value ? string.Empty : dr["LIFE_THREATENING"].ToString().Trim();
        //                        //                    item.hosp_required = dr["HOSP_REQUIRED"] == DBNull.Value ? string.Empty : dr["HOSP_REQUIRED"].ToString().Trim();
        //                        //                    item.other_medically_imp_cond = dr["OTHER_MEDICALLY_IMP_COND"] == DBNull.Value ? string.Empty : dr["OTHER_MEDICALLY_IMP_COND"].ToString().Trim();
        //                        //                    item.reporter_type_code = dr["REPORTER_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_CODE"].ToString().Trim();
        //                        //                    item.reporter_type = dr["REPORTER_TYPE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE"].ToString().Trim();
        //                        //                    item.source_code = dr["SOURCE_CODE"] == DBNull.Value ? string.Empty : dr["SOURCE_CODE"].ToString().Trim();
        //                        //                    item.source_name = dr["SOURCE"] == DBNull.Value ? string.Empty : dr["SOURCE"].ToString().Trim();
        //                        //                    item.report_link_flg = dr["REPORT_LINK_FLG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_LINK_FLG"]);
        //                        //                    item.aer_id = dr["AER_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["AER_ID"]);
        //                        //                    item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
        //                        //                    item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
        //                        //                    item.duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
        //                        //                    item.duration_unit = dr["DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT"].ToString().Trim();
        //                        //                    item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();

        //                        items.Add(item);
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            string errorMessages = string.Format("DbConnection.cs - GetReportByDrugName()");
        //            ExceptionHelper.LogException(ex, errorMessages);
        //            Console.WriteLine(errorMessages);
        //        }
        //        finally
        //        {
        //            if (con.State == ConnectionState.Open)
        //                con.Close();
        //        }
        //    }
        //    return items;
        //}


        //used by simple search
        public List<Report> GetAllReportByBrandName(string searchTermBrandName, string ageRange, string gender, string seriousReport, string startDate, string endDate, string lang)
        {
            var items = new List<Report>();
            var brandNameReports = new List<Report>();
            var ingredientReports = new List<Report>();
            var ageFrom = "";
            var ageTo = "";
            string commandText = "SELECT REPORT_ID, REPORT_NO, VERSION_NO, DATRECEIVED, DATINTRECEIVED, MAH_NO, REPORT_TYPE_CODE, GENDER_CODE, ";
            commandText += " AGE, AGE_Y, AGE_UNIT_CODE, AGE_UNIT_CODE, AGE_GROUP_CODE, OUTCOME_CODE, WEIGHT, WEIGHT_UNIT_CODE, HEIGHT, HEIGHT_UNIT_CODE, ";
            commandText += " SERIOUSNESS_CODE, DEATH, DISABILITY, CONGENITAL_ANOMALY,LIFE_THREATENING, HOSP_REQUIRED, OTHER_MEDICALLY_IMP_COND, DURATION, ";
            commandText += " REPORTER_TYPE_CODE, SOURCE_CODE, REPORT_LINK_FLG, AER_ID, DRUGNAME,";

            if (lang.Equals("fr"))
            {
                commandText += " REPORT_TYPE_FR as REPORT_TYPE, GENDER_FR as GENDER, AGE_UNIT_FR as AGE_UNIT, AGE_GROUP_FR as AGE_GROUP, ";
                commandText += " OUTCOME_FR as OUTCOME, WEIGHT_UNIT_FR as WEIGHT_UNIT, HEIGHT_UNIT_FR as HEIGHT_UNIT, SERIOUSNESS_FR as SERIOUSNESS, ";
                commandText += " REPORTER_TYPE_FR as REPORTER_TYPE, SOURCE_FR as SOURCE, PT_NAME_FR as PT_NAME, SOC_NAME_FR as SOC_NAME, DURATION_UNIT_FR as DURATION_UNIT";
            }
            else {
                commandText += " REPORT_TYPE_ENG as REPORT_TYPE, GENDER_ENG as GENDER, AGE_UNIT_ENG as AGE_UNIT, AGE_GROUP_ENG as AGE_GROUP, ";
                commandText += " OUTCOME_ENG as OUTCOME, WEIGHT_UNIT_ENG as WEIGHT_UNIT, HEIGHT_UNIT_ENG as HEIGHT_UNIT, SERIOUSNESS_ENG as SERIOUSNESS, ";
                commandText += " REPORTER_TYPE_ENG as REPORTER_TYPE, SOURCE_ENG as SOURCE, PT_NAME_ENG as PT_NAME, SOC_NAME_ENG as SOC_NAME, DURATION_UNIT_ENG as DURATION_UNIT";
            }
            commandText += " FROM CVPONL_OWNER.REPORTS WHERE ";

            if (!string.IsNullOrEmpty(searchTermBrandName))
            {
                commandText += "UPPER(DRUGNAME) LIKE '%' || :searchTermBrandName || '%' ";
            }
            if (!string.IsNullOrEmpty(gender))
            {
                commandText += "AND GENDER_CODE = :gender ";
            }
            if (!string.IsNullOrEmpty(seriousReport))
            {
                commandText += "AND SERIOUSNESS_CODE = :seriousReport ";
            }
            if (!string.IsNullOrEmpty(ageRange))
            {
                List<string> ageRangeSelected = GetAgeRange(ageRange);
                ageFrom = ageRangeSelected[0];
                ageTo = ageRangeSelected[1];
        
                commandText += " AND AGE_Y >= :ageFrom ";
                if (!string.IsNullOrEmpty(ageTo))
                {
                    commandText += " AND AGE_Y <= :ageTo ";
                }
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                commandText += " AND DATINTRECEIVED >= TO_DATE(:startDate, 'YYYY/MM/DD') ";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                commandText += " AND DATINTRECEIVED <= TO_DATE(:endDate, 'YYYY/MM/DD') ";
            }


            using (

                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);

                cmd.Parameters.Add(":searchTermBrandName", searchTermBrandName.ToUpper().Trim());
                if (!string.IsNullOrEmpty(gender))
                {
                    cmd.Parameters.Add(":gender", gender);
                }
                if (!string.IsNullOrEmpty(seriousReport))
                {
                    cmd.Parameters.Add(":seriousReport", seriousReport);
                }
                if (!string.IsNullOrEmpty(ageRange))
                {
                    cmd.Parameters.Add(":ageFrom", ageFrom);
                    if (!string.IsNullOrEmpty(ageTo)) {
                        cmd.Parameters.Add(":ageTo", ageTo);
                    }
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    cmd.Parameters.Add(":startDate", startDate);
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    cmd.Parameters.Add(":endDate", endDate);
                }

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
                                item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.report_no = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
                                item.version_no = dr["VERSION_NO"] == DBNull.Value ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
                                item.date_received = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
                                item.date_int_received = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
                                item.mah_no = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
                                item.report_type_code = dr["REPORT_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_CODE"].ToString().Trim();
                                item.report_type_name = dr["REPORT_TYPE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE"].ToString().Trim();
                                item.gender_code = dr["GENDER_CODE"] == DBNull.Value ? string.Empty : dr["GENDER_CODE"].ToString().Trim();
                                item.gender_name = dr["GENDER"] == DBNull.Value ? string.Empty : dr["GENDER"].ToString().Trim();
                                item.age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
                                item.age_y = dr["AGE_Y"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE_Y"]);
                                item.age_unit_code = dr["AGE_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_CODE"].ToString().Trim();
                                item.age_unit = dr["AGE_UNIT"] == DBNull.Value ? string.Empty : dr["AGE_UNIT"].ToString().Trim();
                                item.age_group_code = dr["AGE_GROUP_CODE"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_CODE"].ToString().Trim();
                                item.age_group_name = dr["AGE_GROUP"] == DBNull.Value ? string.Empty : dr["AGE_GROUP"].ToString().Trim();
                                item.outcome_code = dr["OUTCOME_CODE"] == DBNull.Value ? string.Empty : dr["OUTCOME_CODE"].ToString().Trim();
                                item.outcome = dr["OUTCOME"] == DBNull.Value ? string.Empty : dr["OUTCOME"].ToString().Trim();
                                item.weight = dr["WEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["WEIGHT"]);
                                item.weight_unit_code = dr["WEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_CODE"].ToString().Trim();
                                item.weight_unit = dr["WEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT"].ToString().Trim();
                                item.height = dr["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["HEIGHT"]);
                                item.height_unit_code = dr["HEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_CODE"].ToString().Trim();
                                item.height_unit = dr["HEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT"].ToString().Trim();
                                item.seriousness_code = dr["SERIOUSNESS_CODE"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_CODE"].ToString().Trim();
                                item.seriousness = dr["SERIOUSNESS"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS"].ToString().Trim();
                                item.death = dr["DEATH"] == DBNull.Value ? string.Empty : dr["DEATH"].ToString().Trim();
                                item.disability = dr["DISABILITY"] == DBNull.Value ? string.Empty : dr["DISABILITY"].ToString().Trim();
                                item.congenital_anomaly = dr["CONGENITAL_ANOMALY"] == DBNull.Value ? string.Empty : dr["CONGENITAL_ANOMALY"].ToString().Trim();
                                item.life_threatening = dr["LIFE_THREATENING"] == DBNull.Value ? string.Empty : dr["LIFE_THREATENING"].ToString().Trim();
                                item.hosp_required = dr["HOSP_REQUIRED"] == DBNull.Value ? string.Empty : dr["HOSP_REQUIRED"].ToString().Trim();
                                item.other_medically_imp_cond = dr["OTHER_MEDICALLY_IMP_COND"] == DBNull.Value ? string.Empty : dr["OTHER_MEDICALLY_IMP_COND"].ToString().Trim();
                                item.reporter_type_code = dr["REPORTER_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_CODE"].ToString().Trim();
                                item.reporter_type = dr["REPORTER_TYPE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE"].ToString().Trim();
                                item.source_code = dr["SOURCE_CODE"] == DBNull.Value ? string.Empty : dr["SOURCE_CODE"].ToString().Trim();
                                item.source_name = dr["SOURCE"] == DBNull.Value ? string.Empty : dr["SOURCE"].ToString().Trim();
                                item.report_link_flg = dr["REPORT_LINK_FLG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_LINK_FLG"]);
                                item.aer_id = dr["AER_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["AER_ID"]);
                                item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
                                item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
                                item.duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
                                item.duration_unit = dr["DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT"].ToString().Trim();
                                item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();

                                brandNameReports.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetReportByAllCriteria()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            ingredientReports = GetAllReportByIngredientName(searchTermBrandName, ageRange, gender, seriousReport, startDate, endDate, lang);
            if (ingredientReports != null && ingredientReports.Count > 0)
            {
                var mergedList = brandNameReports.Union(ingredientReports, new ReportComparer());
                items = mergedList.ToList();
            }
            else
            {
                items = brandNameReports;
            }

            return items;
        }

        //used by simple search
        public List<Report> GetAllReportByIngredientName(string searchTermIngredientName, string ageRange, string gender, string seriousReport, string startDate, string endDate, string lang)
        {
            var items = new List<Report>();
            var ageFrom = "";
            var ageTo = "";
            string strIngredientNames = searchTermIngredientName.Replace(",", "','");
            string commandText = "SELECT rp.REPORT_ID, rp.REPORT_NO, rp.VERSION_NO, rp.DATRECEIVED, rp.DATINTRECEIVED, rp.MAH_NO, rp.REPORT_TYPE_CODE, rp.GENDER_CODE, ";
            commandText += " rp.AGE, rp.AGE_Y, rp.AGE_UNIT_CODE, rp.AGE_UNIT_CODE, rp.AGE_GROUP_CODE, rp.OUTCOME_CODE, rp.WEIGHT, rp.WEIGHT_UNIT_CODE, rp.HEIGHT, rp.HEIGHT_UNIT_CODE, ";
            commandText += " rp.SERIOUSNESS_CODE, rp.DEATH, rp.DISABILITY, rp.CONGENITAL_ANOMALY, rp.LIFE_THREATENING, rp.HOSP_REQUIRED, rp.OTHER_MEDICALLY_IMP_COND, rp.DURATION, ";
            commandText += " rp.REPORTER_TYPE_CODE, rp.SOURCE_CODE, rp.REPORT_LINK_FLG, rp.AER_ID, rp.DRUGNAME,";

            if (lang.Equals("fr"))
            {
                commandText += " rp.REPORT_TYPE_FR as REPORT_TYPE, rp.GENDER_FR as GENDER, rp.AGE_UNIT_FR as AGE_UNIT, rp.AGE_GROUP_FR as AGE_GROUP, ";
                commandText += " rp.OUTCOME_FR as OUTCOME, rp.WEIGHT_UNIT_FR as WEIGHT_UNIT, rp.HEIGHT_UNIT_FR as HEIGHT_UNIT, rp.SERIOUSNESS_FR as SERIOUSNESS, ";
                commandText += " rp.REPORTER_TYPE_FR as REPORTER_TYPE, rp.SOURCE_FR as SOURCE, rp.PT_NAME_FR as PT_NAME, rp.SOC_NAME_FR as SOC_NAME, rp.DURATION_UNIT_FR as DURATION_UNIT ";
            }
            else {
                commandText += " rp.REPORT_TYPE_ENG as REPORT_TYPE, rp.GENDER_ENG as GENDER, rp.AGE_UNIT_ENG as AGE_UNIT, rp.AGE_GROUP_ENG as AGE_GROUP, ";
                commandText += " rp.OUTCOME_ENG as OUTCOME, rp.WEIGHT_UNIT_ENG as WEIGHT_UNIT, rp.HEIGHT_UNIT_ENG as HEIGHT_UNIT, rp.SERIOUSNESS_ENG as SERIOUSNESS, ";
                commandText += " rp.REPORTER_TYPE_ENG as REPORTER_TYPE, rp.SOURCE_ENG as SOURCE, rp.PT_NAME_ENG as PT_NAME, rp.SOC_NAME_ENG as SOC_NAME, rp.DURATION_UNIT_ENG as DURATION_UNIT ";
            }

            commandText += "FROM REPORTS rp WHERE rp.REPORT_ID IN (SELECT DISTINCT r.REPORT_ID ";
            commandText += "from ADR_MV r, REPORT_DRUGS_MV rd, (SELECT DISTINCT report_id COL1 from REPORT_DRUGS_MV where UPPER(DRUGNAME) IN (SELECT DISTINCT dpi.DRUGNAME FROM DRUG_PRODUCT_INGREDIENTS dpi where UPPER(dpi.ACTIVE_INGREDIENT_NAME) LIKE '%' || :strIngredientNames || '%' )) TEMP1 ";
            commandText += "where r.datreceived BETWEEN TO_DATE('1965-01-01', 'YYYY/MM/DD') AND TO_DATE('2015-09-30', 'YYYY/MM/DD')and r.REPORT_ID = TEMP1.COL1 AND r.REPORT_ID = rd.REPORT_ID) ";

            if (!string.IsNullOrEmpty(gender))
            {
                commandText += " AND rp.GENDER_CODE = :gender ";
            }
            if (!string.IsNullOrEmpty(seriousReport))
            {
                commandText += " AND rp.SERIOUSNESS_CODE = :seriousReport ";
            }
            if (!string.IsNullOrEmpty(ageRange))
            {
                List<string> ageRangeSelected = GetAgeRange(ageRange);
                ageFrom = ageRangeSelected[0];
                ageTo = ageRangeSelected[1];

                commandText += " AND rp.AGE_Y >= :ageFrom ";
                if (!string.IsNullOrEmpty(ageTo))
                {
                    commandText += " AND rp.AGE_Y <= :ageTo ";
                }
            }

            if (!string.IsNullOrEmpty(startDate))
            {
                commandText += " AND rp.DATINTRECEIVED >= TO_DATE(:startDate, 'YYYY/MM/DD') ";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                commandText += " AND rp.DATINTRECEIVED <= TO_DATE(:endDate, 'YYYY/MM/DD') ";
            }

            commandText += " ORDER BY rp.report_id, rp.datreceived";


            using (

                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":strIngredientNames", strIngredientNames.ToUpper().Trim());
                if (!string.IsNullOrEmpty(gender))
                {
                    cmd.Parameters.Add(":gender", gender);
                }
                if (!string.IsNullOrEmpty(seriousReport))
                {
                    cmd.Parameters.Add(":seriousReport", seriousReport);
                }
                if (!string.IsNullOrEmpty(ageRange))
                {
                    cmd.Parameters.Add(":ageFrom", ageFrom);
                    if (!string.IsNullOrEmpty(ageTo))
                    {
                        cmd.Parameters.Add(":ageTo", ageTo);
                    }
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    cmd.Parameters.Add(":startDate", startDate);
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    cmd.Parameters.Add(":endDate", endDate);
                }

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
                                item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.report_no = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
                                item.version_no = dr["VERSION_NO"] == DBNull.Value ? 0 : Convert.ToInt32(dr["VERSION_NO"]);
                                item.date_received = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
                                item.date_int_received = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
                                item.mah_no = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
                                item.report_type_code = dr["REPORT_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_CODE"].ToString().Trim();
                                item.report_type_name = dr["REPORT_TYPE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE"].ToString().Trim();
                                item.gender_code = dr["GENDER_CODE"] == DBNull.Value ? string.Empty : dr["GENDER_CODE"].ToString().Trim();
                                item.gender_name = dr["GENDER"] == DBNull.Value ? string.Empty : dr["GENDER"].ToString().Trim();
                                item.age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
                                item.age_y = dr["AGE_Y"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE_Y"]);
                                item.age_unit_code = dr["AGE_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["AGE_UNIT_CODE"].ToString().Trim();
                                item.age_unit = dr["AGE_UNIT"] == DBNull.Value ? string.Empty : dr["AGE_UNIT"].ToString().Trim();
                                item.age_group_code = dr["AGE_GROUP_CODE"] == DBNull.Value ? string.Empty : dr["AGE_GROUP_CODE"].ToString().Trim();
                                item.age_group_name = dr["AGE_GROUP"] == DBNull.Value ? string.Empty : dr["AGE_GROUP"].ToString().Trim();
                                item.outcome_code = dr["OUTCOME_CODE"] == DBNull.Value ? string.Empty : dr["OUTCOME_CODE"].ToString().Trim();
                                item.outcome = dr["OUTCOME"] == DBNull.Value ? string.Empty : dr["OUTCOME"].ToString().Trim();
                                item.weight = dr["WEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["WEIGHT"]);
                                item.weight_unit_code = dr["WEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT_CODE"].ToString().Trim();
                                item.weight_unit = dr["WEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["WEIGHT_UNIT"].ToString().Trim();
                                item.height = dr["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(dr["HEIGHT"]);
                                item.height_unit_code = dr["HEIGHT_UNIT_CODE"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT_CODE"].ToString().Trim();
                                item.height_unit = dr["HEIGHT_UNIT"] == DBNull.Value ? string.Empty : dr["HEIGHT_UNIT"].ToString().Trim();
                                item.seriousness_code = dr["SERIOUSNESS_CODE"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_CODE"].ToString().Trim();
                                item.seriousness = dr["SERIOUSNESS"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS"].ToString().Trim();
                                item.death = dr["DEATH"] == DBNull.Value ? string.Empty : dr["DEATH"].ToString().Trim();
                                item.disability = dr["DISABILITY"] == DBNull.Value ? string.Empty : dr["DISABILITY"].ToString().Trim();
                                item.congenital_anomaly = dr["CONGENITAL_ANOMALY"] == DBNull.Value ? string.Empty : dr["CONGENITAL_ANOMALY"].ToString().Trim();
                                item.life_threatening = dr["LIFE_THREATENING"] == DBNull.Value ? string.Empty : dr["LIFE_THREATENING"].ToString().Trim();
                                item.hosp_required = dr["HOSP_REQUIRED"] == DBNull.Value ? string.Empty : dr["HOSP_REQUIRED"].ToString().Trim();
                                item.other_medically_imp_cond = dr["OTHER_MEDICALLY_IMP_COND"] == DBNull.Value ? string.Empty : dr["OTHER_MEDICALLY_IMP_COND"].ToString().Trim();
                                item.reporter_type_code = dr["REPORTER_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE_CODE"].ToString().Trim();
                                item.reporter_type = dr["REPORTER_TYPE"] == DBNull.Value ? string.Empty : dr["REPORTER_TYPE"].ToString().Trim();
                                item.source_code = dr["SOURCE_CODE"] == DBNull.Value ? string.Empty : dr["SOURCE_CODE"].ToString().Trim();
                                item.source_name = dr["SOURCE"] == DBNull.Value ? string.Empty : dr["SOURCE"].ToString().Trim();
                                item.report_link_flg = dr["REPORT_LINK_FLG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_LINK_FLG"]);
                                item.aer_id = dr["AER_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["AER_ID"]);
                                item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
                                item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
                                item.duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
                                item.duration_unit = dr["DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT"].ToString().Trim();
                                item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllReportByIngredientName()");
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

        public List<DrugProduct> GetDrugProductByDrugName(string drugName, string lang)
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
                                item.drug_product_id = dr["DRUG_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_ID"]);
                                item.product_id = dr["PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PRODUCT_ID"]);
                                item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.cpd_flag = dr["CPD_FLAG"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CPD_FLAG"]);

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
        //public List<ReportInfo> GetAllReportInfo(string lang)
        //{
        //    var items = new List<ReportInfo>();
        //    string commandText = "SELECT REPORT_ID, REPORT_NO, DATRECEIVED, DATINTRECEIVED, MAH_NO, AGE, DRUGNAME,";

        //    if (lang.Equals("fr"))
        //    {
        //        commandText += " GENDER_FR as GENDER, AGE_UNIT_FR as AGE_UNIT, PT_NAME_FR as PT_NAME, SOC_NAME_FR as SOC_NAME";

        //    }
        //    else
        //    {
        //        commandText += "GENDER_ENG as GENDER, AGE_UNIT_ENG as AGE_UNIT, PT_NAME_ENG as PT_NAME, SOC_NAME_ENG as SOC_NAME";

        //    }
        //    commandText += " FROM CVPONL_OWNER.REPORTS";

        //    using (OracleConnection con = new OracleConnection(DpdDBConnection))
        //    {
        //        OracleCommand cmd = new OracleCommand(commandText, con);
        //        try
        //        {
        //            con.Open();
        //            using (OracleDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        var item = new ReportInfo();
        //                        item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
        //                        item.report_no = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
        //                        item.date_received = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
        //                        item.date_int_received = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
        //                        item.mah_no = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
        //                        item.gender_name = dr["GENDER"] == DBNull.Value ? string.Empty : dr["GENDER"].ToString().Trim();
        //                        item.age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
        //                        item.age_unit = dr["AGE_UNIT"] == DBNull.Value ? string.Empty : dr["AGE_UNIT"].ToString().Trim();
        //                        item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
        //                        item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
        //                        item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();

        //                        items.Add(item);
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            string errorMessages = string.Format("DbConnection.cs - GetAllReport()");
        //            ExceptionHelper.LogException(ex, errorMessages);

        //            Console.WriteLine(errorMessages);
        //        }
        //        finally
        //        {
        //            if (con.State == ConnectionState.Open)
        //                con.Close();
        //        }
        //    }
        //    return items;
        //}

        //public ReportInfo GetReportInfoById(int id, string lang)
        //{
        //    var report = new ReportInfo();
        //    string commandText = "SELECT REPORT_ID, REPORT_NO, DATRECEIVED, DATINTRECEIVED, MAH_NO, AGE, DRUGNAME,";

        //    if (lang.Equals("fr"))
        //    {
        //        commandText += " GENDER_FR as GENDER, AGE_UNIT_FR as AGE_UNIT, PT_NAME_FR as PT_NAME, SOC_NAME_FR as SOC_NAME";

        //    }
        //    else
        //    {
        //        commandText += "GENDER_ENG as GENDER, AGE_UNIT_ENG as AGE_UNIT, PT_NAME_ENG as PT_NAME, SOC_NAME_ENG as SOC_NAME";

        //    }
        //    commandText += " FROM CVPONL_OWNER.REPORTS WHERE REPORT_ID = :id ";

        //    using (

        //        OracleConnection con = new OracleConnection(DpdDBConnection))
        //    {
        //        OracleCommand cmd = new OracleCommand(commandText, con);
        //        cmd.Parameters.Add(":id", id);
        //        try
        //        {
        //            con.Open();
        //            using (OracleDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        var item = new ReportInfo();
        //                        item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
        //                        item.report_no = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
        //                        item.date_received = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
        //                        item.date_int_received = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
        //                        item.mah_no = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
        //                        item.gender_name = dr["GENDER"] == DBNull.Value ? string.Empty : dr["GENDER"].ToString().Trim();
        //                        item.age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
        //                        item.age_unit = dr["AGE_UNIT"] == DBNull.Value ? string.Empty : dr["AGE_UNIT"].ToString().Trim();
        //                        item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
        //                        item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
        //                        item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();

        //                        report = item;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            string errorMessages = string.Format("DbConnection.cs - GetReportById()");
        //            ExceptionHelper.LogException(ex, errorMessages);
        //            Console.WriteLine(errorMessages);
        //        }
        //        finally
        //        {
        //            if (con.State == ConnectionState.Open)
        //                con.Close();
        //        }
        //    }
        //    return report;
        //}

        //public List<ReportInfo> GetReportInfoByDrugName(string drugName, string lang)
        //{
        //    var items = new List<ReportInfo>();

        //    string strDrugNames = "'" + drugName.Replace(",", "','") + "'";

        //    string commandText = "SELECT REPORT_ID, REPORT_NO, DATRECEIVED, DATINTRECEIVED, MAH_NO, AGE, DRUGNAME,";

        //    if (lang.Equals("fr"))
        //    {
        //        commandText += " GENDER_FR as GENDER, AGE_UNIT_FR as AGE_UNIT, PT_NAME_FR as PT_NAME, SOC_NAME_FR as SOC_NAME";

        //    }
        //    else
        //    {
        //        commandText += "GENDER_ENG as GENDER, AGE_UNIT_ENG as AGE_UNIT, PT_NAME_ENG as PT_NAME, SOC_NAME_ENG as SOC_NAME";

        //    }
        //    commandText += " FROM CVPONL_OWNER.REPORTS WHERE UPPER(DRUGNAME) IN (" + strDrugNames.ToUpper() + ")";
        //    using (

        //        OracleConnection con = new OracleConnection(DpdDBConnection))
        //    {
        //        OracleCommand cmd = new OracleCommand(commandText, con);
        //        try
        //        {
        //            con.Open();
        //            using (OracleDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        var item = new ReportInfo();
        //                        item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
        //                        item.report_no = dr["REPORT_NO"] == DBNull.Value ? string.Empty : dr["REPORT_NO"].ToString().Trim();
        //                        item.date_received = dr["DATRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATRECEIVED"]);
        //                        item.date_int_received = dr["DATINTRECEIVED"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DATINTRECEIVED"]);
        //                        item.mah_no = dr["MAH_NO"] == DBNull.Value ? string.Empty : dr["MAH_NO"].ToString().Trim();
        //                        item.gender_name = dr["GENDER"] == DBNull.Value ? string.Empty : dr["GENDER"].ToString().Trim();
        //                        item.age = dr["AGE"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AGE"]);
        //                        item.age_unit = dr["AGE_UNIT"] == DBNull.Value ? string.Empty : dr["AGE_UNIT"].ToString().Trim();
        //                        item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
        //                        item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
        //                        item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();

        //                        items.Add(item);
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            string errorMessages = string.Format("DbConnection.cs - GetReportByDrugName()");
        //            ExceptionHelper.LogException(ex, errorMessages);
        //            Console.WriteLine(errorMessages);
        //        }
        //        finally
        //        {
        //            if (con.State == ConnectionState.Open)
        //                con.Close();
        //        }
        //    }
        //    return items;
        //}

        // used by API
        public List<Reaction> GetAllReaction(string lang)
        {
            var items = new List<Reaction>();
            string commandText = "SELECT DISTINCT REACTION_ID, REPORT_ID, DURATION, MEDDRA_VERSION, ";
            if (lang.Equals("fr"))
            {
                commandText += " DURATION_UNIT_FR as DURATION_UNIT, PT_NAME_FR as PT_NAME, SOC_NAME_FR as SOC_NAME";

            }
            else
            {
                commandText += " DURATION_UNIT_ENG as DURATION_UNIT, PT_NAME_ENG as PT_NAME, SOC_NAME_ENG as SOC_NAME";

            }
            commandText += " FROM CVPONL_OWNER.REACTIONS";
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
                                var item = new Reaction();
                                item.reaction_id = dr["REACTION_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REACTION_ID"]);
                                item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
                                item.duration_unit = dr["DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT"].ToString().Trim();
                                item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
                                item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
                                item.meddra_version = dr["MEDDRA_VERSION"] == DBNull.Value ? string.Empty : dr["MEDDRA_VERSION"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllReaction()");
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

        // used by API
        public Reaction GetReactionById(int id, string lang)
        {
            var reactions = new Reaction();
            string commandText = "SELECT DISTINCT REACTION_ID, REPORT_ID, DURATION, MEDDRA_VERSION, ";
            if (lang.Equals("fr"))
            {
                commandText += " DURATION_UNIT_FR as DURATION_UNIT, PT_NAME_FR as PT_NAME, SOC_NAME_FR as SOC_NAME";

            }
            else
            {
                commandText += " DURATION_UNIT_ENG as DURATION_UNIT, PT_NAME_ENG as PT_NAME, SOC_NAME_ENG as SOC_NAME";

            }
            commandText += " FROM CVPONL_OWNER.REACTIONS WHERE REACTION_ID = :id ";

            using (

                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":id", id);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Reaction();
                                item.reaction_id = dr["REACTION_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REACTION_ID"]);
                                item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
                                item.duration_unit = dr["DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT"].ToString().Trim();
                                item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
                                item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
                                item.meddra_version = dr["MEDDRA_VERSION"] == DBNull.Value ? string.Empty : dr["MEDDRA_VERSION"].ToString().Trim();

                                reactions = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetReactionById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return reactions;
        }

        // used by detail page
        public List<Reaction> GetReactionByReportId(string reportId, string lang)
        {
            var reaction = new List<Reaction>();
            string commandText = "SELECT DISTINCT REACTION_ID, REPORT_ID, DURATION, MEDDRA_VERSION, ";
            if (lang.Equals("fr"))
            {
                commandText += " DURATION_UNIT_FR as DURATION_UNIT, PT_NAME_FR as PT_NAME, SOC_NAME_FR as SOC_NAME";
            }
            else
            {
                commandText += " DURATION_UNIT_ENG as DURATION_UNIT, PT_NAME_ENG as PT_NAME, SOC_NAME_ENG as SOC_NAME";
            }
            commandText += " FROM CVPONL_OWNER.REACTIONS WHERE REPORT_ID = :reportId ";
            commandText += " ORDER BY UPPER(PT_NAME) ";

            using (

            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":reportId", reportId);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Reaction();
                                item.reaction_id = dr["REACTION_ID"] == DBNull.Value ? 0 : Convert.ToInt64(dr["REACTION_ID"]);
                                item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.duration = dr["DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DURATION"]);
                                item.duration_unit = dr["DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["DURATION_UNIT"].ToString().Trim();
                                item.pt_name = dr["PT_NAME"] == DBNull.Value ? string.Empty : dr["PT_NAME"].ToString().Trim();
                                item.soc_name = dr["SOC_NAME"] == DBNull.Value ? string.Empty : dr["SOC_NAME"].ToString().Trim();
                                item.meddra_version = dr["MEDDRA_VERSION"] == DBNull.Value ? string.Empty : dr["MEDDRA_VERSION"].ToString().Trim();

                                reaction.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetReactionByReportId(reportId, lang)");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return reaction;
        }

        // used by API
        public List<Outcome> GetAllOutcome(string lang)
        {
            var items = new List<Outcome>();
            string commandText = "SELECT DISTINCT OUTCOME_LX_ID, OUTCOME_CODE, ";
            if (lang.Equals("fr"))
            {
                commandText += " FR_DESC as OUTCOME";

            }
            else
            {
                commandText += " EN_DESC as OUTCOME";

            }
            commandText += " FROM CVPONL_OWNER.OUTCOME_LX";

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
                                var item = new Outcome();
                                item.outcome_id = dr["OUTCOME_LX_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["OUTCOME_LX_ID"]);
                                item.outcome_code = dr["OUTCOME_CODE"] == DBNull.Value ? string.Empty : dr["OUTCOME_CODE"].ToString().Trim();
                                item.outcome_name = dr["OUTCOME"] == DBNull.Value ? string.Empty : dr["OUTCOME"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllOutcome()");
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

        // used by API
        public Outcome GetOutcomeById(int id, string lang)
        {
            var outcome = new Outcome();
            string commandText = "SELECT DISTINCT OUTCOME_LX_ID, OUTCOME_CODE, ";
            if (lang.Equals("fr"))
            {
                commandText += " FR_DESC as OUTCOME,";

            }
            else
            {
                commandText += " EN_DESC as OUTCOME";

            }
            commandText += " FROM CVPONL_OWNER.OUTCOME_LX WHERE OUTCOME_LX_ID = :id ";

            using (

            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":id", id);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Outcome();
                                item.outcome_id = dr["OUTCOME_LX_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["OUTCOME_LX_ID"]);
                                item.outcome_code = dr["OUTCOME_CODE"] == DBNull.Value ? string.Empty : dr["OUTCOME_CODE"].ToString().Trim();
                                item.outcome_name = dr["OUTCOME"] == DBNull.Value ? string.Empty : dr["OUTCOME"].ToString().Trim();

                                outcome = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetOutcomeById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return outcome;
        }

        // used by API
        public List<Gender> GetAllGender(string lang)
        {
            var items = new List<Gender>();
            string commandText = "SELECT DISTINCT GENDER_LX_ID, GENDER_CODE, ";
            if (lang.Equals("fr"))
            {
                commandText += " FR_DESC as GENDER";
            }
            else
            {
                commandText += " EN_DESC as GENDER";
            }
            commandText += " FROM CVPONL_OWNER.GENDER_LX";

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
                                var item = new Gender();
                                item.gender_id = dr["GENDER_LX_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["GENDER_LX_ID"]);
                                item.gender_code = dr["GENDER_CODE"] == DBNull.Value ? string.Empty : dr["GENDER_CODE"].ToString().Trim();
                                item.gender_name = dr["GENDER"] == DBNull.Value ? string.Empty : dr["GENDER"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllGender()");
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

        // used by API
        public Gender GetGenderById(int id, string lang)
        {
            var gender = new Gender();
            string commandText = "SELECT DISTINCT GENDER_LX_ID, GENDER_CODE, ";
            if (lang.Equals("fr"))
            {
                commandText += " FR_DESC as GENDER";
            }
            else
            {
                commandText += " EN_DESC as GENDER";
            }
            commandText += " FROM CVPONL_OWNER.GENDER_LX WHERE GENDER_LX_ID = :id ";
            using (

            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":id", id);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Gender();
                                item.gender_id = dr["GENDER_LX_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["GENDER_LX_ID"]);
                                item.gender_code = dr["GENDER_CODE"] == DBNull.Value ? string.Empty : dr["GENDER_CODE"].ToString().Trim();
                                item.gender_name = dr["GENDER"] == DBNull.Value ? string.Empty : dr["GENDER"].ToString().Trim();

                                gender = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetGenderById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return gender;
        }

        // used by API
        public List<ReportType> GetAllReportType(string lang)
        {
            var items = new List<ReportType>();
            string commandText = "SELECT DISTINCT REPORT_TYPE_LX_ID, REPORT_TYPE_CODE, ";
            if (lang.Equals("fr"))
            {
                commandText += " FR_DESC as REPORT_TYPE";
            }
            else
            {
                commandText += " EN_DESC as REPORT_TYPE";
            }
            commandText += " FROM CVPONL_OWNER.REPORT_TYPE_LX";
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
                                var item = new ReportType();
                                item.report_type_id = dr["REPORT_TYPE_LX_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_TYPE_LX_ID"]);
                                item.report_type_code = dr["REPORT_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_CODE"].ToString().Trim();
                                item.report_type = dr["REPORT_TYPE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllReportType()");
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

        // used by API
        public ReportType GetReportTypeById(int id, string lang)
        {
            var reportType = new ReportType();
            string commandText = "SELECT DISTINCT REPORT_TYPE_LX_ID, REPORT_TYPE_CODE, ";
            if (lang.Equals("fr"))
            {
                commandText += " FR_DESC as REPORT_TYPE";
            }
            else
            {
                commandText += " EN_DESC as REPORT_TYPE";
            }
            commandText += " FROM CVPONL_OWNER.REPORT_TYPE_LX WHERE REPORT_TYPE_LX_ID = :id ";

            using (

                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":id", id);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new ReportType();
                                item.report_type_id = dr["REPORT_TYPE_LX_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_TYPE_LX_ID"]);
                                item.report_type_code = dr["REPORT_TYPE_CODE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE_CODE"].ToString().Trim();
                                item.report_type = dr["REPORT_TYPE"] == DBNull.Value ? string.Empty : dr["REPORT_TYPE"].ToString().Trim();

                                reportType = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetReportTypeById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return reportType;
        }

        // used by API
        public List<Seriousness> GetAllSeriousness(string lang)
        {
            var items = new List<Seriousness>();
            string commandText = "SELECT DISTINCT SERIOUSNESS_LX_ID, SERIOUSNESS_CODE, ";
            if (lang.Equals("fr"))
            {
                commandText += " FR_DESC as SERIOUSNESS";
            }
            else
            {
                commandText += " EN_DESC as SERIOUSNESS";
            }
            commandText += " FROM CVPONL_OWNER.SERIOUSNESS_LX";

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
                                var item = new Seriousness();
                                item.seriousness_id = dr["SERIOUSNESS_LX_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SERIOUSNESS_LX_ID"]);
                                item.seriousness_code = dr["SERIOUSNESS_CODE"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_CODE"].ToString().Trim();
                                item.seriousness = dr["SERIOUSNESS"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllSeriousness()");
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

        // used by API
        public Seriousness GetSeriousnessById(int id, string lang)
        {
            var seriousness = new Seriousness();
            string commandText = "SELECT DISTINCT SERIOUSNESS_LX_ID, SERIOUSNESS_CODE, ";
            if (lang.Equals("fr"))
            {
                commandText += " FR_DESC as SERIOUSNESS";
            }
            else
            {
                commandText += " EN_DESC as SERIOUSNESS";
            }
            commandText += " FROM CVPONL_OWNER.SERIOUSNESS_LX WHERE SERIOUSNESS_LX_ID = :id ";

            using (

                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":id", id);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Seriousness();
                                item.seriousness_id = dr["SERIOUSNESS_LX_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SERIOUSNESS_LX_ID"]);
                                item.seriousness_code = dr["SERIOUSNESS_CODE"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS_CODE"].ToString().Trim();
                                item.seriousness = dr["SERIOUSNESS"] == DBNull.Value ? string.Empty : dr["SERIOUSNESS"].ToString().Trim();

                                seriousness = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetSeriousnessById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return seriousness;
        }

        // used by API
        public List<Source> GetAllSource(string lang)
        {
            var items = new List<Source>();
            string commandText = "SELECT DISTINCT SOURCE_LX_ID, SOURCE_CODE,";
            if (lang.Equals("fr"))
            {
                commandText += " FR_DESC as SOURCE";
            }
            else
            {
                commandText += " EN_DESC as SOURCE";
            }
            commandText += " FROM CVPONL_OWNER.SOURCE_LX";

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
                                var item = new Source();
                                item.source_id = dr["SOURCE_LX_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SOURCE_LX_ID"]);
                                item.source_code = dr["SOURCE_CODE"] == DBNull.Value ? string.Empty : dr["SOURCE_CODE"].ToString().Trim();
                                item.source = dr["SOURCE"] == DBNull.Value ? string.Empty : dr["SOURCE"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllSource()");
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

        // used by API
        public Source GetSourceById(int id, string lang)
        {
            var source = new Source();

            string commandText = "SELECT DISTINCT SOURCE_LX_ID, SOURCE_CODE,";
            if (lang.Equals("fr"))
            {
                commandText += " FR_DESC as SOURCE";
            }
            else
            {
                commandText += " EN_DESC as SOURCE";
            }
            commandText += " FROM CVPONL_OWNER.SOURCE_LX WHERE SOURCE_LX_ID = :id ";
            using (
                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":id", id);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new Source();
                                item.source_id = dr["SOURCE_LX_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SOURCE_LX_ID"]);
                                item.source_code = dr["SOURCE_CODE"] == DBNull.Value ? string.Empty : dr["SOURCE_CODE"].ToString().Trim();
                                item.source = dr["SOURCE"] == DBNull.Value ? string.Empty : dr["SOURCE"].ToString().Trim();

                                source = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetSourceById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return source;
        }

        // used by API
        public List<ReportLink> GetAllReportLink(string lang)
        {
            var items = new List<ReportLink>();
            string commandText = "SELECT DISTINCT REPORT_LINK_ID, REPORT_ID, REPORT_LINK,";
            if (lang.Equals("fr"))
            {
                commandText += " RECORD_TYPE_FR as RECORD_TYPE";
            }
            else
            {
                commandText += " RECORD_TYPE_ENG as RECORD_TYPE";
            }
            commandText += " FROM CVPONL_OWNER.REPORT_LINKS";
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
                                var item = new ReportLink();
                                item.report_link_id = dr["REPORT_LINK_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_LINK_ID"]);
                                item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.record_type = dr["RECORD_TYPE"] == DBNull.Value ? string.Empty : dr["RECORD_TYPE"].ToString().Trim();
                                item.report_link_no = dr["REPORT_LINK"] == DBNull.Value ? string.Empty : dr["REPORT_LINK"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllReportLinksLx()");
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

        // used by API
        public ReportLink GetReportLinkById(int id, string lang)
        {
            var reportLinks = new ReportLink();
            string commandText = "SELECT DISTINCT REPORT_LINK_ID, REPORT_ID, REPORT_LINK,";
            if (lang.Equals("fr"))
            {
                commandText += " RECORD_TYPE_FR as RECORD_TYPE";
            }
            else
            {
                commandText += " RECORD_TYPE_ENG as RECORD_TYPE";
            }
            commandText += " FROM CVPONL_OWNER.REPORT_LINKS WHERE REPORT_LINK_ID = :id ";

            using (

            OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":id", id);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new ReportLink();
                                item.report_link_id = dr["REPORT_LINK_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_LINK_ID"]);
                                item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.record_type = dr["RECORD_TYPE"] == DBNull.Value ? string.Empty : dr["RECORD_TYPE"].ToString().Trim();
                                item.report_link_no = dr["REPORT_LINK"] == DBNull.Value ? string.Empty : dr["REPORT_LINK"].ToString().Trim();

                                reportLinks = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetReportLinksLxById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return reportLinks;
        }

        // used by API
        public List<ReportDrug> GetAllReportDrug(string lang)
        {
            var items = new List<ReportDrug>();
            string commandText = "SELECT DISTINCT REPORT_DRUG_ID, REPORT_ID, DRUG_PRODUCT_ID, DRUGNAME, UNIT_DOSE_QTY, FREQUENCY, FREQ_TIME, THERAPY_DURATION, ";
            if (lang.Equals("fr"))
            {
                commandText += " DRUGINVOLV_FR as DRUGINVOLV, ROUTEADMIN_FR AS ROUTEADMIN, DOSE_UNIT_FR as DOSE_UNIT, FREQUENCY_TIME_FR as FREQUENCY_TIME, ";
                commandText += " FREQ_TIME_UNIT_FR as FREQ_TIME_UNIT, THERAPY_DURATION_UNIT_FR as THERAPY_DURATION_UNIT, DOSAGEFORM_FR as DOSAGEFORM";
            }
            else
            {
                commandText += " DRUGINVOLV_ENG as DRUGINVOLV, ROUTEADMIN_ENG AS ROUTEADMIN, DOSE_UNIT_ENG as DOSE_UNIT, FREQUENCY_TIME_ENG as FREQUENCY_TIME, ";
                commandText += " FREQ_TIME_UNIT_ENG as FREQ_TIME_UNIT, THERAPY_DURATION_UNIT_ENG as THERAPY_DURATION_UNIT, DOSAGEFORM_ENG as DOSAGEFORM";
            }
            commandText += " FROM CVPONL_OWNER.REPORT_DRUG";

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
                                var item = new ReportDrug();
                                item.report_drug_id = dr["REPORT_DRUG_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_DRUG_ID"]);
                                item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.drug_product_id = dr["DRUG_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_ID"]);
                                item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.drug_involv_name = dr["DRUGINVOLV"] == DBNull.Value ? string.Empty : dr["DRUGINVOLV"].ToString().Trim();
                                item.route_admin_name = dr["ROUTEADMIN"] == DBNull.Value ? string.Empty : dr["ROUTEADMIN"].ToString().Trim();
                                item.unit_dose_qty = dr["UNIT_DOSE_QTY"] == DBNull.Value ? 0 : Convert.ToInt32(dr["UNIT_DOSE_QTY"]);
                                item.dose_unit = dr["DOSE_UNIT"] == DBNull.Value ? string.Empty : dr["DOSE_UNIT"].ToString().Trim();
                                item.frequency = dr["FREQUENCY"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FREQUENCY"]);
                                item.freq_time = dr["FREQ_TIME"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FREQ_TIME"]);
                                item.frequency_time = dr["FREQUENCY_TIME"] == DBNull.Value ? string.Empty : dr["FREQUENCY_TIME"].ToString().Trim();
                                item.freq_time_unit = dr["FREQ_TIME_UNIT"] == DBNull.Value ? string.Empty : dr["FREQ_TIME_UNIT"].ToString().Trim();
                                item.therapy_duration = dr["THERAPY_DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["THERAPY_DURATION"]);
                                item.therapy_duration_unit = dr["THERAPY_DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["THERAPY_DURATION_UNIT"].ToString().Trim();
                                item.dosage_form = dr["DOSAGEFORM"] == DBNull.Value ? string.Empty : dr["DOSAGEFORM"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllReportDrug()");
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

        // used by detail page
        public List<ReportDrug> GetReportDrugByReportId(string reportId, string lang)
        {
            var items = new List<ReportDrug>();
            string commandText = "SELECT DISTINCT REPORT_DRUG_ID, REPORT_ID, DRUG_PRODUCT_ID, DRUGNAME, UNIT_DOSE_QTY, FREQUENCY, FREQ_TIME, THERAPY_DURATION, ";
            if (lang.Equals("fr"))
            {
                commandText += " DRUGINVOLV_FR as DRUGINVOLV, ROUTEADMIN_FR AS ROUTEADMIN, DOSE_UNIT_FR as DOSE_UNIT, FREQUENCY_TIME_FR as FREQUENCY_TIME, ";
                commandText += " FREQ_TIME_UNIT_FR as FREQ_TIME_UNIT, THERAPY_DURATION_UNIT_FR as THERAPY_DURATION_UNIT, DOSAGEFORM_FR as DOSAGEFORM";
            }
            else
            {
                commandText += " DRUGINVOLV_ENG as DRUGINVOLV, ROUTEADMIN_ENG AS ROUTEADMIN, DOSE_UNIT_ENG as DOSE_UNIT, FREQUENCY_TIME_ENG as FREQUENCY_TIME, ";
                commandText += " FREQ_TIME_UNIT_ENG as FREQ_TIME_UNIT, THERAPY_DURATION_UNIT_ENG as THERAPY_DURATION_UNIT, DOSAGEFORM_ENG as DOSAGEFORM";
            }
            commandText += " FROM CVPONL_OWNER.REPORT_DRUG WHERE REPORT_ID = :reportId ";

            using (OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":reportId", reportId);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new ReportDrug();
                                item.report_drug_id = dr["REPORT_DRUG_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_DRUG_ID"]);
                                item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.drug_product_id = dr["DRUG_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_ID"]);
                                item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.drug_involv_name = dr["DRUGINVOLV"] == DBNull.Value ? string.Empty : dr["DRUGINVOLV"].ToString().Trim();
                                item.route_admin_name = dr["ROUTEADMIN"] == DBNull.Value ? string.Empty : dr["ROUTEADMIN"].ToString().Trim();
                                item.unit_dose_qty = dr["UNIT_DOSE_QTY"] == DBNull.Value ? 0 : Convert.ToInt32(dr["UNIT_DOSE_QTY"]);
                                item.dose_unit = dr["DOSE_UNIT"] == DBNull.Value ? string.Empty : dr["DOSE_UNIT"].ToString().Trim();
                                item.frequency = dr["FREQUENCY"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FREQUENCY"]);
                                item.freq_time = dr["FREQ_TIME"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FREQ_TIME"]);
                                item.frequency_time = dr["FREQUENCY_TIME"] == DBNull.Value ? string.Empty : dr["FREQUENCY_TIME"].ToString().Trim();
                                item.freq_time_unit = dr["FREQ_TIME_UNIT"] == DBNull.Value ? string.Empty : dr["FREQ_TIME_UNIT"].ToString().Trim();
                                item.therapy_duration = dr["THERAPY_DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["THERAPY_DURATION"]);
                                item.therapy_duration_unit = dr["THERAPY_DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["THERAPY_DURATION_UNIT"].ToString().Trim();
                                item.dosage_form = dr["DOSAGEFORM"] == DBNull.Value ? string.Empty : dr["DOSAGEFORM"].ToString().Trim();

                                items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetAllReportDrug()");
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

        // used by API
        public ReportDrug GetReportDrugById(int reportId, string lang)
        {
            var reportDrug = new ReportDrug();
            string commandText = "SELECT DISTINCT REPORT_DRUG_ID, REPORT_ID, DRUG_PRODUCT_ID, FREQ_TIME, DRUGNAME, UNIT_DOSE_QTY, FREQUENCY, THERAPY_DURATION, ";
            if (lang.Equals("fr"))
            {
                commandText += " DRUGINVOLV_FR as DRUGINVOLV, ROUTEADMIN_FR AS ROUTEADMIN, DOSE_UNIT_FR as DOSE_UNIT, FREQUENCY_TIME_FR as FREQUENCY_TIME, ";
                commandText += " FREQ_TIME_UNIT_FR as FREQ_TIME_UNIT, THERAPY_DURATION_UNIT_FR as THERAPY_DURATION_UNIT, DOSAGEFORM_FR as DOSAGEFORM";
            }
            else
            {
                commandText += " DRUGINVOLV_ENG as DRUGINVOLV, ROUTEADMIN_ENG AS ROUTEADMIN, DOSE_UNIT_ENG as DOSE_UNIT, FREQUENCY_TIME_ENG as FREQUENCY_TIME, ";
                commandText += " FREQ_TIME_UNIT_ENG as FREQ_TIME_UNIT, THERAPY_DURATION_UNIT_ENG as THERAPY_DURATION_UNIT, DOSAGEFORM_ENG as DOSAGEFORM";
            }
            commandText += " FROM CVPONL_OWNER.REPORT_DRUG WHERE REPORT_ID = :reportId ";
            using (

                OracleConnection con = new OracleConnection(DpdDBConnection))
            {
                OracleCommand cmd = new OracleCommand(commandText, con);
                cmd.Parameters.Add(":reportId", reportId);
                try
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var item = new ReportDrug();
                                item.report_drug_id = dr["REPORT_DRUG_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_DRUG_ID"]);
                                item.report_id = dr["REPORT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["REPORT_ID"]);
                                item.drug_product_id = dr["DRUG_PRODUCT_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DRUG_PRODUCT_ID"]);
                                item.drug_name = dr["DRUGNAME"] == DBNull.Value ? string.Empty : dr["DRUGNAME"].ToString().Trim();
                                item.drug_involv_name = dr["DRUGINVOLV"] == DBNull.Value ? string.Empty : dr["DRUGINVOLV"].ToString().Trim();
                                item.route_admin_name = dr["ROUTEADMIN"] == DBNull.Value ? string.Empty : dr["ROUTEADMIN"].ToString().Trim();
                                item.unit_dose_qty = dr["UNIT_DOSE_QTY"] == DBNull.Value ? 0 : Convert.ToInt32(dr["UNIT_DOSE_QTY"]);
                                item.dose_unit = dr["DOSE_UNIT"] == DBNull.Value ? string.Empty : dr["DOSE_UNIT"].ToString().Trim();
                                item.frequency = dr["FREQUENCY"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FREQUENCY"]);
                                item.freq_time = dr["FREQ_TIME"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FREQ_TIME"]);
                                item.frequency_time = dr["FREQUENCY_TIME"] == DBNull.Value ? string.Empty : dr["FREQUENCY_TIME"].ToString().Trim();
                                item.freq_time_unit = dr["FREQ_TIME_UNIT"] == DBNull.Value ? string.Empty : dr["FREQ_TIME_UNIT"].ToString().Trim();
                                item.therapy_duration = dr["THERAPY_DURATION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["THERAPY_DURATION"]);
                                item.therapy_duration_unit = dr["THERAPY_DURATION_UNIT"] == DBNull.Value ? string.Empty : dr["THERAPY_DURATION_UNIT"].ToString().Trim();
                                item.dosage_form = dr["DOSAGEFORM"] == DBNull.Value ? string.Empty : dr["DOSAGEFORM"].ToString().Trim();

                                reportDrug = item;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessages = string.Format("DbConnection.cs - GetReportDrugById()");
                    ExceptionHelper.LogException(ex, errorMessages);
                    Console.WriteLine(errorMessages);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return reportDrug;
        }

        /// <summary>
        /// Method that parses and age range string and returns the "to" and "from"
        /// values in the List
        /// </summary>
        /// <param name="ageRangeSelected"></param>
        /// <returns>List of two strings</returns>
        private List<string> GetAgeRange(string ageRangeSelected)
        {
            List<string> ageRange = new List<string>();
            var ageFrom = "";
            var ageTo = "";
            var stringLength = ageRangeSelected.Length;
            //check if there is a hyphen
            if (ageRangeSelected.IndexOf("-") > 0)
            {
                var hyphenPosition = ageRangeSelected.IndexOf("-");
                //parse both sides of the hyphen to get range
                ageFrom = ageRangeSelected.Substring(0, hyphenPosition);
                ageTo = ageRangeSelected.Substring(hyphenPosition + 1, (stringLength - (hyphenPosition + 1)));
            }
            else
            {
                //no upper limit to age
                ageFrom = ageRangeSelected.Substring(0, stringLength);
            }

            ageRange.Add(ageFrom);
            ageRange.Add(ageTo);
            
            return ageRange;
        }

    }


}
