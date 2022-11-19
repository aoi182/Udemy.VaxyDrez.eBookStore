using AutoMapper;

using eBookStore.API.Basket.Application.Basket;
using eBookStore.API.Basket.Clients.Book;
using eBookStore.API.Basket.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Basket.Application.Item
{
    public class GetItems : IRequest<IEnumerable<ItemDto>>
    {
        public int BasketId { get; set; }
    }

    public class GetBasketsHandler : IRequestHandler<GetItems, IEnumerable<ItemDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public GetBasketsHandler(AppDbContext context, IMapper mapper, IBookService bookService)
        {
            _context = context;
            _mapper = mapper;
            _bookService = bookService;
        }

        public async Task<IEnumerable<ItemDto>> Handle(GetItems request, CancellationToken cancellationToken)
        {
            var entities = await _context.Items.Where(q => q.BasketId == request.BasketId).ToListAsync(cancellationToken);

            var dtos = _mapper.Map<IEnumerable<ItemDto>>(entities);

            foreach (var dto in dtos)
            {
                var bookDetails = await _bookService.GetBookAsync(dto.Id);
                if (bookDetails.Item2)
                {
                    dto.BookDetails = new Book
                    {
                        Id = dto.Id,
                        AuthorId = bookDetails.Item1.AuthorId,
                        Name = bookDetails.Item1.Name,
                        Price = bookDetails.Item1.Price
                    };
                }
            }

            return dtos;
        }
    }
}
