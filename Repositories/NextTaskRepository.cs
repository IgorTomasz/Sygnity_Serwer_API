using Azure;
using CountNextTaskDate.Models;
using CountNextTaskDate.Models.DTOs;
using CountNextTaskDate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CountNextTaskDate.Repositories
{

	public interface INextTaskRepository
	{
		public Task<Object> Get();
		public Task<Object> Calculate(NextTaskRequest req);
	}

	public class NextTaskRepository : INextTaskRepository
	{
		private readonly MyDbContext _dbContext;

		public NextTaskRepository(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public enum Days
		{
			Pn = DayOfWeek.Monday,
			Wt = DayOfWeek.Tuesday,
			Sr = DayOfWeek.Wednesday,
			Cz = DayOfWeek.Thursday,
			Pt = DayOfWeek.Friday,
			Sb = DayOfWeek.Saturday,
			N = DayOfWeek.Sunday
		}

		public async Task<Object> Get()
		{
			NextTaskResponse res = await _dbContext.Responses.OrderByDescending(e => e.id).FirstOrDefaultAsync();

			return new
			{
				count = res.count,
				currentDate = DateOnly.FromDateTime(res.currentDate),
				firstOccurrence = DateOnly.FromDateTime(res.firstOccurrence),
				lastOccurrence = DateOnly.FromDateTime(res.lastOccurrence),
				nextOccurrence = DateOnly.FromDateTime(res.nextOccurrence)
			};
		}

		public async Task<Object> Calculate(NextTaskRequest req)
		{
			DateTime start = req.startDate.ToDateTime(TimeOnly.MinValue);
			DateTime lastCall = DateTime.Today;
			DateTime nextCall = DateTime.Today;
			int count = 0;
			NextTaskResponse resp = null;
			Enum.TryParse(req.day, out Days day);
			Days tempDay = (Days)start.DayOfWeek;
			DateTime tempDate = start;


			if (DateOnly.FromDateTime(start).Equals(DateOnly.FromDateTime(DateTime.Now)) && !tempDay.Equals(day))
			{
				return new
				{
					count = "",
					currentDate = "",
					firstOccurrence = "",
					lastOccurrence = "",
					nextOccurrence = ""
				};
			}

			if (!tempDay.Equals(day))
			{
				int startDay = (int)start.DayOfWeek;
				int initial = (int)day;
				if(startDay > initial)
				{
					start = start.AddDays(7 - startDay + initial);
				}
				else
				{
					start = start.AddDays(initial - startDay);
				}
			}

			count++;

			while (tempDate <= DateTime.Now)
			{
				if(tempDate.AddDays(req.interval * 7) >=DateTime.Now)
				{
					lastCall = tempDate;
					nextCall = lastCall.AddDays(req.interval * 7);
					break;
				}
				tempDate = tempDate.AddDays(req.interval * 7);
				count++;
			}

			resp = new NextTaskResponse
			{
				count = count,
				currentDate = DateTime.Now,
				firstOccurrence = start,
				lastOccurrence = lastCall,
				nextOccurrence = nextCall
			};
			_dbContext.Add(resp);
			_dbContext.SaveChanges();


			return new {
				count = count,
				currentDate = DateOnly.FromDateTime(DateTime.Now),
				firstOccurrence = DateOnly.FromDateTime(start),
				lastOccurrence = DateOnly.FromDateTime(lastCall),
				nextOccurrence = DateOnly.FromDateTime(nextCall)
			};
		}

	}
}
