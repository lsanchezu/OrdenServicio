using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Minsur.OrdenServicio.Common.Excel
{
    public static class ExcelHelper
    {
        public static byte[] ExportToExcel2<T>(IEnumerable<T> data, string worksheetTitle)
        {
           
            using (var ms = new MemoryStream())
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(worksheetTitle); 
                
                PropertyInfo[] properties = data.First()?.GetType().GetProperties();

                for (int i = 0; i < properties.Count(); i++)
                {
                    ws.Cell(1, i + 1).Value = ((DisplayAttribute)properties[i].GetCustomAttributes(typeof(DisplayAttribute), false).First()).Name;
                }

                if (data != null && data.Count() > 0)
                {
                    ws.Cell(2, 1).InsertData(data);
                }

                wb.SaveAs(ms);

                return ms.ToArray();
            }
        }

        public static byte[] ExportToExcel<T>(IEnumerable<T> data, string worksheetTitle, List<string> listacolumna)
        {

            using (var ms = new MemoryStream())
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(worksheetTitle);

                for (int i = 0; i < listacolumna.Count(); i++)
                {
                    ws.Cell(1, i + 1).Value = listacolumna[i];
                }
                

                PropertyInfo[] properties = data.First()?.GetType().GetProperties();


                int row = 2;

                foreach (var item in data)
                {
                    for (int i = 0; i < listacolumna.Count(); i++)
                    {
                        var valor = properties.First();
                        var valor2 = ((DisplayAttribute)valor.GetCustomAttributes(typeof(DisplayAttribute), false).First()).GetName();
                        var prop = properties.First(x => ((DisplayAttribute)x.GetCustomAttributes(typeof(DisplayAttribute), false).First()).GetName() == listacolumna[i]);
                        ws.Cell(row, i + 1).Value = prop.GetValue(item);
                    }

                    row += 1;
                }

                wb.SaveAs(ms);

                return ms.ToArray();
            }
        }

        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T)property.GetCustomAttributes(attrType, false).First();
        }
    }
}
