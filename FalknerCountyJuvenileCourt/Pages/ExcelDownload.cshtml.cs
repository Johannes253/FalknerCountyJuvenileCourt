using ClosedXML.Excel;
using ExcelStar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExcelStar.Pages;

public class ExcelDownloadModel : PageModel {
    private readonly ILogger<IndexModel> _logger;
    private readonly List<Juvenile> Juveniles;

    public ExcelModel(ILogger<IndexModel> logger) {
        _logger = logger;
    }

    public FileResult OnGet() {

        using (var workbook = new XLWorkbook()) {
            IXLWorksheet worksheet =
            workbook.Worksheets.Add("Juveniles");
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Faulkner County Juvenile ID";
            worksheet.Cell(1, 3).Value = "Age";
            worksheet.Cell(1, 4).Value = "Race";
            worksheet.Cell(1, 5).Value = "Race ID";
            worksheet.Cell(1, 6).Value = "Gender";
            worksheet.Cell(1, 7).Value = "Gender ID";
            worksheet.Cell(1, 8).Value = "Risk";
            worksheet.Cell(1, 9).Value = "Risk ID";
            worksheet.Cell(1, 10).Value = "Repeat Offender";

            IXLRange range = worksheet.Range(worksheet.Cell(1, 1).Address, worksheet.Cell(1, 10).Address);

            int index = 1;

            

        }
    }
}