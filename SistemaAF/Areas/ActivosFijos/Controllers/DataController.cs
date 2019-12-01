using System;
using System.Net;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Collections.Generic;
using System.Web.Http.Description;
using OfficeOpenXml;
using System.IO;

namespace SistemaAF.Areas.ActivosFijos.Controllers
{
    public class DataController : ApiController
    {
        // Upload data from an excel document
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            var name = httpRequest.Params[0];

            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/Files/" + "uploaded_data");
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, UploadFile(docfiles[0], name));
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        // Download data as an excel document
        [ResponseType(typeof(void))]
        public HttpResponseMessage Get()
        {
            var httpRequest = HttpContext.Current.Request;
            var name = httpRequest.Params[0];
            ExportDataToExcel(name);
            return Request.CreateResponse(System.Net.HttpStatusCode.Accepted, "The file has been downloaded!");
        }

        private void ExportDataToExcel(string name)
        {
            string conn = ConfigurationManager.ConnectionStrings["SistemaAFEntities"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                SqlCommand cmmd = new SqlCommand("SELECT * FROM " + name + ";", sqlConn);
                using (var adapter = new SqlDataAdapter(cmmd))
                {
                    var nacionales = new DataTable();
                    adapter.Fill(nacionales);
                    ExcelPackage excel = new ExcelPackage();
                    var workSheet = excel.Workbook.Worksheets.Add(name);
                    workSheet.Cells["A1"].LoadFromDataTable(nacionales, true);
                    
                    using (var memoryStream = new MemoryStream())
                    {
                        HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;  filename="+ name.ToLower() +"_assets_data.xlsx");
                        excel.SaveAs(memoryStream);
                        memoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                }
            }
        }
        
        private string  UploadFile(string file, string name)
        {
            DataSet ds = new DataSet();
            DataTable tableBakup = new DataTable();

            try
            {
                // Open SQL connection
                SqlConnection connSql = new SqlConnection();
                connSql.ConnectionString = ConfigurationManager.ConnectionStrings["SistemaAFEntities"].ConnectionString;
                connSql.Open();

                // Open Excel connection
                OleDbConnection connXls = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
                        "Data Source="+ file + ";" +
                        "Extended Properties='Excel 12.0 Xml; HDR=YES'");

                if (name.Equals("NACIONALES"))
                {
                    // Backup the old data
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(@"SELECT * FROM Nacionales;", connSql);
                    //sqlDataAdapter.Fill(tableBakup);

                    try {
                        // Get the new data from the excel file
                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(@"SELECT * FROM [NACIONALES$] WHERE NoActivo  IS NOT NULL;", connXls);

                        dataAdapter.Fill(ds);
                        

                        // Upload data to the database server
                        SqlBulkCopy bulkCopy = new SqlBulkCopy(connSql);
                        bulkCopy.DestinationTableName = "Nacionales";
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["NoActivo"].ToString(), "NoActivo");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Division"].ToString(), "Division");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Status"].ToString(), "Status");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Name"].ToString(), "Name");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["TextLine1"].ToString(), "TextLine1");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["AcquisitionDate"].ToString(), "AcquisitionDate");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["AccountingDimension2"].ToString(), "AccountingDimension2");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["AccountingDimension6"].ToString(), "AccountingDimension6");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["PhysicalInventoryNo"].ToString(), "PhysicalInventoryNo");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["LifetimeInMonths"].ToString(), "LifetimeInMonths");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["AcomulatedDeprecationLinear"].ToString(), "AcomulatedDeprecationLinear");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["YearToDateDepreciationLinear"].ToString(), "YearToDateDepreciationLinear");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["AcquisitionCost"].ToString(), "AcquisitionCost");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["ForecastLinear"].ToString(), "ForecastLinear");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Comment"].ToString(), "Comment");
                        //TODO: This isnt working
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Location"].ToString(), "Location");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Image"].ToString(), "Image");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["SerialNumber"].ToString(), "SerialNumber");
                        bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["ActivationDate"].ToString(), "ActivationDate");

                        // Delete old data
                        new SqlCommand("DELETE Nacionales;", connSql).ExecuteNonQuery();

                        bulkCopy.WriteToServer(ds.Tables[0]);
                        return "OK";
                    }
                    catch (Exception ex)
                    {
                        //sqlDataAdapter.Fill(tableBakup);
                        //// Upload data to the database server
                        //SqlBulkCopy bulkCopy = new SqlBulkCopy(connSql);
                        //bulkCopy.DestinationTableName = "Nacionales";

                        //foreach (DataColumn col in tableBakup.Columns)
                        //{
                        //    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                        //}

                        //bulkCopy.WriteToServer(tableBakup);
                        return ex.Message;
                    }
                    
                }
                else
                {
                    
                    // Copy new data to the adapter 
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(@"SELECT DISTINCT * FROM [EXTRANJEROS$] WHERE NoParte IS NOT NULL;", connXls);
                    dataAdapter.Fill(ds);
                    // Upload data to the database server
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(connSql);
                    bulkCopy.DestinationTableName = "Extranjeros";
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["NoParte"].ToString(), "NoParte");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["NoFactura"].ToString(), "NoFactura");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Fecha"].ToString(), "Fecha");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Cantidad"].ToString(), "cantidad");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["CostoUnit"].ToString(), "CostoUnit");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["TipoMcia"].ToString(), "TipoMcia");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["DescEsp"].ToString(), "DescEsp");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["DescIng"].ToString(), "DescIng");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Marca"].ToString(), "Marca");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Modelo"].ToString(), "Modelo");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Serie"].ToString(), "Serie");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Pedimento"].ToString(), "Pedimento");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Proveedor"].ToString(), "Proveedor");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Placas"].ToString(), "Placas");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["NoPacking"].ToString(), "NoPacking");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Comment1"].ToString(), "Comment1");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Test1"].ToString(), "Test1");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Division"].ToString(), "Division");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["NoZEM"].ToString(), "NoZEM");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["NoExt"].ToString(), "NoExt");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Location"].ToString(), "Location");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Status"].ToString(), "Status");
                    bulkCopy.ColumnMappings.Add(ds.Tables[0].Columns["Image"].ToString(), "Image");
                    // Delete old data
                    new SqlCommand("DELETE Extranjeros;", connSql).ExecuteNonQuery();
                    bulkCopy.WriteToServer(ds.Tables[0]);
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message + " : " + ex.StackTrace;
            }
        }
    }
}
