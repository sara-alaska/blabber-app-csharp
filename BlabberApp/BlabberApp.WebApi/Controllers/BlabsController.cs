using System.Collections.Generic;
using BlabberApp.DataStore;
using BlabberApp.Domain;
using Microsoft.AspNetCore.Mvc;


namespace BlabberApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlabsController : ControllerBase
    {
        MySqlDataStoreConnection conn = new MySqlDataStoreConnection(
    "Server=143.110.159.170;Port=3306;Database=saraalaskarova;Uid=saraalaskarova;Pwd=letmein;");

        BlabMySqlDataStore fixtureBlab;

        public BlabsController()
        {
            fixtureBlab = new BlabMySqlDataStore(conn);

        }

        [HttpGet]
        public ActionResult Get()
        {
            IDomain[] iDomainBlabs = fixtureBlab.ReadAll();

            List<BlabEntity> blabs =  new List<BlabEntity>();
            foreach (IDomain iDomainBlab in iDomainBlabs)
            {
                blabs.Add((BlabEntity)iDomainBlab);
            }
            if (Response != null)
            {
                Response.ContentType = "application/json";
            }
            return Ok(blabs);
        }


        [HttpGet("{id}")]
        public ActionResult Get(int id) 
        {
            BlabEntity blab;
            IDomain iDomainBlab = fixtureBlab.Read(id);

            blab = (BlabEntity)iDomainBlab;
            if (Response != null)
            {
                Response.ContentType = "application/json";
            }

            if (blab.GetId() == 0)
            {
                return Ok("{\"Error\":\"Blab does not exist\"}");
            }
            return Ok(blab);
            
        }

        [HttpDelete] 
        public ActionResult Delete()
        {
            fixtureBlab.DeleteAll();
            return Ok("{\"Message\":\"Deleted all blabs\"}");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            BlabEntity blab = (BlabEntity)fixtureBlab.Read(id);
            if (blab.GetId() == 0)
            {
                return Ok("{\"Error\":\"Blab does not exist\"}");
            }
            fixtureBlab.Delete(id);  
            return Ok("{\"Message\":\"Blab deleted\"}");

        }

        [HttpPost]
        public ActionResult Create([FromBody] BlabEntity value)
        {
            fixtureBlab.Create(value);
            return Ok(value);
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] BlabEntity value)
        {
            fixtureBlab.Update(id, value.message);
            BlabEntity updated = (BlabEntity)fixtureBlab.Read(id);
            if (updated.GetId() == 0)
            {
                return Ok("{\"Error\":\"Blab does not exist\"}");
            }
            return Ok(updated);
        }
    }
}