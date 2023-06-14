namespace client_app_backend.Core.Repository
{
    using client_app_backend.Core.DataTransferObjects;
    using client_app_backend.Core.Models;
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SurveyRepository : ISurveyRepository
    {
        private readonly DataContext _dbContext;

        public SurveyRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Survey> Get(string id)
        {
            return await _dbContext.Survey
                .SingleOrDefaultAsync(survey => survey.Id == id);
        }

        public async Task<List<Survey>> Get()
        {
            return await _dbContext.Survey
                .ToListAsync();
        }

        public async Task Add(SurveyDTO survey)
        {
            await _dbContext.Survey
                .AddAsync(new Survey(survey));
        }

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
