using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;
using ClosedXML.Excel;

namespace FalknerCountyJuvenileCourt.Pages;

public class ExcelDownloadModel : PageModel {
    private readonly ILogger<IndexModel> _logger;
    private readonly CourtContext _context;
    public ExcelDownloadModel(ILogger<IndexModel> logger, CourtContext context) {
        _logger = logger;
        _context = context;
    }

    public FileResult OnGet() {

        var juveniles = _context.Juveniles
            .Include(j => j.Race)
            .Include(j => j.Gender)
            .Include(j => j.Risk)
            .ToList();

        using (var workbook = new XLWorkbook()) {
            IXLWorksheet worksheet =
            workbook.Worksheets.Add("Juveniles");
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Faulkner County Juvenile ID";
            worksheet.Cell(1, 3).Value = "Age";
            worksheet.Cell(1, 4).Value = "Race";
            worksheet.Cell(1, 5).Value = "Gender";
            worksheet.Cell(1, 6).Value = "Risk";
            worksheet.Cell(1, 7).Value = "Repeat Offender";

            IXLRange range = worksheet.Range(worksheet.Cell(1, 1).Address, worksheet.Cell(1, 7).Address);

            int index = 1;

            foreach (var juvenile in juveniles) {
                index++;

                worksheet.Cell(index, 1).Value = juvenile.ID;
                worksheet.Cell(index, 2).Value = juvenile.FaulknerCountyIdentification;
                worksheet.Cell(index, 3).Value = juvenile.Age;
                worksheet.Cell(index, 4).Value = juvenile.Race?.ToString() ?? string.Empty;
                worksheet.Cell(index, 5).Value = juvenile.Gender?.ToString() ?? string.Empty;
                worksheet.Cell(index, 6).Value = juvenile.Risk?.ToString() ?? "Unknown";
                if(juvenile.Repeat)
                    worksheet.Cell(index, 7).Value = "Yes";
                else
                    worksheet.Cell(index, 7).Value = "No";


            }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                    var strDate = DateTime.Now.ToString("yyyy");
                    string filename = string.Format($"FaulknerCountyAnnualReport_{strDate}.xlsx");

                    return File(content, contentType, filename);
                }
        }
    }
}