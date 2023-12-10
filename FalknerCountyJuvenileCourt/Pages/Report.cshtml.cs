using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FalknerCountyJuvenileCourt.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class ReportModel : PageModel
{
    private readonly CourtContext _context;

    public ReportModel(CourtContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnGetArrestedRaceDistributionDataAsync()
    {

        try
        {
            var crimes = _context.Crimes
                .Include(c => c.Juvenile)
                .ThenInclude(j => j.Race)
                .ToList();

            var raceCounts = crimes
                .Select(c => c.Juvenile?.Race?.Name)
                .Where(race => !string.IsNullOrEmpty(race))
                .GroupBy(race => race)
                .Select(group => new { Race = group.Key, Count = group.Count() })
                .ToList();
                foreach (var race in raceCounts)
                    Console.WriteLine($"Race: {race.Race}, Count: {race.Count}");


            return new JsonResult(raceCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data.")
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetGenderDistributionDataAsync()
    {

        try
        {
            var juvenilesWithGender = _context.Juveniles
                .Include(j => j.Gender)
                .ToList();

            var genderCounts = juvenilesWithGender
                .Where(j => j.Gender != null)
                .GroupBy(j => j.Gender.Name)
                .Select(group => new { Gender = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(genderCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data.")
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetAgeDistributionDataAsync()
    {
        Console.WriteLine("Function called");
        try
        {
        var juvenilesWithAge = _context.Juveniles.ToList();

        var ageGroups = juvenilesWithAge
            .GroupBy(j => ((j.Age - 1) / 3) * 3)
            .OrderBy(group => group.Key)
            .Select(group => new { ageGroups = $"{group.Key + 1}-{group.Key + 3}", Count = group.Count() })
            .ToList();


            foreach (var juvenile in juvenilesWithAge)
                Console.WriteLine($"Juvenile ID: {juvenile.ID}, Age: {juvenile.Age}");

            return new JsonResult(ageGroups);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetIntakeDecisionDistributionDataAsync()
    {

        try
        {
            var IntakeDecisionCounts = _context.Crimes
                .GroupBy(j => j.IntakeDecisionID)
                .Select(group => new { IntakeDecisionCounts = group.Key, count = group.Count() })
                .ToList();

            return new JsonResult(IntakeDecisionCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetRiskDistributionDataAsync()
    {

         try
    {
        var juvenileRisk = _context.Juveniles
            .Include(j => j.Risk)
            .ToList();

        var RiskCounts = juvenileRisk
            .Where(j => j.Risk != null)
            .GroupBy(j => j.Risk.Name)
            .Select(group => new { riskcount = group.Key.ToString(), count = group.Count() })
            .ToList();

        return new JsonResult(RiskCounts);
    }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetSchoolDistributionDataAsync()
    {

        try
        {
            var juvenileSchool = _context.Crimes
                .Include(j => j.School)
                .ToList();

            var SchoolCounts = juvenileSchool
                .Where(j => j.School != null)
                .GroupBy(j => j.School.Name)
                .Select(group => new { schoolCount = group.Key, count = group.Count() })
                .ToList();

            return new JsonResult(SchoolCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetFilingDecisionDistributionDataAsync()
    {

        try
        {
            var FilingDecisionCounts = _context.Crimes
                .GroupBy(j => j.FilingDecisionID)
                .Select(group => new { filingdecisioncount = group.Key, count = group.Count() })
                .ToList();

            return new JsonResult(FilingDecisionCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetDelinquencySchoolDistributionDataAsync()
    {

        try
        {
            var juvenilesWithSchool = _context.Crimes.ToList();

            var delinquencyschool = juvenilesWithSchool
                .Where(j => j.FilingDecision != null && j.FilingDecision.ID == 1 && j.School != null)
                .GroupBy(j => j.School.Name)
                .Select(group => new { delinquencyschool = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(delinquencyschool);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetDelinquencyRaceDistributionDataAsync()
    {

        try
        {
            var juvenilesWithrace = _context.Crimes
                .Include(j => j.Juvenile)
                .ToList();

            var delinquencyrace = juvenilesWithrace
                .Where(j => j.FilingDecision != null && j.FilingDecision.ID == 1 && j.Juvenile.Race != null)
                .GroupBy(j => j.Juvenile.Race.Name)
                .Select(group => new { delinquencyrace = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(delinquencyrace);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetDelinquencyGenderDistributionDataAsync()
    {

        try
        {
            var juvenilesWithGender = _context.Crimes
                .Include(j => j.Juvenile)
                .ToList();

            var delinquencygender = juvenilesWithGender
                .Where(j => j.FilingDecision != null && j.FilingDecision.ID == 1 && j.Juvenile.Gender != null)
                .GroupBy(j => j.Juvenile.Gender.Name)
                .Select(group => new { delinquencygender = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(delinquencygender);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data.")
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetDelinquencyAgeDistributionDataAsync()
    {
        Console.WriteLine("Function called");
        try
        {
        var juvenilesWithAge = _context.Crimes
            .Include(j => j.Juvenile)
            .ToList();

        var delinquencyage = juvenilesWithAge
            .Where(j => j.FilingDecision != null && j.FilingDecision.ID == 1 && j.Juvenile.Age != null)
            .GroupBy(j => ((j.Juvenile.Age - 1) / 3) * 3)
            .OrderBy(group => group.Key)
            .Select(group => new { delinquencyage = $"{group.Key + 1}-{group.Key + 3}", Count = group.Count() })
            .ToList();

            return new JsonResult(delinquencyage);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetRaceDistributionDataAsync()
    {

        try
        {
            var crimes = _context.Crimes
                .Include(c => c.Juvenile)
                .ThenInclude(j => j.Race)
                .ToList();

            var raceCounts = crimes
                .Select(c => c.Juvenile?.Race?.Name)
                .Where(race => !string.IsNullOrEmpty(race))
                .GroupBy(race => race)
                .Select(group => new { Race = group.Key, Count = group.Count() })
                .ToList();
                foreach (var race in raceCounts)
                    Console.WriteLine($"Race: {race.Race}, Count: {race.Count}");


            return new JsonResult(raceCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data.")
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetAdGenderDistributionDataAsync()
    {

        try
        {
            var juvenilesWithGender = _context.Juveniles
                .Include(j => j.Gender)
                .ToList();

            var genderCounts = juvenilesWithGender
                .Where(j => j.Gender != null)
                .GroupBy(j => j.Gender.Name)
                .Select(group => new { Gender = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(genderCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data.")
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetAdAgeDistributionDataAsync()
    {
        Console.WriteLine("Function called");
        try
        {
        var juvenilesWithAge = _context.Juveniles.ToList();

        var ageGroups = juvenilesWithAge
            .GroupBy(j => ((j.Age - 1) / 3) * 3)
            .OrderBy(group => group.Key)
            .Select(group => new { ageGroups = $"{group.Key + 1}-{group.Key + 3}", Count = group.Count() })
            .ToList();


            foreach (var juvenile in juvenilesWithAge)
                Console.WriteLine($"Juvenile ID: {juvenile.ID}, Age: {juvenile.Age}");

            return new JsonResult(ageGroups);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetAdRiskDistributionDataAsync()
    {

         try
    {
        var juvenileRisk = _context.Juveniles
            .Include(j => j.Risk)
            .ToList();

        var AdRiskCounts = juvenileRisk
            .Where(j => j.Risk != null)
            .GroupBy(j => j.Risk.Name)
            .Select(group => new { adriskcount = group.Key.ToString(), count = group.Count() })
            .ToList();

        return new JsonResult(AdRiskCounts);
    }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetDrugGenderDistributionDataAsync()
    {

        try
        {
            var juvenilesWithGender = _context.Crimes.ToList();

            var druggenderCounts = juvenilesWithGender
                .Where(j => j.DrugCourt == true)
                .GroupBy(j => j.Juvenile.Gender.Name)
                .Select(group => new { druggendercount = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(druggenderCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetDrugRaceDistributionDataAsync()
    {

        try
        {
            var juvenilesWithRace = _context.Crimes.ToList();

            var drugraceCounts = juvenilesWithRace
                .Where(j => j.DrugCourt == true)
                .GroupBy(j => j.Juvenile.Race.Name)
                .Select(group => new { drugracecount = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(drugraceCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
}
