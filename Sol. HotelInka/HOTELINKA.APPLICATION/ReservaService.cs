using AutoMapper;
using HOTELINKA.DOMAIN.Domain;
using HOTELINKA.DOMAIN.Interface;
using HOTELINKA.DTO;
using HOTELINKA.DTO.Reserva.Request;

namespace HOTELINKA.APPLICATION
{
    public class ReservaService : IRservaService
    {
        private readonly IMapper _mapper;
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IMapper mapper,
                       IReservaRepository reservaRepository)
        {
            _mapper = mapper;
            _reservaRepository = reservaRepository;
        }
         
        public async Task<ResponseDTO> AddReservaAsync(RegistrarReservaRequest request)
        {
            return _mapper.Map<ResponseDTO>(await _reservaRepository.AddReservaAsync(_mapper.Map<Reserva>(request)));
        }
    }
}
