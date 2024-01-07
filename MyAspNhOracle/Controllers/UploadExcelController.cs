using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAspNhOracle.Controllers
{
    public class UploadExcelController : Controller
    {
        // GET: UploadExcel
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>

        /// 将datatbale的数据转化为workbook，并设置相关参数

        /// </summary>

        /// <param name="dt"></param>

        /// <param name="workbook"></param>

        /// <param name="sheetName"></param>

        /// <returns></returns>
        public void ImportExcelFile()
        {
            XSSFWorkbook hssfworkbook;
            #region//初始化信息
            try
            {
                //获取选中的excel路径
                string apk_dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Excel");
                HttpPostedFile FileName = Request.Files[0];
                var now = DateTime.UtcNow.AddHours(8);
                Random rand = new Random();
                int shu = rand.Next(100, 999);
                string sourcePath = now.ToString("yyyyMMdd_HH_mmss") + "_" + shu + "_" + FileName.FileName;
                FileName.SaveAs(Path.Combine(apk_dir, sourcePath));
                using (FileStream file = new FileStream(apk_dir + "/" + sourcePath, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new XSSFWorkbook(file);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            #endregion
            NPOI.SS.UserModel.ISheet sheet = hssfworkbook.GetSheetAt(0);
            //using (NPOI.SS.UserModel.ISheet sheet = hssfworkbook.GetSheetAt(0))
            //{
            DataTable table = new DataTable();
            IRow headerRow = sheet.GetRow(0);//第一行为标题行
            int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells
            int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1

            //handling header.
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                if (row != null)
                {
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = GetCellValue(row.GetCell(j));
                    }
                }

                table.Rows.Add(dataRow);
            }
            int res = 0;
            if (table != null)
            {
                res = AddUpExcel(table);
            }
            Response.Write(res);
        }
        /// <summary>
        /// 根据Excel列类型获取列的值
        /// </summary>
        /// <param name="cell">Excel列</param>
        /// <returns></returns>
        private static string GetCellValue(ICell cell)
        {
            if (cell == null)
                return string.Empty;
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return string.Empty;
                case CellType.Boolean:
                    return cell.BooleanCellValue.ToString();
                case CellType.Error:
                    return cell.ErrorCellValue.ToString();
                case CellType.Numeric:
                case CellType.Unknown:
                default:
                    return cell.ToString();//This is a trick to get the correct value of the cell. NumericCellValue will return a numeric value no matter the cell value is a date or a number
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Formula:
                    try
                    {
                        HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                        e.EvaluateInCell(cell);
                        return cell.ToString();
                    }
                    catch
                    {
                        return cell.NumericCellValue.ToString();
                    }
            }
        }

        /// <summary>
        /// 导入信息上传
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddUpExcel(DataTable dataTable)
        {
            //将数据写到数据库里面
            int result = 0;
            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = null;

                List<Model.SMSInfo> list = new List<Model.SMSInfo>();
                //查询数据库的数据
                List<Model.SMSInfo> alllist = GetAllSMS();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    dr = dataTable.Rows[i];
                    Model.SMSInfo info = new Model.SMSInfo();
                    info.PhoneNumber = dr[0].ToString().Trim();
                    info.UserName = dr[1].ToString().Trim();
                    info.Identity = dr[2].ToString().Trim();
                    info.Postage = dr[3].ToString().Trim();
                    info.State = dr[4].ToString().Trim();
                    info.County = dr[5].ToString().Trim();
                    info.Department = dr[6].ToString().Trim();
                    info.Type = 0;
                    //数据库存在数据则不加入
                    var infolist = alllist.Where(a => a.PhoneNumber == dr[0].ToString().Trim()).FirstOrDefault();
                    if (infolist == null) { list.Add(info); }

                }
                //sql方法 加入数据库
                result = InsertSMS(list);
            }
            if (result == dataTable.Rows.Count)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}