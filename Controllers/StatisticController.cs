using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace netapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Setting.ShowListAllCars();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<double> Get(int id)
        {
            switch (id)
            {
                case 1:
                    return Setting.ShowBalanceParking();                       
                case 2:
                    return Setting.ShowAmountMoneyEarnd();
                 case 3:  
                    return Setting.ShowNumberBusyPlaces();
                 case 4: 
                    return Setting.ShowNumberFreePlaces();
            }
            return 0;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
