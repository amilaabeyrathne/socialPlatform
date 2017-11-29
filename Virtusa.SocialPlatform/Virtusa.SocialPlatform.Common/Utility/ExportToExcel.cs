using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Virtusa.SocialPlatform.Common.Utility
{
    public class ExportToExcel<T> where T:class 
    {
        public DataTable MakeDataTable(IEnumerable<T> list)
        {
            bool headerRowGenerated =false;
            // Create a new DataTable. 
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects. 
            DataColumn column;
            DataRow row;

            // Create DataRow objects and add  
            // them to the DataTable 
            foreach (var record in list)
            {
                row = table.NewRow();

                Type objType = record.GetType();
                IList<PropertyInfo> objprops = new List<PropertyInfo>(objType.GetProperties());

                if (!headerRowGenerated)
                {
                    foreach (PropertyInfo prop in objprops.Where(e => e.PropertyType.IsPrimitive || e.PropertyType.Equals(typeof(string))))
                    {
                        // Create new DataColumn, set DataType,  
                        // ColumnName and add to DataTable.     
                        column = new DataColumn();
                        column.DataType = prop.PropertyType;
                        column.ColumnName = prop.Name;
                        column.ReadOnly = false;
                        column.Unique = false;
                        // Add the Column to the DataColumnCollection. 
                        table.Columns.Add(column);
                    }
                    headerRowGenerated = true;
                }

                foreach (PropertyInfo prop in objprops.Where(e => e.PropertyType.IsPrimitive || e.PropertyType.Equals(typeof(string))))
                {
                    row[prop.Name] = prop.GetValue(record, null);
                }
                table.Rows.Add(row);
            }

            return table;
        }

        public void ExportDataSet(DataTable table, string excelFileName)
        {
            using (var workbook = SpreadsheetDocument.Create(excelFileName, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();

                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                uint sheetId = 1;
                if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                {
                    sheetId =
                        sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                }

                DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                sheets.Append(sheet);

                DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();


                // Construct column names 
                List<String> columns = new List<string>();
                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                    headerRow.AppendChild(cell);
                }

                // Add the row values to the excel sheet 
                sheetData.AppendChild(headerRow);

                foreach (System.Data.DataRow dsrow in table.Rows)
                {
                    DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                    foreach (String col in columns)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                        newRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(newRow);
                }
            }
        }

    }
}
