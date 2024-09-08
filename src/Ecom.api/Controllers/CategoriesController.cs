using Ecom.api.DTO;
using Ecom.core.Entities;
using Ecom.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecom.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //inject unit of work to use repos
        public readonly IUnitOfWork unitOfWork;
        public CategoriesController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        //get all categories
        [HttpGet("get-all-categories")]
        public async Task<IActionResult> GetAll()
        {
            var allCategories = await unitOfWork.CategoryRepository.GetAllAsync();
          
            if (allCategories is not null)
            {
                //map the result to customized form
                var result = allCategories.Select(x => new CategoryDTO
                {
                    name = x.Name,
                    description = x.Description
                });
                return Ok(result);
            }
            else
                return BadRequest("Not Found");
        }

        //get by id
        [HttpGet("get-category-by-id/{id}")]
        public async Task<IActionResult> getCategoryById(int id)
        {
            var categoryFound = await unitOfWork.CategoryRepository.GetAsync(id);

            if (categoryFound is not null)
            {
                var categoryDTO = new CategoryDTO
                {
                    name = categoryFound.Name,
                    description = categoryFound.Description
                };
                return Ok(categoryDTO);

            }
            else
                return BadRequest("Category not found");
        }

        //add category
        [HttpPost("add-new-category")]
        public async Task<IActionResult> addCategory(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                //mapping 
                var newCategory = new Category()
                {
                    Name = categoryDTO.name,
                    Description = categoryDTO.description,
                };

                await unitOfWork.CategoryRepository.AddAsync(newCategory);
                return Ok(categoryDTO);
            }
            else return BadRequest("not found");
        }

        //update category

        [HttpPut("update-category/{id}")]
        public async Task<IActionResult> updateCategory(int id, CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCategory = await unitOfWork.CategoryRepository.GetAsync(id);
            if (existingCategory is null)
            {
                return NotFound("Category not found");
            }

            // Assign old with new values
            existingCategory.Name = categoryDTO.name;
            existingCategory.Description = categoryDTO.description;

            // Update
            await unitOfWork.CategoryRepository.UpdateAsync(id, existingCategory);

            return Ok(categoryDTO);
        }

        //Delete Category
        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var existingCategory = await unitOfWork.CategoryRepository.GetAsync(id);

            if (existingCategory is null)
            {
                return NotFound("Category not found");
            }
             await unitOfWork.CategoryRepository.DeleteAsync(id);
            return Ok("Delete Done");
        }
    }
    }
