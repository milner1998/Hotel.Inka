using AutoMapper;
using HOTELINKA.DOMAIN.Domain;
using HOTELINKA.DOMAIN.Interface;
using HOTELINKA.DTO;
using HOTELINKA.DTO.Reserva.Request;
using HOTELINKA.DTO.Reserva.Response;

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
            var ultimoRegistroIdentificador = await _reservaRepository.GetLastCodigoReservaAsync();

            var newCodigo = ultimoRegistroIdentificador + 1;

            request.CodigoReserva = "C" + newCodigo.ToString().PadLeft(4, '0');

            return _mapper.Map<ResponseDTO>(await _reservaRepository.AddReservaAsync(_mapper.Map<Reserva>(request)));
        }
        public async Task<List<ObtenerCalogoHabitacionesDTO>> ObtenerCalogoHabitacionesAsync()
        {

            return _mapper.Map<List<ObtenerCalogoHabitacionesDTO>>(await _reservaRepository.GetCatalogoHabitaciones());
        }

        public async Task<ObtenerClientePorDNIDTO> ObtenerClienteXDNIAsync(string dni)
        {

            return _mapper.Map<ObtenerClientePorDNIDTO>(await _reservaRepository.GetClienteByDNI(dni));
        }

        public async Task<ResponseDTO> AddOrdenHospedajeAsync(RegistrarOrdenHospedaje request)
        {

            return _mapper.Map<ResponseDTO>(await _reservaRepository.AddOrdenHospedajeAsync(_mapper.Map<OrdenDeHospedaje>(request)));
        }

        /*public async Task<ObtenerReservaDTO> ObtenerReservarxDNIAsync(string dni)
        {

            return _mapper.Map<ObtenerReservaDTO>(await _reservaRepository.GetReservaXDNI(dni));
        }*/
    }

}
