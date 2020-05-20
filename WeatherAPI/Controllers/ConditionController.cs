using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Library.Data;
using WeatherAPI.Library.Models;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionController : ControllerBase
    {
        private readonly IConditionData _conditionData;

        public ConditionController(IConditionData conditionData)
        {
            _conditionData = conditionData;
        }
        public async Task<ConditionModel> Get()
        {
            var reading = await _conditionData.GetLatestCondition();

            ConditionModel currentCondition = new ConditionModel
            {
                Id = reading.FirstOrDefault().Id,
                ReadingId = reading.FirstOrDefault().ReadingId,
                Weather_Condition = reading.FirstOrDefault().Weather_Condition,
                Condition_Description = reading.FirstOrDefault().Condition_Description,
                Icon = reading.FirstOrDefault().Icon
            };

            return currentCondition;
        }
    }
}