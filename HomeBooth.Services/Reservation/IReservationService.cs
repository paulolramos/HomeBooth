using System;
namespace HomeBooth.Services
{
    public interface IReservationService
    {
        ServiceResponse<Data.Models.Reservation> GetReservationById(int id);
        ServiceResponse<Data.Models.Reservation> MakeReservation(Data.Models.Reservation reservation);
        ServiceResponse<Data.Models.Reservation> ConfirmReservation(int reservationId);
        ServiceResponse<Data.Models.Reservation> ModifyReservation(int id, Data.Models.Reservation reservation);
        ServiceResponse<Data.Models.Reservation> CancelReservation();
    }
}
