using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace Jd.Api.Util
{

    /// <summary>
    /// 导出Excel帮助类
    /// </summary>
    public class ExportExcelHelper
    {
        public static Stream ExportExcel<T>(List<T> list)
        {
            var type = typeof(T);
            var attributeType = typeof(DescriptionAttribute);
            var properties = type.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            var book = new HSSFWorkbook();
            var sheet = book.CreateSheet("Sheet1");
            var header = sheet.CreateRow(0);

            string title;
            object[] attrs;
            foreach (var item in properties)
            {
                title = item.Name;
                attrs = item.GetCustomAttributes(attributeType, false);
                if (attrs.Length > 0)
                {
                    title = (attrs[0] as DescriptionAttribute)?.Description;
                }
                header.CreateCell(header.Cells.Count).SetCellValue(title);
            }

            IRow row;
            ICell cell;
            PropertyInfo prop;
            object value;
            var format = book.CreateDataFormat();
            for (int i = 0; i < list.Count; i++)
            {
                row = sheet.CreateRow(i + 1);
                for (int j = 0; j < properties.Length; j++)
                {
                    prop = properties[j];
                    value = prop.GetValue(list[i], null);
                    cell = row.CreateCell(j);

                    if (value == null)
                    {
                        continue;
                    }
                    cell.SetCellValue(value.ToString());
                    if (prop.PropertyType == typeof(DateTime))
                    {
                        cell.CellStyle.DataFormat = format.GetFormat("yyyy-MM-dd HH:mm:ss");
                    }
                }
            }
            MemoryStream stream = new MemoryStream(5120);
            book.Write(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}
