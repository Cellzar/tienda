using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class ProductosController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    // GET: api/Productos
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ProductoListDto>>> Get([FromQuery] Params productoParams)
    {
        var resultado = await _unitOfWork.Productos.GetAllAsync(productoParams.PageIndex, productoParams.PageSize, productoParams.Search);
        
        var listaProductosDto =  _mapper.Map<List<ProductoListDto>>(resultado.registros);
        return new Pager<ProductoListDto>(listaProductosDto, resultado.totalRegistros, productoParams.PageIndex, productoParams.PageSize, productoParams.Search);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ProductoDto>>> Get11()
    {
        var productos = await _unitOfWork.Productos.GetAllAsync();
        return _mapper.Map<List<ProductoDto>>(productos);
    }

    // GET: api/Productos/4
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductoDto>> GetById(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);
        if(producto == null) 
            return NotFound();

        return _mapper.Map<ProductoDto>(producto);
    }

    // POST: api/Productos
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task <ActionResult<Producto>> Post(ProductoAddUpdateDto productoDto)
    {

        var producto = _mapper.Map<Producto>(productoDto);
        _unitOfWork.Productos.Add(producto);
        await _unitOfWork.SaveAsync();
        if(productoDto == null)
        {
            return BadRequest();
        }
        productoDto.Id = producto.Id;
        return CreatedAtAction(nameof(Post), new { id = productoDto.Id }, productoDto );
    }


    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductoAddUpdateDto>> Put(int id, [FromBody] ProductoAddUpdateDto productoDto)
    {
        if (productoDto == null)
            return NotFound();

        var producto = _mapper.Map<Producto>(productoDto);

        _unitOfWork.Productos.Update(producto);
        await _unitOfWork.SaveAsync();
        return productoDto;
    }

    //// DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);

        if (producto == null)
            return NotFound();

        _unitOfWork.Productos.Remove(producto);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
