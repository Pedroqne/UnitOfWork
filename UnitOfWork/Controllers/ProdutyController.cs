using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Models;
using UnitOfWork.Repository;

namespace UnitOfWork.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnityOfWork _uof;

        public ProductController(IUnityOfWork uof)
        {
            _uof = uof;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var produtos = _uof.ProducyRepository.Get().ToList();

            return Ok(produtos);
        }

        [HttpGet("{id}", Name = "ObterProduto")] 
        public ActionResult<IEnumerable<Product>> GetProductById(int id)
        {
            var produto = _uof.ProducyRepository.GetById(p => p.Id == id);


            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product produto)
        {
            _uof.ProducyRepository.Add(produto);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterProduto", 
                new { id = produto.Id }, produto);
        }

        [HttpPut] 
        public ActionResult Put(int id, [FromBody] Product produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _uof.ProducyRepository.Update(produto);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           var produto = _uof.ProducyRepository.GetById(p => p.Id == id);

            if (produto == null)
            {
                return BadRequest();
            }

            _uof.ProducyRepository.Delete(produto);
            _uof.Commit();

            return Ok(produto);

        }

    }
}
