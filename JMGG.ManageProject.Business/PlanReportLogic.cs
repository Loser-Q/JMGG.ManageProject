using JMGG.ManageProject.DataAccess;
using JMGG.ManageProject.Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Business
{
    public class PlanReportLogic
    {
        private static readonly PlanReportQuery planQuery = new PlanReportQuery();

        public PlanReportPageResponse QueryPlanRepostListPage(PlanReportRequest request)
        {
            int total = 0;
            var pageList = planQuery.QueryAdPlanReportList(request, out total);

            PlanReportPageResponse page = new PlanReportPageResponse();
            if (pageList != null && pageList.Count > 0)
            {
                page.count = total;
                page.data = pageList;
                return page;
            }
            return page;
        }

        /// <summary>
        /// 统计报表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Tuple<bool, string, string> ExportReportPlanReport(PlanReportRequest request)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory + "ReportFiles\\";
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);
            var fileName = string.Format("data_{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss"));
            var relativePath = "/ReportFiles/" + fileName;
            var filePath = basePath + fileName;
            if (!File.Exists(filePath))
            {
                var f = File.Create(filePath);
                f.Close();
                f.Dispose();
            }
            MemoryStream stream = new MemoryStream();
            IWorkbook eworkbook = new HSSFWorkbook();

            var ssumSheet = eworkbook.CreateSheet(string.Format("data"));
            var ssumR0 = ssumSheet.CreateRow(0);
            ssumR0.CreateCell(0).SetCellValue("投放时间");
            ssumR0.CreateCell(1).SetCellValue("广告ID");
            ssumR0.CreateCell(2).SetCellValue("商家ID");
            ssumR0.CreateCell(3).SetCellValue("广告名称");
            ssumR0.CreateCell(4).SetCellValue("投放状态");
            ssumR0.CreateCell(5).SetCellValue("曝光(PV)");
            ssumR0.CreateCell(6).SetCellValue("点击(CPV)");
            ssumR0.CreateCell(7).SetCellValue("CTR(PV)");
            ssumR0.CreateCell(8).SetCellValue("曝光(UV)");
            ssumR0.CreateCell(9).SetCellValue("点击(CUV)");
            ssumR0.CreateCell(10).SetCellValue("CTR(UV)");
            ssumR0.CreateCell(11).SetCellValue("下载量(DPV)");
            ssumR0.CreateCell(12).SetCellValue("安装量");
            ssumR0.CreateCell(13).SetCellValue("实际消耗金额");
            var rows = planQuery.QueryAdPlanReportExcel(request);
            var index = 1;
            foreach (var item in rows)
            {
                var status = item.LaunchStatus == "1" ? "已发布" : item.LaunchStatus == "2" ? "已结束" : item.LaunchStatus == "3" ? "已暂停" : "";
                IRow theRow = ssumSheet.CreateRow(index);
                theRow.CreateCell(0).SetCellValue(item.LaunchDate.ToString("yyyy-MM-dd HH:mm:ss"));
                theRow.CreateCell(1).SetCellValue(item.NewAdPlanId);
                theRow.CreateCell(2).SetCellValue(item.BussinessId);
                theRow.CreateCell(3).SetCellValue(item.AdName);
                theRow.CreateCell(4).SetCellValue(status);
                theRow.CreateCell(5).SetCellValue(item.PV);
                theRow.CreateCell(6).SetCellValue(item.CPV);
                theRow.CreateCell(7).SetCellValue(item.CTRPV);
                theRow.CreateCell(8).SetCellValue(item.UV);
                theRow.CreateCell(9).SetCellValue(item.UV);
                theRow.CreateCell(10).SetCellValue(item.CUV);
                theRow.CreateCell(11).SetCellValue(item.DPV);
                theRow.CreateCell(12).SetCellValue(item.InstallCount);
                theRow.CreateCell(13).SetCellValue(item.ActualAmount);
                index++;
            }
            ICellStyle style = eworkbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;
            IFont font = eworkbook.CreateFont();
            font.FontHeightInPoints = 10;
            style.SetFont(font);
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderTop = BorderStyle.Thin;
            for (var i = 0; i < eworkbook.NumberOfSheets; i++)
                foreach (IRow row in eworkbook.GetSheetAt(i))
                    foreach (ICell cell in row)
                        cell.CellStyle = style;
            var fs = new FileStream(filePath, FileMode.OpenOrCreate);
            eworkbook.Write(fs);
            fs.Close();
            fs.Dispose();
            return new Tuple<bool, string, string>(true, "生成文件成功,请下载!", relativePath);
        }
    }
}
