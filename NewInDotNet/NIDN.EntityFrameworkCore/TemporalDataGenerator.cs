using Microsoft.Extensions.Logging;
using NIDN.EntityFrameworkCore.Helpers;

namespace NIDN.EntityFrameworkCore;

public class TemporalDataGenerator
{
    private readonly DemoDbContext _dbContext;
    private readonly ILogger<TemporalDataGenerator> _logger;

    public TemporalDataGenerator(DemoDbContext dbContext, ILogger<TemporalDataGenerator> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    /// <summary>
    /// Generates and adds records with some time between to demonstrate Temporal Data
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<(DateTime requestOpened, DateTime requestDenied, DateTime requestOverturned)> GenerateTemporalDataAsync(CancellationToken cancellationToken = default)
    {
        var michael = new User("agent_michael_scarn");
        var toby = new User("t_flenderson");
        var jim = new User("real_dwight_schrute");
        var dwight = new User("dwight_schrute");

        var timeBeforeUsers = DateTime.Now;
        _logger.LogInformation("Creating users...");
        _dbContext.Users.AddRange(michael, toby, jim, dwight);
        await _dbContext.SaveChangesAsync(cancellationToken);

        await Task.Delay(2000, cancellationToken);
        var timeBeforeRequestCreated = DateTime.Now;
        
        _logger.LogInformation("Toby requesting time off...");
        toby.TimeOffRequests.Add(new TimeOffRequest(new DateOnly(2021, 12, 25), new DateOnly(2022, 1, 1)));
        await _dbContext.SaveChangesAsync(cancellationToken);

        await Task.Delay(3000, cancellationToken);
        var timeRequestOpen = DateTime.Now;

        _logger.LogInformation("Michael reviewing time off requests...");
        var openTimeOffRequests = _dbContext.TimeOffRequests.Where(tor => tor.Approved == null);

        foreach (var request in openTimeOffRequests)
        {
            if (request.RequestingUser == toby)
            {
                _logger.LogInformation("Denying request for {RequestingUser}", request.RequestingUser.UserName);
                request.Approved = false;
                request.ReviewingUser = michael;
            }
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        await Task.Delay(2000, cancellationToken);
        var timeAfterDenied = DateTime.Now;

        _logger.LogInformation("Jim reviewing requests flagged for re-review");
        var deniedRequestsFlaggedForReview = _dbContext.TimeOffRequests.Where(tor => tor.Approved == false
            && tor.ReviewingUser == michael
            && tor.RequestingUser == toby);

        foreach (var reqForReview in deniedRequestsFlaggedForReview)
        {
            if (reqForReview.EndDate.Subtract(reqForReview.StartDate).Days < 10)
            {
                _logger.LogInformation("Overturning denial for {RequestingUser}", reqForReview.RequestingUser.UserName);
                reqForReview.Approved = true;
                reqForReview.ReviewingUser = jim;
            }
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        var timeAfterOverturned = DateTime.Now;

        return (timeRequestOpen, timeAfterDenied, timeAfterOverturned);
    }
}
