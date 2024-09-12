﻿using HOTELINKA.DOMAIN.Domain;
using HOTELINKA.DTO;
using HOTELINKA.DTO.Reserva.Request;
using HOTELINKA.DTO.Reserva.Response;

namespace HOTELINKA.APPLICATION
{
    public interface IRservaService
    {
        Task<ResponseDTO> AddReservaAsync(RegistrarReservaRequest request);
        Task<List<ObtenerCalogoHabitacionesDTO>> ObtenerCalogoHabitacionesAsync();
        Task<ObtenerClientePorDNIDTO> ObtenerClienteXDNIAsync(string dni);
    }
}
