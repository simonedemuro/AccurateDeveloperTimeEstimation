using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADE.Domain.Models;
using ADE.Domain.ViewModels;
using ADE.Engine;
using Microsoft.AspNetCore.Mvc;

namespace ADE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        DistributionManager distributionManager;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public List<ProjectCompletionOdds> Post([FromBody]List<PertInput> pertInputs)
        {
            //Todo: Some creational pattern here?
            distributionManager = new DistributionManager(pertInputs);
            List<ProjectCompletionOdds> projOdds = distributionManager.GetProjectCompletionOdds();
            return projOdds;
        }
        /*
         * call example
         *  url: https://localhost:44358/api/values
         *  body (application/Json):
         [{
  	        "Optimistic":1,
  	        "Neutral":3,
  	        "Pessimistic":12}
         ]
         */

    }
}
